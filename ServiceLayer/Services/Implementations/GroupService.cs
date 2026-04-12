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
        private CourseGroupRepository _groupRepository= new CourseGroupRepository();
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
            CourseGroup courseGroup=GetById(x=>x.Id==id);
            _groupRepository.Delete(courseGroup);
        }

        public List<CourseGroup> GetAll()
        {
            return _groupRepository.GetAll(i=>i.Id>0);
        }

        public List<CourseGroup> GetAllByRoomn(string room)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByTeacher(string teacher)
        {
            throw new NotImplementedException();
        }

        public CourseGroup GetById(Predicate<CourseGroup>predicate)
        {
           return   _groupRepository.GetById( predicate);
        }

        public List<CourseGroup> SearchByName(string room)
        {
            throw new NotImplementedException();
        }

        public CourseGroup Update(CourseGroup group,int id)
        {
            //var existGroup = _groupRepository.GetAll(x => x.Id == group.Id);

            CourseGroup dbcourse= GetById(x=>x.Id==group.Id);

            if (dbcourse is null) return null;

            group.Id = id;

            _groupRepository.Update(group,id);

            return GetById(x=>x.Id==id);



        }
    }
}
