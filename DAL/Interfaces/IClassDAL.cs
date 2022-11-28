using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IClassDAL
    {
        List<ClassDTO> GetAllClasses();
        ClassDTO CreateClass(ClassDTO myclass);
        ClassDTO UpdateClass(ClassDTO myclass);
        ClassDTO DeleteClass(ClassDTO myclass);
    }
}
