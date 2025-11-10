using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityBack.Application;
using UniversityBack.Domain.Entities;

namespace UniversityBack.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<EmpresaDto, Empresa>();
        }
    }
}
