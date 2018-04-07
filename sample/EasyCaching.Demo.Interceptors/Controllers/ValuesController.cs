﻿namespace EasyCaching.Demo.Interceptors.Controllers
{
    using EasyCaching.Demo.Interceptors.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IAspectCoreService _aService;
        private readonly ICastleService _cService;

        public ValuesController(IAspectCoreService aService, ICastleService cService)
        {
            this._aService = aService;
            this._cService = cService;
        }

        [HttpGet]
        [Route("aspectcore")]
        public string Aspectcore(int type = 1)
        {
            if (type == 1)
            {
                return _aService.GetCurrentUtcTime();
            }
            else if (type == 2)
            {
                _aService.DeleteSomething(1);
                return "ok";
            }
            else if (type == 3)
            {
                return _aService.PutSomething("123");
            }
            else
            {
                return "wait";
            }
        }

        [HttpGet]
        [Route("aspectcoreasync")]
        public async Task<string> AspectcoreAsync(int type = 1)
        {
            if (type == 1)
            {
                return await _aService.GetUtcTimeAsync();
            }
            else
            {
                return await Task.FromResult<string>("wait");
            }
        }

        [HttpGet]
        [Route("castle")]
        public string Castle(int type = 1)
        {
            if (type == 1)
            {
                return _cService.GetCurrentUtcTime();
            }
            else if (type == 2)
            {
                _cService.DeleteSomething(1);
                return "ok";
            }
            else if (type == 3)
            {
                return _cService.PutSomething("123");
            }
            else
            {
                return "wait";
            }
        }

        [HttpGet]
        [Route("castleasync")]
        public async Task<string> CastleAsync(int type = 1)
        {
            if (type == 1)
            {
                return await _cService.GetUtcTimeAsync();
            }
            else
            {
                return await Task.FromResult<string>("wait");
            }
        }
    }
}
