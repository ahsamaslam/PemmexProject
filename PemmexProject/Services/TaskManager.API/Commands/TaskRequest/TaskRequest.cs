﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PemmexCommonLibs.Application.Interfaces;
using PemmexCommonLibs.Domain.Enums;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.API.Database.context;
using TaskManager.API.Database.Entities;
using TaskManager.API.Dtos;
using TaskManager.API.Enumerations;
using TaskManager.API.NotificationHub;

namespace TaskManager.API.Commands.TaskRequest
{
    public class TaskRequest : IRequest
    {
        [JsonIgnore]
        public string RequestedByIdentifier { get; set; }
        [JsonIgnore]
        public string ManagerIdentifier { get; set; }
        [JsonIgnore]
        public string RequestedByName { get; set; }
        [JsonIgnore]
        public string ManagerName { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public string organizationIdentifier { get; set; }
        [JsonIgnore]
        public string businessIdentifier { get; set; }
        public TaskType taskType { get; set; }
        public string taskDescription { get; set; }
        public bool isActive { get; set; }
        public TaskReasons reasons { get; set; }
        public DateTime EffectiveDate { get; set; }

        public CompensationTask compensationTask { get; set; }
        public Dtos.BonusTask bonusTask { get; set; }
        public TitleTask titleTask { get; set; }
        public ManagerTask managerTask { get; set; }
        public GradeTask gradeTask { get; set; }
        public TeamTask teamTask { get; set; }
        public BudgetPromotionTask budgetPromotionTask { get; set; }

    }

    public class TaskRequestCommandHandeler : IRequestHandler<TaskRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;
        private readonly IHubContext<NotificationUserHub> _notificationUserHubContext;
        private readonly IUserConnectionManager _userConnectionManager;
        private readonly INotificationRepository _notificationRepository;
        public TaskRequestCommandHandeler(IApplicationDbContext context,
            IMapper mapper, IHubContext<NotificationUserHub> notificationUserHubContext,
            IUserConnectionManager userConnectionManager,
            INotificationRepository notificationRepository,
            IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _dateTime = dateTime;
            _notificationUserHubContext = notificationUserHubContext;
            _userConnectionManager = userConnectionManager;
            _notificationRepository = notificationRepository;
        }

        public async Task<Unit> Handle(TaskRequest request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.ManagerIdentifier))
                throw new Exception("There is no manager to approve the request");
            var approvesetting = await GetApprovalSettingStructure(request.organizationIdentifier,request.taskType);
            if (approvesetting == null)
            {
                throw new Exception("Approval settings does not contain any approval structure");
            }
            var baseTask = new BaseTask();
            baseTask.isActive = true;
            baseTask.currentTaskStatus = TaskStatuses.Pending;
            baseTask.appliedStatus = TaskStatuses.Initiated;
            baseTask.CreatedBy = request.UserId.ToString();
            baseTask.Created = _dateTime.Now;
            baseTask = PopulateTask(request, baseTask);
            baseTask.taskDescription = request.taskDescription;
            baseTask.RequestedByIdentifier = request.RequestedByIdentifier;
            baseTask.reasons = request.reasons;
            baseTask.EffectiveDate = request.EffectiveDate;
            baseTask.TaskIdentifier = Guid.NewGuid();
            baseTask.ManagerIdentifier = request.ManagerIdentifier;
            baseTask.ManagerName = request.ManagerName;
            baseTask.RequesterName = request.RequestedByName;
            _context.BaseTasks.Add(baseTask);
            var managerTask = PopulateManagerTask(baseTask);
            if (approvesetting.ManagerType == OrganizationApprovalStructure.Other)
            {
                managerTask.RequestedByIdentifier = approvesetting.EmployeeIdentifier;
            }

            _context.BaseTasks.Add(managerTask);
            await _context.SaveChangesAsync(cancellationToken);
            await SendNotification(managerTask, cancellationToken);

