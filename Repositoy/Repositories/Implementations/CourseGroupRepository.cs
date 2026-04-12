using DomainLayer.Entitties;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            AppDbContext<CourseGroup>.datas.Remove(data);
        }

        public CourseGroup GetById(Predicate<CourseGroup>predicate)
        {
            return AppDbContext<CourseGroup>.datas.Find(predicate);
        }

        public void Update(CourseGroup data,int id)
        {

            CourseGroup dbcourse = GetById(l => l.Id == data.Id);

            if (dbcourse == null) return;

            if (!string.IsNullOrEmpty(data.Name))
            {
                dbcourse.Name = data.Name;
            }

            if (data.Room > 0)
            {
                dbcourse.Room = data.Room;
            }
        }
        public List<CourseGroup> GetAll(Predicate<CourseGroup>predicate)
        {
            return predicate!=null?AppDbContext<CourseGroup>.datas.FindAll(predicate):null;
        }
    }
}