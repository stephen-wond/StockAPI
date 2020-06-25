using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StocksWebAPI.Services;
using Telegram.Bot.Types;

namespace StocksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private readonly IUpdateService _updateService;

        public TelegramController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            try
            {
                await _updateService.EchoAsync(update);
            }
            catch
            {
                Console.WriteLine("broke");
            }
            return Ok();

        }
    }
}