﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Organization.API.Database.Context;
using Organization.API.Database.Entities;
using Organization.API.Dtos;

namespace Organization.API.Queries.GetManagersQuery
{
    public class GetManagersQuery : IRequest<List<EmployeeResponse>>
    {
        public string Id { get; set; }
    }
    public class GetManagersQueryHandler : IRequestHandler<GetManagersQuery, List<EmployeeResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetManagersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeResponse>> Handle(GetManagersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _context.Employees
                .Where(e => e.IsActive == true && e.Businesses.ParentBusinessId == request.Id)
                .Select(e => e.ManagerIdentifier)
                .Distinct()
                .ToListAsync(cancellationToken);

                var e = await _context.Employees
                    .Include(e => e.CostCenter)
                    .Where(x => list.Contains(x.EmployeeIdentifier))
                    .ToListAsync(cancellationToken);

                return _mapper.Map<List<Employee>, List<EmployeeResponse>>(e);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
