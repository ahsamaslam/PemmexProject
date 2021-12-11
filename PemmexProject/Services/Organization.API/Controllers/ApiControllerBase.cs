﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PemmexCommonLibs.Domain.Common.Dtos;
using Newtonsoft.Json;
using System.Linq;

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
        protected UserEntity CurrentUser => JsonConvert.DeserializeObject<UserEntity>(HttpContext.User.Claims.First(claim => claim.Type == "UserObject").Value);
    }
}