using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeBianGu.Demo.WebApi.Base.Controllers
{
    [ApiController]
    [Route("/Api/[controller]/[action]")]
    public class WeatherForecastController : ApiControllerBase
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
        /// Get的默认方式
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
        /// Get的传递参数
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public WeatherForecast GetByID(string id)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                ID = id,
                Name = string.Empty
            };
        }

        /// <summary>
        /// Get的传递多个参数
        /// </summary>
        /// <returns></returns>
        [HttpGet("{name}/{id}")]
        public WeatherForecast GetByID(string id,string name)
        {
            var rng = new Random();

            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                ID = id,
                Name = name
            };
        }

        /// <summary>
        /// Post传递Body
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        [HttpPost]
        public WeatherForecast GetSummary([FromBody]WeatherForecast model)
        {
            return model;
        }

        /// <summary>
        /// Post传递参数
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteByID(string id)
        {
            return this.Ok("删除成功!" + id);
        }

        /// <summary>
        /// Post传递多个参数
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBy(string id,string name)
        {
            return this.Ok($"添加成功!ID:{id}- Name:{name}");
        }


        /// <summary>
        /// Post传递多个参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ApiResult> GetResult()
        {
            ApiResult result = new ApiResult();

            result.ErrorCode = 1;

            result.Msg = "请求成功！";

            return result;
        }




    }
}
