using DomainLayer.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {
        CourseGroup Create(CourseGroup group);
        CourseGroup Update(CourseGroup group,int id);
        void Delete(int id);
        CourseGroup GetById(Predicate<CourseGroup>predicate);
        List<CourseGroup> GetAll();
        List<CourseGroup> GetAllByTeacher(string teacher);
        List<CourseGroup> GetAllByRoomn(string room);
        List<CourseGroup> SearchByName(string room);
    }
}
