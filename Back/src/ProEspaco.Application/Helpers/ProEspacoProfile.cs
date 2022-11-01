using AutoMapper;
using ProEspaco.Application.DTOs;
using ProEspaco.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Application.Helpers
{
    public class ProEspacoProfile : Profile
    {
        public ProEspacoProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
