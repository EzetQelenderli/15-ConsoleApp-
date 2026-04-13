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
        CourseGroup Update( int id,CourseGroup group);
        void Delete(int id);
        CourseGroup GetById(int id);
        List<CourseGroup> GetAll();
        List<CourseGroup> GetAllByTeacherName(string teacherName);
        List<CourseGroup> GetAllByRoom(string room);
        List<CourseGroup> SearchByName(string name);
    }
}
