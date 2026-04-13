  using DomainLayer.Entitties;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;


namespace RepositoryLayer.Repositories.Implementations
{
    public class CourseGroupRepository : IRepositoriy<CourseGroup>
    {
        private List<CourseGroup> _data = new();
        private readonly StudentRepository _studentRepository;
        private readonly ICourseGroupService _groupService;
        public void Create(CourseGroup data)
        {
            
            try
            {
                if (data is null) throw new NotFoundException("data not found");
                AppDbContext<CourseGroup>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void Delete(CourseGroup data)
        {
            if (data == null) return;
            AppDbContext<CourseGroup>.datas.Remove(data);
        }

        public CourseGroup GetById(Predicate<CourseGroup>predicate)
        {
            return predicate!=null
                ?AppDbContext<CourseGroup>.datas.Find(predicate):null;
        }

        public void Update(int id,CourseGroup data)
        {

            CourseGroup? dbCourse =
               AppDbContext<CourseGroup>.datas.Find(x => x.Id == id);

            if (dbCourse == null) return;

            if (!string.IsNullOrEmpty(data.Name))
                dbCourse.Name = data.Name;

            if (!string.IsNullOrEmpty(data.Teacher))
                dbCourse.Teacher = data.Teacher;

            if (data.Room > 0)
                dbCourse.Room = data.Room;
        }
        public List<CourseGroup> GetAll(Predicate<CourseGroup>predicate=null)
        {

            return predicate != null ? AppDbContext<CourseGroup>.datas.FindAll(predicate) : AppDbContext<CourseGroup>.datas;


        }

        
    }

    internal interface ICourseGroupService
    {
    }
}