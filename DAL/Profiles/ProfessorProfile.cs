using AutoMapper;
using DAL.Models;
using DTO;

namespace DAL.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<Professor, ProfessorDTO>().ReverseMap();
        }
    }
}
