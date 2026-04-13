using DomainLayer.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IStudentService
    {

        Student Create( Student student,int groupId);
        Student Update(int id, Student student);
        void Delete(int id);
        Student GetById(Predicate<Student> predicate);
        List<Student> GetAll();
        List<Student> GetByAge(int age);
        List<Student> GetByGroupId(int groupId);
        List<Student> SearchByNameOrSurname(string text);


    }
}
