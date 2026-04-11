using CourseApp.Helpers;
using DomainLayer.Entitties;
using ServiceLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Controllers
{
    internal class CourseGroupController
    {
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
    }
}
