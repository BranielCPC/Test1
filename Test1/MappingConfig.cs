using AutoMapper;
using Test1.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test1
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Engineer, EngineCreateDTO>().ReverseMap();
            CreateMap<Engineer, EngineerDTO>().ReverseMap();
            CreateMap<Engineer, EngineerUpdateDTO>().ReverseMap();
        }
    }
}
