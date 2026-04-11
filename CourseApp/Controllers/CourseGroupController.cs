using CourseApp.Helpers;
using DomainLayer.Entitties;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Controllers
{
    internal class CourseGroupController
    {
        private CourseGroup _courseGroup;



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
            bool isCourseGroupId= int.TryParse(courseGroupId, out id);
            if (isCourseGroupId)
            {

            CourseGroup courseGroup =_courseGroup.GetById(id);
                
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
    }
}
