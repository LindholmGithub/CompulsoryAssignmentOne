using System.Collections.Generic;

namespace PetShop.Infrastructure.Security.SecurityInterfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
    }
}