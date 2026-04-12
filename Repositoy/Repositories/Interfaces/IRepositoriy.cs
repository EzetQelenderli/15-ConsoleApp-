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
        void Update(T data,int id);
        void Delete(T data);
        T GetById(Predicate<T>predicate);

    }
}
