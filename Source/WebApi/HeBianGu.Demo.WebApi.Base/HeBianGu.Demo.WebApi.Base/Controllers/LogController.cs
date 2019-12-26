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
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger = null;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 写运行日志
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RunLog(string messsage)
        {
            _logger.LogInformation(messsage);

            return Ok(messsage);
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ErrorLog(string messsage)
        {
            _logger.LogError(messsage);

            return Ok(messsage);
        }
    }
}