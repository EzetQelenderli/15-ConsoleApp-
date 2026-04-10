using DomainLayer.Entitties;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private StudentRepository studentRepository;
        private int _count = 1;
        public Student Create(Student student, int groupId)
        {
           
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetByAge(int age)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchByNameOrSurname(string text)
        {
            throw new NotImplementedException();
        }

        public Student Update(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
