using AutoMapper;
using DSR_MAGALU_BUSINESS.Models;
using DSR_MAGALU_DATA.Entities;

namespace DSR_MAGALU_BUSINESS.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}