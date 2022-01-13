﻿using Organization.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organization.API.Repositories.Interface
{
    public interface IBusiness
    {
        Task<IEnumerable<Business>> GetAllEmployeeTree(string Id);
        Task<IEnumerable<Business>> GetBusinessByParentBusinessId(string ParentBusinessId);
        Task<IEnumerable<Business>> GetBusinessById(int Id);
        Task<Business> AddBusiness(Business Business);
        Task<Business> UpdateBusiness(Business Business);
        Task<int> DeleteBusiness(int Id);
    }
}
