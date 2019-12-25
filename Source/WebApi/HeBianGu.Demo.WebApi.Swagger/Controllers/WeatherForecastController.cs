using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeBianGu.Demo.WebApi.Swagger.Controllers
{
    [ApiController]
    [Route("/Api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
       /// <summary>
       /// 获取数据
       /// </summary>
       /// <param name="id">主键ID</param>
       /// <returns> 返回数据 </returns>
        [HttpGet("{id}")]
        public WeatherForecast GetByID(string id)
        {
            var rng = new Random();

            WeatherForecast result = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = rng.Next(-20, 55),
                Summary = id
            };

            return result;
        }

        /// <summary>
        /// 获取Summary
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        [HttpPost]
        public string GetSummary([FromBody]WeatherForecast model)
        {
            return model.Summary;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public IActionResult DeleteByID(string id)
        {
            return this.Ok("删除成功!" + id);
        }
    }
}
