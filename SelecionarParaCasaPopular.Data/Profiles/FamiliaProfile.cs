using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SelecionarParaCasaPopular.Data.Models;
using SelecionarParaCasaPopular.Data.Models.Dtos;

namespace SelecionarParaCasaPopular.Data.Profiles
{
    public class FamiliaProfile : Profile
    {
        public FamiliaProfile()
        {
            CreateMap<CreateFamiliaDto, Familia>();
        }
    }
}
