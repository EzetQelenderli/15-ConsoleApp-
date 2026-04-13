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
            if (data == null) return;
            AppDbContext<Student>.datas.Remove(data);
        }
            
        

        public List<Student> GetAll(Predicate<Student> predicate=null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;

        }

        public Student GetById(Predicate<Student>predicate)
        {
            return predicate != null
              ? AppDbContext<Student>.datas.Find(predicate) : null;
        }

        public void Update(int id,Student data)
        {
            Student? dbStudent =
               AppDbContext<Student>.datas.Find(x => x.Id == id);

            if (dbStudent == null) return;

            if (!string.IsNullOrEmpty(data.Name))
                dbStudent.Name = data.Name;

            if (!string.IsNullOrEmpty(data.Surname))
                dbStudent.Surname = data.Surname;

            if ((data.Age!=null))
                dbStudent.Age = data.Age;

            if (data.Group > 0)
                dbStudent.Group = data.Group;
        }
        
    }
}