            return Unit.Value;
        }
        private async Task<OrganizationApprovalSettingDetail> GetApprovalSettingStructure(string organizationIdentifer, TaskType taskType)
        {
            var setting = await _context.organizationApprovalSettings
                  .Include(d => d.organizationApprovalSettingDetails)
                   .FirstOrDefaultAsync(s => s.OrganizationIdentifier == organizationIdentifer
                   && s.taskType == taskType);

            return setting.organizationApprovalSettingDetails?.FirstOrDefault();
        }
        private async Task SendNotification(BaseTask task, CancellationToken cancellationToken)
        {
            Notifications n = new Notifications()
            {
                isRead = false,
                tasks = task.taskType,
                description = "There is a Request to approve Please see the details",
                title = "Workflow Created",
                EmployeeId = task.RequestedByIdentifier
            };
            await _notificationRepository.AddNotifications(n);
            await _context.SaveChangesAsync(cancellationToken);
            var connections = _userConnectionManager.GetUserConnections(n.EmployeeId.ToString());
            if (connections != null && connections.Count > 0)
            {
                foreach (var connectionId in connections)
                {
                    await _notificationUserHubContext.Clients.Client(connectionId).SendAsync("ReceiveMessage", n.title, n.description, Enum.GetName(NotificationServiceType.TaskService), await _notificationRepository.CountUnReadNotifications(n.EmployeeId));
                }
            }
        }
        private BaseTask PopulateManagerTask(BaseTask dto)
        {
            BaseTask task = new BaseTask();

            task.isActive = true;
            task.ManagerIdentifier = null;
            task.RequestedByIdentifier = dto.ManagerIdentifier;
            task.RequesterName = dto.ManagerName;
            task.currentTaskStatus = TaskStatuses.Pending;
            task.appliedStatus = TaskStatuses.Pending;
            task.taskType = dto.taskType;
            task.CreatedBy = dto.CreatedBy;
            task.Created = _dateTime.Now;
            task.taskDescription = dto.taskDescription;
            task.TaskIdentifier = dto.TaskIdentifier;
            task.EffectiveDate = dto.EffectiveDate;
            task.reasons = dto.reasons;
            return task;
        }

        private BaseTask PopulateTask(TaskRequest dto,BaseTask task)
        {
            task.taskType = dto.taskType;
            if (dto.taskType == TaskType.Compensation && dto.compensationTask != null)
            {
                task.ChangeCompensation = _mapper.Map<CompensationTask, ChangeCompensation>(dto.compensationTask);
            }
            else if (dto.taskType == TaskType.Organization)
            {
                if(dto.gradeTask != null)
                {
                    task.ChangeGrade = _mapper.Map<GradeTask, ChangeGrade>(dto.gradeTask);
                }
                if (dto.managerTask != null)
                {
                    task.ChangeManager = _mapper.Map<ManagerTask, ChangeManager>(dto.managerTask);
                }
                if (dto.compensationTask != null)
                {
                    task.ChangeCompensation = _mapper.Map<CompensationTask, ChangeCompensation>(dto.compensationTask);
                }
                if (dto.titleTask != null)
                {
                    task.ChangeTitle = _mapper.Map<TitleTask, ChangeTitle>(dto.titleTask);
                }
            }
            else if (dto.taskType == TaskType.Title && dto.titleTask != null)
            {
                task.ChangeTitle = _mapper.Map<TitleTask, ChangeTitle>(dto.titleTask);
            }
            else if (dto.taskType == TaskType.Team && dto.teamTask != null)
            {
                task.ChangeTeam = _mapper.Map<TeamTask, ChangeTeam>(dto.teamTask);
            }
            else if (dto.taskType == TaskType.Bonus && dto.bonusTask != null)
            {
                var b = _context.BonusSettings.FirstOrDefault(b => b.businessIdentifier == dto.businessIdentifier);
                var bonus_amount = (dto.bonusTask.one_time_bonus / dto.bonusTask.salary) * 100;
                if (bonus_amount > 0
                    && b.limit_percentage < bonus_amount)
                {
                    throw new Exception("One time bonus amount cannot be more than limit");
                }
                task.ChangeBonus = _mapper.Map<Dtos.BonusTask, Database.Entities.BonusTask>(dto.bonusTask);
            }
            else if (dto.taskType == TaskType.BudgetPromotion)
            {
                if (dto.budgetPromotionTask != null)
                {
                    task.ChangeBudgetPromotion = _mapper.Map<BudgetPromotionTask, ChangeBudgetPromotion>(dto.budgetPromotionTask);
                }
            }

            return task;
        }
    }
}
