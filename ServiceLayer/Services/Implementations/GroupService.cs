using DomainLayer.Entitties;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class GroupService : IGroupService
    {

        private CourseGroupRepository _groupRepository;
        private int _count=1;
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
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByRoomn(string room)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByTeacher(string teacher)
        {
            throw new NotImplementedException();
        }

        public CourseGroup GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> SearchByName(string room)
        {
            throw new NotImplementedException();
        }

        public CourseGroup Update(CourseGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
