using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base 
    {
        Task<T> Create(T obj);
        Task<T> Upadate(T obj);
        Task Remove(long id);
        Task<T> Get(long id);
        Task<List<T>> Get();

    }
}
