using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    internal enum CourseGroup
    {
        Create = 1,
        Update = 2,
        Delete = 3,
        GetById = 4,
        GetAll = 5,
        GetAllByTeacherName = 6,
        GetAllByRoom = 7,
        SearchByName = 8,
        Exit = 0
    }
}
