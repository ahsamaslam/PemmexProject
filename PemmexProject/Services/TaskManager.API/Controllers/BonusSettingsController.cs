﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PemmexCommonLibs.Application.Helpers;
using PemmexCommonLibs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.API.Commands.DeleteBonusSetting;
using TaskManager.API.Commands.SaveBonusSetting;
using TaskManager.API.Queries.GetBonusSetting;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusSettingsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> Get(string businessIdentifer)
        {
            try
            {
                var data = await Mediator.Send(new GetBonusSettingQuery { businessIdentifier = businessIdentifer });
                return new ResponseMessage(true, EResponse.OK, null, data);
            }
            catch (Exception e)
            {
                return new ResponseMessage(false, EResponse.UnexpectedError, e.Message, null);
            }
        }
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> Post(SaveBonusSettingCommand setting)
        {
            try
            {
                var data = await Mediator.Send(setting);
                return new ResponseMessage(true, EResponse.OK, null, data);
            }
            catch (Exception e)
            {
                return new ResponseMessage(false, EResponse.UnexpectedError, e.Message, null);
            }
        }
        [HttpDelete]

        public async Task<ActionResult<ResponseMessage>> Delete(string businessIdentifer)
        {
            try
            {
                var data = await Mediator.Send(new DeleteBonusSettingCommand { businessIdentifier = businessIdentifer });
                return new ResponseMessage(true, EResponse.OK, null, data);
            }
            catch (Exception e)
            {
                return new ResponseMessage(false, EResponse.UnexpectedError, e.Message, null);
            }
        }
    }
}
