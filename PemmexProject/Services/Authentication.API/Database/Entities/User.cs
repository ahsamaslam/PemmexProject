﻿using PemmexCommonLibs.Domain.Common;
using PemmexCommonLibs.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.API.Database.Entities
{
    public class User : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string EmployeeIdentifier { get; set; }
        public string ManagerIdentifier { get; set; }
        public string ManagerName { get; set; }
        public string CostCenterIdentifier { get; set; }
        public string BusinessIdentifier { get; set; }
        public string OrganizationIdentifier { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public bool IsPasswordReset { get; set; }
        public bool IsTwoStepAuthEnabled { get; set; }
        public string PasswordResetCode { get; set; }
        public DateTime PasswordResetCodeTime { get; set; }
        public bool isActive { get; set; }
        public JobFunction JobFunction { get; set; }
        public string Grade { get; set; }
        public string OrganizationCountry { get; set; }
    }
    
}
