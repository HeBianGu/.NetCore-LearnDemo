using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Demo.WebApi.Base
{
    public class ApiControllerBase : ControllerBase
    {
        protected JsonResult JsonContent(object value)
        {
           return new JsonResult(value);
        }

    }
}
