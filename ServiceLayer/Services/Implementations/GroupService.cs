using DomainLayer.Common;
using DomainLayer.Entitties;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServiceLayer.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private CourseGroupRepository _groupRepository = new CourseGroupRepository();
        private int _count = 1;
        public GroupService()
        {
            _groupRepository = new CourseGroupRepository();
        }
        public CourseGroup Create(CourseGroup group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;

        }

        public void Delete(int id)
        {
            CourseGroup courseGroup = _groupRepository.GetById(x => x.Id == id);
            //if (courseGroup==null)
            //{
            //    return;
            //}
            _groupRepository.Delete(courseGroup);
        }

        public List<CourseGroup> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public List<CourseGroup> GetAllByRoom(string room)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByRoomn(string room)
        {
            var groups = _groupRepository.GetAll(cg =>
              cg != null &&
              !string.IsNullOrWhiteSpace(room) &&
              room.Contains(room, StringComparison.OrdinalIgnoreCase));



            return groups;
        }

        public List<CourseGroup> GetAllByTeacherName(string teacherName)
        {
            var groups = _groupRepository.GetAll(cg =>
             cg != null &&
             !string.IsNullOrWhiteSpace(teacherName) &&
             teacherName.Contains(teacherName, StringComparison.OrdinalIgnoreCase));

            if (groups.Count == 0)
                throw new EmptyListException("No course groups found with the given teacher name.");

            return groups;
        }

        public CourseGroup GetById(int id)
        {
            if (id < 0)
                throw new ArgumentNegativeException("Id has to be positive numbers!");

            var group = _groupRepository.GetById(x => x.Id == id);
            if (group == null)
                throw new NotFoundException("Course group not found!");

            return group;
        }

        public List<CourseGroup> Search(string name)
        {
            return _groupRepository.GetAll(c => c.Name == name);
        }

        public List<CourseGroup> SearchByName(string name)
        {
            var groups = _groupRepository.GetAll(cg =>
                 cg != null &&
                 !string.IsNullOrWhiteSpace(cg.Name) &&
                 cg.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            //if (groups.Count == 0)
            //    throw new EmptyListException("No groups found with the given keyword.");

            return groups;
        }

        public CourseGroup Update(CourseGroup group, int id)
        {
            if (id < 0)
                throw new ArgumentNegativeException("Id has to be positive numbers!");
            if (group is null)
                throw new ArgumentNullException("Course group cannot be null!");

            var existingGroup = _groupRepository.GetById(x => x.Id == id);
            if (existingGroup == null)
                throw new NotFoundException("Course group not found!");

            if (!string.IsNullOrWhiteSpace(group.Name))
            {
                bool nameExists = _groupRepository.GetAll()
                    .Any(g => g.Id != id && g.Name.Equals(group.Name, StringComparison.OrdinalIgnoreCase));



                existingGroup.Name = group.Name;


            }
            return existingGroup;


        }
    }
}