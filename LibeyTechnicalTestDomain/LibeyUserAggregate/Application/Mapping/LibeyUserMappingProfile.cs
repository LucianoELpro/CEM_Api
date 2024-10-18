using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Mapping
{
    public class LibeyUserMappingProfile : Profile
    {
        public LibeyUserMappingProfile()
        {
            CreateMap<LibeyUser, UserUpdateorCreateCommand>().ReverseMap();
         
        }
    }
}
