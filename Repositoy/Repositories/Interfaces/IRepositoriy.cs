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
        void Update(T data);
        void Delete(T data);
        T Getbyid(int id);

    }
}
