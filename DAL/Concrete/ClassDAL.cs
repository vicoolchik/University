using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
    public class ClassDAL : IClassDAL
    {
        private readonly IMapper _mapper;
        public ClassDAL(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ClassDTO CreateClass(ClassDTO myclass)
        {
            using (var entites = new universityContext())
            {
                var classInDB = _mapper.Map<Class>(myclass);
                classInDB.ClassId = myclass.ClassId;
                entites.Classes.Add(classInDB);
                entites.SaveChanges();
                return _mapper.Map<ClassDTO>(classInDB);
            }
        }

        public List<ClassDTO> GetAllClasses()
        {
            using (var entities = new universityContext())
            {
                var classes = entities.Classes.Where(x => x.ClassId != 0).ToList();
                return _mapper.Map<List<ClassDTO>>(classes);
            }
        }

        public ClassDTO UpdateClass(ClassDTO myclass)
        {
            using (var entites = new universityContext())
            {
                var classInDB = _mapper.Map<Class>(myclass);
                classInDB = entites.Classes.SingleOrDefault(x => x.ClassId == myclass.ClassId);
                if (classInDB != null)
                {
                   classInDB.ClassId = myclass.ClassId;
                    classInDB.ProfessorId = myclass.ProfessorId;
                    classInDB.SubjectId = myclass.SubjectId;
                    
                    entites.SaveChanges();
                    return _mapper.Map<ClassDTO>(classInDB);
                }
                return null;
            }
        }

        public ClassDTO DeleteClass(ClassDTO myclass)
        {
            using (var entites = new universityContext())
            {
                var classInDB = _mapper.Map<Class>(myclass);
                classInDB = entites.Classes.SingleOrDefault(x => x.ClassId == myclass.ClassId);
                if (classInDB != null)
                {
                    entites.Classes.Remove(classInDB);
                    entites.SaveChanges();
                    return _mapper.Map<ClassDTO>(classInDB);
                }
                return null;
            }
        }

    }
}
