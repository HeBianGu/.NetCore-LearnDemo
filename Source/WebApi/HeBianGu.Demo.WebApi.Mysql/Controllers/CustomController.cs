using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeBianGu.Demo.WebApi.Mysql.Controllers
{
    [ApiController]
    [Route("/Api/[controller]/[action]")]
    public class CustomController : ControllerBase
    {
        MysqlDbContext _dbContext;

        public CustomController(MysqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

   
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<CustomEntity>> GetAll()
        {
            var entity = _dbContext.CustomEntity;

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
            var entity = _dbContext.CustomEntity.FirstOrDefault(l => l.ID == id);

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
            _dbContext.CustomEntity.Add(entity);

            _dbContext.SaveChanges();

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
            var book = _dbContext.CustomEntity.FirstOrDefault(l=>l.ID==id);

            if (book == null)
            {
                return NotFound();
            }

            book.Name = bookIn.Name;
            book.Age = bookIn.Age;

            _dbContext.CustomEntity.Update(book);

            _dbContext.SaveChanges();

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
            var entity = _dbContext.CustomEntity.FirstOrDefault(l => l.ID == id);

            if (entity == null)
            {
                return NotFound();
            }

            _dbContext.CustomEntity.Remove(entity);

            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}