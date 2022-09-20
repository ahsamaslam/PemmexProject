﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PemmexCommonLibs.Domain.Common.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Compensation.API.Controllers
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
