using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IProfessorDAL
    {
        List<ProfessorDTO> GetAllProfessors();
        ProfessorDTO CreateProfessor(ProfessorDTO professor);
        ProfessorDTO UpdateProfessor(ProfessorDTO professor);
        ProfessorDTO DeleteProfessor(ProfessorDTO professor);
    }
}
