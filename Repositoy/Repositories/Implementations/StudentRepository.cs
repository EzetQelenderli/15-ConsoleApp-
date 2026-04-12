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
    public class StudentRepository : IRepositoriy<Student>
    {
        public void Create(Student data)
        {

            try
            {
                if (data is null) throw new NotFoundException("Student Not Found");

                AppDbContext<Student>.datas.Add(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            throw new NotImplementedException();
        }

        public Student GetById(Predicate<Student>predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Student data,int id)
        {
            throw new NotImplementedException();
        }
        public void GetStudentById(Student data)
        {
            throw new NotImplementedException();
        }
        public void DeleteStudent(Student data)
        {
            throw new NotImplementedException();
        }
        public void GetStudentsByAge(Student data)
        {
            throw new NotImplementedException();
        }
        public void GetAllStudentsByGroupId(Student data)
        {
            throw new NotImplementedException();
        }
        public void SearchMethodForGroupsByName(Student data)
        {
            throw new NotImplementedException();
        } 
        public void SearchMethodForStudentsByNameOrSurname(Student data)
        {
            throw new NotImplementedException();
        } 

    }
}
