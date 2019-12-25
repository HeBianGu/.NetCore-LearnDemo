using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeBianGu.Demo.WebApi.Base.Controllers
{
    [ApiController]
    [Route("/Api/[controller]/[action]")]
    public class CustomController : ControllerBase
    {
        ICustomService _service;

        public CustomController(ICustomService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<CustomEntity>> GetAll()
        {
            var entity = _service.GetAll();

            if (entity == null)
            {
                return NotFound();
            }

            //  Message：C# 不支持对接口使用隐式强制转换运算符。 因此，必须使用 ActionResult<T>，才能将接口转换为具体类型。 例如，在下面的示例中，使用 IEnumerable 不起作用：
            return entity.ToList();
        }

        /// <summary>
        /// 获取指定项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<CustomEntity> Get(string id)
        {
            var entity = _service.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CustomEntity> Create(CustomEntity entity)
        {
            _service.Create(entity);

            //  Do ：跳转到Get
            return CreatedAtRoute("Get", new { id = entity.ID.ToString() }, entity);
        }

        /// <summary>
        /// 修改实例
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookIn"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(string id, CustomEntity bookIn)
        {
            var book = _service.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _service.Update(id, bookIn);

            return NoContent();
        }

        /// <summary>
        /// 删除实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _service.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            _service.Remove(entity.ID);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomEntity> GetById(string id)
        {
            var from = _service.Get(id);

            if (from == null)
            {
                return NotFound();
            }
            return from;
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CustomEntity>> GetByIdAsync(string id)
        //{
        //    var from = _service.Get(id);

        //    await Task.Delay(3000);

        //    if (from == null)
        //    {
        //        return NotFound();
        //    }

        //    return from;
        //}

        /// <summary>
        /// 限制返回格式
        /// </summary>
        /// <remarks>
        /// /api/GetFormat/5	默认输出格式化程序
        /// /api/GetFormat/5.json JSON 格式化程序（如配置）
        /// /api/GetFormat/5.xml XML 格式化程序（如配置）
        /// </remarks>
        /// <param name="id"> 5 /5.json /5.xml </param>
        /// <returns></returns>
        [HttpGet("{id}.{format?}")]
        public ActionResult<CustomEntity> GetFormat(string id)
        {
            var from = _service.Get(id);

            if (from == null)
            {
                return NotFound();
            }
            return from;
        }
    }
}