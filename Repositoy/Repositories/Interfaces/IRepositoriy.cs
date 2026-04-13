using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IRepositoriy<T>
    {
        void Create(T data);
        void Update(int id,T data);
        void Delete(T data);
        T ?GetById(Predicate<T>predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}
