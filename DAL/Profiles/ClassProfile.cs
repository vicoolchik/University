using AutoMapper;
using DAL.Models;
using DTO;

namespace DAL.Profiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassDTO>().ReverseMap();
        }
    }
}
