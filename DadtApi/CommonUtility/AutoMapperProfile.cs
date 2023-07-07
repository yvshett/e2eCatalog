using AutoMapper;
using DadtApi.DomainModels;
using DadtApi.Models;

namespace DadtApi.CommonUtility
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserMe>();
            CreateMap<WebObjectMetadatum, WebObjectView>();
        }
    }
}
