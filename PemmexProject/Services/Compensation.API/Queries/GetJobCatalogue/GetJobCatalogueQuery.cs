﻿using AutoMapper;
using Compensation.API.Database.context;
using Compensation.API.Database.Entities;
using Compensation.API.Dtos;
using Compensation.API.Enumerations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Organization.API.Queries.GetJobCatalogue
{
    public class GetJobCatalogueQuery : IRequest<JobCatalogueDto>
    {
        public string organizationIdentifier { get; set; }
        public JobFunctions jobFunction { get; set; }
        public string grade { get; set; }
    }

    public class GetJobCatalogueQueryHandeler : IRequestHandler<GetJobCatalogueQuery, JobCatalogueDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetJobCatalogueQueryHandeler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<JobCatalogueDto> Handle(GetJobCatalogueQuery request, CancellationToken cancellationToken)
        {
            var p = request.jobFunction.ToString();
            var employee = await _context.JobCatalogues
                .Where(e => e.jobFunction == request.jobFunction.ToString() 
                && e.organizationIdentifier == request.organizationIdentifier
                && e.grade == request.grade
                )
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<JobCatalogue, JobCatalogueDto>(employee);
        }
    }
}
