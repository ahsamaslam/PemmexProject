﻿using MediatR;
using Notifications.API.NotificationHub;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notifications.API.Commands.MarkNotification
{
    public class MarkNotificationCommand : IRequest
    {
        public string userId { get; set; }
    }

    public class MarkNotificationCommandHandeler : IRequestHandler<MarkNotificationCommand>
    {
        private readonly INotificationRepository _context;
        public MarkNotificationCommandHandeler(INotificationRepository context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(MarkNotificationCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _context.UpdateNotificationToRead(request.userId);
                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
