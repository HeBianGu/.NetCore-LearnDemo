using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Demo.WebApi.Mysql
{
    public class CustomEntity
    {
        [Key]
        public string ID { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Age { get; set; }

    }
}
