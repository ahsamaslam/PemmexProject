﻿using Holidays.API.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidays.API.Repositories.Interface
{
    public interface IHolidaySettings
    {
        Task<IEnumerable<HolidaySettings>> GetHolidaySettings();
        Task<IEnumerable<HolidaySettings>> GetHolidaySettingsById(int Id);
        Task<HolidaySettings> AddHolidaySettings(HolidaySettings HolidaySettings);
        Task<HolidaySettings> UpdateHolidaySettings(HolidaySettings HolidaySettings);
        Task<int> DeleteHolidaySettings(int Id);
    }
}