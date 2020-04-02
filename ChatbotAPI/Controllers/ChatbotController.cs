using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeechToText;

namespace ChatbotAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GetSpeechToText([FromBody] GetModel getModel)
        {
            var bytes = getModel.Bytes;
            var command = new SpeechToTextConverter().ConvertSpeechToText(bytes);
            // var command = " can you close the fridge please?";
            var result = CommandHandler.GetCommand(command).Execute();
            return Ok(result);
        }

    }
}
