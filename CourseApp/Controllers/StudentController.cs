using CourseApp.Helpers;
using DomainLayer.Entitties;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CourseApp.Controllers
{
    internal class StudentController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void CreateStudent(StudentService studentService)
        {

            Helper.PrintConsole(ConsoleColor.Cyan, "=== Create New Student ===");

            Console.Write("Enter student name: ");
            string name = Helper.ReadValidatedString("Name is not valid. Enter again:");

            Console.Write("Enter student surname: ");
            string surname = Helper.ReadValidatedString("Surname is not valid. Enter again:");

            int age;
            while (true)
            {
                Console.Write("Enter student age: ");
                age = Helper.ReadValidatedInt("Age must be a valid number. Enter again:");
                if (age >= 8 && age <= 70)
                    break;
                Helper.PrintConsole(ConsoleColor.Red, "Age must be between 8 and 70. Enter again:");
            }

            Console.Write("Enter group ID: ");
            int groupId = Helper.ReadValidatedInt("Group ID must be a valid number. Enter again:");

            try
            {
                studentService.Create(new Student { Name = name, Surname = surname, Age = age }, groupId);
                ;
                Helper.PrintConsole(ConsoleColor.Green, "Student created successfully!");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }

        public void UpdateStudent(StudentService studentService)
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "=== Update Student ===");

            Student existingStudent = null;
            int id;

            while (true)
            {
                Console.Write("Enter student ID to update (or type 'Exit' to go back): ");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) || input.Equals("e", StringComparison.OrdinalIgnoreCase))
                    return;

                if (int.TryParse(input, out id))
                {
                    try
                    {
                        existingStudent = studentService.GetById(x=>x.Id==id);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "ID must be a valid number. Try again:");
                }
            }

            Console.WriteLine($"Current Name: {existingStudent.Name}");
            Console.Write("Enter new student name (leave empty to keep current): ");
            string newName = Helper.ReadValidatedUpdateString(existingStudent.Name, "Name is not valid. Enter again:");

            Console.WriteLine($"Current Surname: {existingStudent.Surname}");
            Console.Write("Enter new student surname (leave empty to keep current): ");
            string newSurname = Helper.ReadValidatedUpdateString(existingStudent.Surname, "Surname is not valid. Enter again:");

            int newAge;
            while (true)
            {
                Console.WriteLine($"Current Age: {existingStudent.Age}");
                Console.Write("Enter new student age (leave empty to keep current): ");
                string ageInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ageInput))
                {
                    newAge = existingStudent.Age;
                    break;
                }

                if (int.TryParse(ageInput, out newAge) && newAge >= 8 && newAge <= 70)
                    break;

                Helper.PrintConsole(ConsoleColor.Red, "Age must be a number between 8 and 70. Enter again:");
            }

            try
            {
                studentService.Update(id, new Student
                {
                    Name = newName,
                    Surname = newSurname,
                    Age = newAge
                });
                Helper.PrintConsole(ConsoleColor.Green, "Student updated successfully!");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }


        public void DeleteStudent(StudentService studentService)
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "=== Delete Student ===");
            Console.Write("Enter student ID to delete: ");
            int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

            try
            {
                studentService.Delete(id);
                Helper.PrintConsole(ConsoleColor.Green, "Student deleted successfully!");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }

        public void GetStudentById(StudentService studentService)
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "=== View Student Details ===");
            Console.Write("Enter student ID: ");
            int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

            try
            {
                var student = studentService.GetById(x=>x.Id==id);
                Helper.PrintConsole(ConsoleColor.Green, $"ID: {student.Id} | Name: {student.Name} {student.Surname} | Age: {student.Age} | Group: {student.Group}");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }

        public void GetAllStudents(StudentService studentService)
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "=== List All Students ===");

            try
            {
                var list = studentService.GetAll();
                foreach (var s in list)
                    Helper.PrintConsole(ConsoleColor.Green, $"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age} | Group: {s.Group}");
            }
            catch (Exception ex)
            {
                            }
        }

        public void GetStudentsByAge(StudentService studentService)
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "=== List Students by Age ===");
            Console.Write("Enter age: ");
            int age = Helper.ReadValidatedInt("Age must be a valid number. Enter again:");

            try
            {
                var list = studentService.GetByAge( age);
                foreach (var s in list)
                    Helper.PrintConsole(ConsoleColor.Green, $"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age}");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }

        public void GetStudentsByGroup(StudentService studentService)
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "=== List Students by Group ===");
            Console.Write("Enter group ID: ");
            int groupId = Helper.ReadValidatedInt("Group ID must be a valid number. Enter again:");

            try
            {
                var list = studentService.GetByGroupId(groupId);
                foreach (var s in list)
                    Helper.PrintConsole(ConsoleColor.Green, $"ID: {s.Id} | Name: {s.Name} {s.Surname}");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }

        public void SearchStudents(StudentService studentService)
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "=== Search Students ===");
            Console.Write("Enter keyword (name or surname): ");
            string keyword = Console.ReadLine();

            try
            {
                var list = studentService.SearchByNameOrSurname(keyword);
                foreach (var s in list)
                    Helper.PrintConsole(ConsoleColor.Green, $"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age}");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
    }
}

