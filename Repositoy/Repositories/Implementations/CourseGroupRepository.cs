using DomainLayer.Entitties;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Implementations
{
    public class CourseGroupRepository : IRepositoriy<CourseGroup>
    {
        public void Create(CourseGroup data)
        {
            try
            {
                if (data is null) throw new NotFoundException("data not found");
                AppDbContext<CourseGroup>.datas.Add(data);

                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(CourseGroup data)
        {
            throw new NotImplementedException();
        }

        public CourseGroup Getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseGroup data)
        {
            throw new NotImplementedException();
        }
        public void GetAllGroupsByTeacher(int age)
        {
            throw new NotImplementedException();
        }
        public void GetAllGroupsByRoom(CourseGroup data)
        {
            throw new NotImplementedException();
        }
        public void GetAllGroups(CourseGroup data)
        {
            throw new NotImplementedException();
        }
    }
}
