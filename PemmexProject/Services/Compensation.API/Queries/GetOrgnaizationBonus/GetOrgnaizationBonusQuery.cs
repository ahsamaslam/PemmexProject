﻿using AutoMapper;
using Compensation.API.Database.context;
using Compensation.API.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Compensation.API.Queries.GetOrgnaizationBonus
{
    public class GetOrgnaizationBonusQuery : IRequest<List<UserBonus>>
    {
        public string organizationIdentifiers { get; set; }
    }

    public class GetOrgnaizationBonusQueryHandeler : IRequestHandler<GetOrgnaizationBonusQuery, List<UserBonus>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrgnaizationBonusQueryHandeler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserBonus>> Handle(GetOrgnaizationBonusQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<UserBonus> userBonuses = new List<UserBonus>();
                var salary = await _context.CompensationSalaries
                    .Where(e => e.organizationIdentifier == request.organizationIdentifiers)
                    .GroupBy(c => c.EmployeeIdentifier)
                    .Select(cl => new UserBonus
                    {
                        EmployeeIdentifier = cl.First().EmployeeIdentifier,
                        bonusAmount = cl.Sum(c => c.one_time_bonus),
                    })
                    .ToListAsync(cancellationToken);

                return userBonuses;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
