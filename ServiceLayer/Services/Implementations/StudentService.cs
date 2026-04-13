using DomainLayer.Entitties;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{

    public class StudentService : IStudentService
    {
        private readonly IGroupService _groupService;
        private StudentRepository _studentRepository;
        private int _count = 1;
        public Student Create(Student student, int groupId)
        {
            var group = _groupService.GetById(groupId);
            if (group == null)
                throw new NotFoundException("There is no group with given ID! Create a new group!");

            if (student == null)
                throw new ArgumentNullException("Student cannot be null!");

            student.courseGroup = group;
            _studentRepository.Create(student);
            return student;
        }

        

        public void Delete(int id)
        {
            if (id < 0)
                throw new ArgumentNegativeException("Id has to be positive numbers!");
            var existingStudent = _studentRepository.GetById(x=>x.Id==id);
            if (existingStudent == null)
                throw new NotFoundException("Student is not found!");

            _studentRepository.Delete(existingStudent);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public List<Student> GetByAge(int age)
        {
            if (age< 0)
                throw new ArgumentNegativeException("Group ID has to be positive numbers!");

            var students = _studentRepository.GetAll(students => students != null && students.Age == age);
            if (!students.Any())
                throw new EmptyListException("No students found in the given age.");

            return students;
        }

        public List<Student> GetByGroupId(int groupId)
        {
            if (groupId < 0)
                throw new ArgumentNegativeException("Group ID has to be positive numbers!");

            var students = _studentRepository.GetAll(students=>students!=null&& students.courseGroup.Id==groupId);
            if (!students.Any())
                throw new EmptyListException("No students found in the given group.");

            return students;
        }

        public Student GetById(Predicate<Student> predicate)
        {
            var student = _studentRepository.GetById(predicate);
            if (student == null)
                throw new NotFoundException("There is no student with given ID!");

            return student; ;
        }

        public List<Student> SearchByNameOrSurname(string text)
        {
            var students = _studentRepository.GetAll(s =>
              s != null &&
              (s.Name.Contains(text, StringComparison.OrdinalIgnoreCase) ||
               s.Surname.Contains(text, StringComparison.OrdinalIgnoreCase)));

            if (!students.Any())
                throw new EmptyListException("No students found with the given keyword.");

            return students;
        }

        public Student Update(int id, Student data)
        {
            if (id < 0)
                throw new ArgumentNegativeException("Id has to be positive numbers!");
            if (data == null)
                throw new ArgumentNullException("Student cannot be null!");

            var existingStudent = _studentRepository.GetById(x=>x.Id==id);
            if (existingStudent == null)
                throw new NotFoundException("Student not found!");

            if (!string.IsNullOrWhiteSpace(data.Name))
                existingStudent.Name = data.Name;

            if (!string.IsNullOrWhiteSpace(data.Surname))
                existingStudent.Surname = data.Surname;

            if (data.Age > 0)
                existingStudent.Age = data.Age;

            if (data.courseGroup != null)
            {
                var group = _groupService.GetById(data.courseGroup.Id);
                if (group == null)
                    throw new NotFoundException("The provided CourseGroup does not exist!");

                existingStudent.courseGroup = group;
            }

            _studentRepository.Update(id, existingStudent);
            return existingStudent;
        }
    }
}
