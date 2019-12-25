using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeBianGu.Demo.WebApi.Base
{
    public interface ICustomService
    {
        void Create(CustomEntity entity);
        Task CreateAsync(CustomEntity entity);
        void Remove(string id);
        CustomEntity Get(string id);
        IEnumerable<CustomEntity> GetAll();
        void Update(string id,CustomEntity entity);
    }
}