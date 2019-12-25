using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Demo.WebApi.Base
{
    public class CustomService : ICustomService
    {
        public CustomService()
        {
            for (int i = 0; i < 10; i++)
            {
                _collection.Add(new CustomEntity() { ID = i.ToString(), Name = (i * i).ToString() });
            }
        }
        List<CustomEntity> _collection = new List<CustomEntity>();

        public void Create(CustomEntity entity)
        {
            _collection.Add(entity);
        }


        public async Task CreateAsync(CustomEntity entity)
        {
            await Task.Delay(3000);

            _collection.Add(entity);
        }

        public void Remove(string id)
        {
            _collection.Remove(this.Get(id));
        }

        public CustomEntity Get(string id)
        {
            return _collection.Find(l => l.ID == id);
        }

        public IEnumerable<CustomEntity> GetAll()
        {
            return _collection;
        }

        public void Update(string id, CustomEntity entity)
        {
            var value = _collection.Find(l => l.ID == id);

            value.ID = entity.ID;
            value.Name = entity.Name;
        }
    }
}
