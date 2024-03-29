﻿using PemmexCommonLibs.Domain.Common;
using PemmexCommonLibs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compensation.API.Database.Entities
{
    public class OrganizationBudget:AuditableEntity
    {
        public int OrganizationBudgetId { get; set; }
        public string organizationIdentifier { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string businessIdentifier { get; set; }
        public double budgetPercentage { get; set; }
        public double budgetValue { get; set; }
        public double compulsoryPercentage { get; set; }
        public double TotalbudgetPercentage { get; set; }
        public double TotalbudgetValue { get; set; }
        public JobFunction jobFunction { get; set; }
        public double euro_rate { get; set; }
    }
}
