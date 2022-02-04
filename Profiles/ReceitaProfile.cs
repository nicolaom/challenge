using AutoMapper;
using challenge.Data.Dtos.ReceitaDtos;
using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Profiles
{
    public class ReceitaProfile : Profile
    {
        public ReceitaProfile()
        {
            CreateMap<CreateReceitaDto, Receita>();
            CreateMap<Receita, ReadReceitaDto>();
            CreateMap<UpdateReceitaDto, Receita>();
        }
    }
}
