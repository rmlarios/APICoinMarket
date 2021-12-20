using APLICATION.Services;
using APLICATION.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly CurrencyService _service;
        public CurrenciesController(CurrencyService service)
        {
            _service = service;
        }

        [HttpGet("List")]
        public async Task<ApiResponse> GetList()
        {
            return await _service.GetCurrencyList();
        }
    }
}
