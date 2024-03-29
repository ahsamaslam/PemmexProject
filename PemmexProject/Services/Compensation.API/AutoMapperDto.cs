﻿using System;
using AutoMapper;
using Compensation.API.Commands.CreateBudgetCommand;
using Compensation.API.Commands.SaveFunctionalBudgetByWorkFlow;
using Compensation.API.Commands.SaveSalary;
using Compensation.API.Commands.SaveSalaryBonus;
using Compensation.API.Commands.UpdateCompensationAndBonus;
using Compensation.API.Commands.UpdateFunctionalBudget;
using Compensation.API.Database.Entities;
using Compensation.API.Dtos;
using PemmexCommonLibs.Application.Helpers;
using PemmexCommonLibs.Domain.Common.Dtos;
using PemmexCommonLibs.Domain.Enums;

namespace Compensation.API
{
    public class AutoMapperDto:Profile
    {
        public AutoMapperDto()
        {
            CreateMap<JobCatalogue, JobCatalogueDto>().ReverseMap();
            CreateMap<Database.Entities.Compensation, CompensationDto>().ReverseMap();
            CreateMap<Database.Entities.Compensation, CompensationSalaries>()
                .ForMember(d => d.IssuedDate, opt => opt.MapFrom(s => s.EffectiveDate));
            CreateMap<CompensationSalaries, CompensationSalariesDto>().ReverseMap();
            CreateMap<SaveSalaryCommand,CompensationSalaries>();
            CreateMap<SaveSalaryBonusCommand, CompensationSalaries>();
            CreateMap<UpdateCompensationAndBonusCommand,Database.Entities.Compensation>();
            CreateMap<UpdateCompensationAndBonusCommand,CompensationSalaries>();
            CreateMap<CreateBudgetCommand, OrganizationBudget>();
            CreateMap<UpdateCompensationAndBonusCommand, FunctionalBudget>();
            CreateMap<FunctionalBudget, FunctionalBudgetDto>();
            CreateMap<UpdateFunctionalBudgetCommand,FunctionalBudget>();
            CreateMap<SaveFunctionalBudgetByWorkFlowCommand, FunctionalBudget>();


        }

    }
}
