using BenchmarkDotNet.Attributes;
using ConsumerBrasil.Application.Interfaces;
using ConsumerBrasil.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerBrasil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrasilApi : ControllerBase
    {
        private readonly IBrasilAPI _brasilApi;
        public BrasilApi(IBrasilAPI brasilAPI)
        {
            _brasilApi = brasilAPI;
        }
        
        [ProducesResponseType(typeof(IActionResult), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _brasilApi.GetAllBancos();
            return Ok(response);
        }

        [ProducesResponseType(typeof(IActionResult), 200)]
        [HttpGet("cache")]
        public async Task<IActionResult> GetAllCache()
        {
            var response = await _brasilApi.GetBancosCache();
            return Ok(response);
        }
    }
}
