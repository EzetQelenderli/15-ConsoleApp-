using CourseApp.Helpers;
using DomainLayer.Entitties;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CourseApp.Controllers
{
    internal class CourseGroupController
    {
        
         private CourseGroupService _courseGroupService = new CourseGroupService();
        private CourseGroupService _courseGroup;
        public CourseGroupController()
        {
            _courseGroup = new CourseGroupService();
        }



        public void Create()
        {
            GroupService _groupService = new GroupService();

            helper.PrintConsole(ConsoleColor.Blue, "Add CourseGroup Name");
            string? courseGroupName = Console.ReadLine();
            helper.PrintConsole(ConsoleColor.Blue, "Add Teacher Name");
            string? courseGroupTeacherName = Console.ReadLine();
            helper.PrintConsole(ConsoleColor.Blue, "Add CourseGroup Room");
        groupRoom: string? courseGroupRoom = Console.ReadLine();
            int groupRoom;
            bool isgroupRoom = int.TryParse(courseGroupRoom, out groupRoom);
            if (isgroupRoom)
            {
                CourseGroup coursegroup = new CourseGroup { Name = courseGroupName, Teacher = courseGroupTeacherName, Room = groupRoom };
                _groupService.Create(coursegroup);
                helper.PrintConsole(ConsoleColor.Green, $"Id:{coursegroup.Id}Name:{coursegroup.Name},Teacher Name:{coursegroup.Teacher},Room:{coursegroup.Room}");
            }
            else
            {


                helper.PrintConsole(ConsoleColor.Red, "Please enter correct groupRoom type!");
                goto groupRoom;
            }

        }
        public void GetById()
        {

        GroupId: helper.PrintConsole(ConsoleColor.Blue, "Ad CourseGroup Id");
            string courseGroupId = Console.ReadLine();
            int id;
            bool isCourseGroupId = int.TryParse(courseGroupId, out id);
            if (isCourseGroupId)
            {

                CourseGroup courseGroup = _courseGroup.GetById(id);

                if (courseGroup != null)
                {
                    helper.PrintConsole(ConsoleColor.Green, $"Id:{courseGroup.Id}Name:{courseGroup.Name},Teacher Name:{courseGroup.Teacher},Room:{courseGroup.Room}");

                }
                else
                {
                    helper.PrintConsole(ConsoleColor.Red, "CourseGroup Not Found!!");
                    goto GroupId;

                }
            }
            else
            {
                helper.PrintConsole(ConsoleColor.Red, "Please enter correct CourseGroupId type!!");
                goto GroupId;

            }
        }
        public void GetAll()
        {
            List<CourseGroup> courseGroups = _courseGroupService.GetAll();

            if (courseGroups.Count != 0)
            {
                foreach (var course in courseGroups)
                {
                    helper.PrintConsole(ConsoleColor.Green, $"Course Id : {course.Id}, Name : {course.Name}, Teacher : {course.Teacher},Room:{course.Room}");
                }
            }
            else
            {
                helper.PrintConsole(ConsoleColor.Red, "Please Create Course!");
            }
        }
        public void Delete()
        {
        groupId: helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");

            string groupId = Console.ReadLine();

            int id;

            bool isLibraryId = int.TryParse(groupId, out id);

            if (isLibraryId)
            {
                CourseGroup courseGroup = _courseGroupService.GetById(id);
                helper.PrintConsole(ConsoleColor.Red, $"{courseGroup.Name}CourseGroup delete succesfully!!");
                if (courseGroup != null)
                {
                    _courseGroupService.Delete(id);
                }
                else
                {
                    helper.PrintConsole(ConsoleColor.Red, "CourseGroup Not Found!!");
                    goto groupId;

                }
            }
            else
            {
                helper.PrintConsole(ConsoleColor.Red, "Add correct LibraryId type");
                goto groupId;
            }

        }
        public void Update()
        {
 
        }
    }
    
}

