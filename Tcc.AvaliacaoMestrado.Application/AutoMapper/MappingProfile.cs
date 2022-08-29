using AutoMapper;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFormCommand, FormViewModel>().ReverseMap();
            CreateMap<FormViewModel, Form>().ReverseMap();
        }
    }
}
