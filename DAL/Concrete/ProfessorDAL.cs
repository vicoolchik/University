using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
    public class ProfessorDAL : IProfessorDAL
    {
        private readonly IMapper _mapper;
        public ProfessorDAL(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ProfessorDTO CreateProfessor(ProfessorDTO professor)
        {

            using (var entites = new universityContext())
            {
                var professorInDB = _mapper.Map<Professor>(professor);
                professorInDB.ProfessorId = professor.ProfessorId;
                entites.Professors.Add(professorInDB);
                entites.SaveChanges();
                return _mapper.Map<ProfessorDTO>(professorInDB);
            }
        }

        public List<ProfessorDTO> GetAllProfessors()
        {
            using (var entities = new universityContext())
            {
                var professors = entities.Professors.Where(x => x.ProfessorId != 0).ToList();
                return _mapper.Map<List<ProfessorDTO>>(professors);
            }
        }
        public ProfessorDTO UpdateProfessor(ProfessorDTO professor)
        {
            using (var entites = new universityContext())
            {
                var professorInDB = _mapper.Map<Professor>(professor);
                professorInDB = entites.Professors.SingleOrDefault(x => x.ProfessorId == professor.ProfessorId);
                if (professorInDB != null)
                {
                    professorInDB.ProfessorId = professor.ProfessorId;
                    professorInDB.Name = professor.Name;
                    professorInDB.LastName = professor.LastName;
                    professorInDB.PhoneNumber = professor.PhoneNumber;
                    professorInDB.Email = professor.Email;
                    entites.SaveChanges();
                    return _mapper.Map<ProfessorDTO>(professorInDB);
                }
                return null;
            }
        }

        public ProfessorDTO DeleteProfessor(ProfessorDTO professor)
        {
            using (var entites = new universityContext())
            {
                var professorInDB = _mapper.Map<Professor>(professor);
                professorInDB = entites.Professors.SingleOrDefault(x => x.ProfessorId == professor.ProfessorId);
                if (professorInDB != null)
                {
                    entites.Professors.Remove(professorInDB);
                    entites.SaveChanges();
                    return _mapper.Map<ProfessorDTO>(professorInDB);
                }
                return null;
            }
        }
    }
}
