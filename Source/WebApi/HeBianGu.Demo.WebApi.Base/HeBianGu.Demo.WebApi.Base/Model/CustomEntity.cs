using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Demo.WebApi.Base
{
    public class CustomEntity
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

    }
}
