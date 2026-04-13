using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    internal enum Student
    {
        Create = 1,
        Delete = 2,
        Update = 3,
        GetById = 4,
        GetAll = 5,
        GetAllByAge = 6,
        GetAllByGroupId = 7,
        SearchByNameOrSurname = 8,
        Exit = 0
    }
}
