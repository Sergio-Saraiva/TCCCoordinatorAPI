using AutoMapper;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Answers;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions;
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
            CreateMap<GetByIdFormViewModel, Form>().ReverseMap();

            CreateMap<CreateQuestionCommand, QuestionViewModel>().ReverseMap();
            CreateMap<QuestionViewModel, Question>().ReverseMap();

            CreateMap<CreateOptionCommand, OptionViewModel>().ReverseMap();
            CreateMap<OptionViewModel, Option>().ReverseMap();

            CreateMap<CreateAnswerCommand, AnswerViewModel>().ReverseMap();
            CreateMap<CreateAnswerArray, AnswerViewModel>().ReverseMap();
            CreateMap<AnswerViewModel, Answer>().ReverseMap();

        }
    }
}
