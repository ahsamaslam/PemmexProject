﻿using PemmexCommonLibs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organization.API.Database.Entities
{
    public class sp_GetBusinessUnitsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BUnitIdentifier { get; set; }
        public string Title { get; set; }
        public string EmployeeIdentifier { get; set; }
        public string ManagerIdentifier { get; set; }
        public string businessIdentifier { get; set; }
        public string CostCenterName { get; set; }
        public bool isBunit { get; set; }
        public string Grade { get; set; }
        public JobFunction JobFunction { get; set; }

    }
}
