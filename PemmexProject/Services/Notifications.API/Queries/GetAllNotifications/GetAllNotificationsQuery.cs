﻿using AutoMapper;
using MediatR;
using Notifications.API.Dtos;
using Notifications.API.NotificationHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notifications.API.Queries.GetAllNotifications
{
    public class GetAllNotificationsQuery : IRequest<List<NotificationDto>>
    {
        public string Id { get; set; }
    }
    public class GetAllNotificationsQueryHandeler : IRequestHandler<GetAllNotificationsQuery, List<NotificationDto>>
    {
        private readonly INotificationRepository _context;
        private readonly IMapper _mapper;

        public GetAllNotificationsQueryHandeler(INotificationRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<NotificationDto>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _context.GetAllNotification(request.Id);
            return _mapper.Map<List<Database.Entities.Notifications>, List<NotificationDto>>(notifications);
        }
    }
}
