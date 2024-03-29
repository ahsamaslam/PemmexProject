﻿using Holidays.API.Commands.SaveHolidays;
using Holidays.API.Commands.SaveHolidaySettings;
using Holidays.API.Database.Entities;
using MediatR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PemmexCommonLibs.Domain.Common;
using PemmexCommonLibs.Domain.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.API.Services
{
    public class HolidayTopicReciever : BackgroundService
    {
        private readonly ISubscriptionClient _subscriptionClient;
        private readonly IMediator _mediator;
        public HolidayTopicReciever(ISubscriptionClient subscriptionClient, IMediator mediator)
        {
            _subscriptionClient = subscriptionClient;
            _mediator = mediator;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriptionClient.RegisterMessageHandler(async (message,token) =>
            {

                string response = Encoding.UTF8.GetString(message.Body);
                var a = message.UserProperties.FirstOrDefault();
                if (a.Value != null && a.Value.ToString() == nameof(HolidaySettingsEntity))
                {
                    var data = JsonConvert.DeserializeObject<HolidaySettings>(response);
                    var d = await _mediator.Send(new UploadHolidaySettingsCommand { settings = data });
                }
                else if (a.Value != null && a.Value.ToString() == nameof(EmployeeHolidayEntity))
                {
                    var data = JsonConvert.DeserializeObject<SaveHolidayCommand>(response);
                    var d = await _mediator.Send(data);
                }
                else if (a.Value != null && a.Value.ToString() == nameof(CompanyToEmployeeHolidayEntity))
                {
                    var holidayData = JsonConvert.DeserializeObject<CompanyToEmployeeHolidays>(response);
                    var data = await _mediator.Send(new SaveCompanyGivenHolidays { companyHolidays = holidayData });
                }

                _ = _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);

            },new MessageHandlerOptions(ExceptionReceivedHandler) { 
                
                AutoComplete = false,
                MaxConcurrentCalls = 1
            });
            return Task.CompletedTask;
        }
        protected Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Exception:: {exceptionReceivedEventArgs.Exception}.");
            return Task.CompletedTask;
        }
    }
}
