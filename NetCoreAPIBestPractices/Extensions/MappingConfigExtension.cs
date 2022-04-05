using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NetCoreAPIBestPractices.Data.Models;
using NetCoreAPIBestPractices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIBestPractices.Extensions
{
    public static class MappingConfigExtension
    {
        public static IServiceCollection ConfigureDasMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
    }

    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<Contact, ContactDVO>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id)) // since property names are same no need for this one
                .ReverseMap();
        }
    }
}
