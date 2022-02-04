using AutoMapper;
using challenge.Data.Dtos.DespesaDtos;
using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Profiles
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<CreateDespesaDto, Despesa>();
            CreateMap<Despesa, ReadDespesaDto>();
            CreateMap<UpdateDespesaDto, Despesa>();
        }
    }
}
