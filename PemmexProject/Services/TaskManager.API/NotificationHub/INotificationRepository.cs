﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager.API.NotificationHub
{
    public interface INotificationRepository
    {
        Task<int> SaveNotification(Database.Entities.Notifications notifications, 
            CancellationToken cancellationToken);
        Task<List<Database.Entities.Notifications>> GetAllNotification(string EmployeeId);
        Task<int> CountUnReadNotifications(string EmployeeId);
        Task<int> AddNotifications(Database.Entities.Notifications notifications);
        Task UpdateNotificationToRead(string EmployeeId);
    }
}
