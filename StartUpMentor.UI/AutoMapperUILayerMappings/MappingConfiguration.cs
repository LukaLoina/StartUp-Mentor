using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StartUpMentor.Model.Common;
using StartUpMentor.DAL.Models;
using StartUpMentor.UI.Models;

using AnswerType = StartUpMentor.Model.Answer;
using QuestionType = StartUpMentor.Model.Question;

namespace StartUpMentor.Model.AutoMapperModelLayerMapping
{
    public class UIMappingConfiguration : Profile
	    {
        protected override void Configure()
        {

			Mapper.CreateMap<AnswerType, IndexAnswerViewModel>();
			Mapper.CreateMap<AnswerType, IndexAnswerViewModel>().ReverseMap();

			Mapper.CreateMap<AnswerType, DetailsAnswerViewModel>();
			Mapper.CreateMap<AnswerType, DetailsAnswerViewModel>().ReverseMap();

			Mapper.CreateMap<AnswerType, CreateAnswerViewModel>();
			Mapper.CreateMap<AnswerType, CreateAnswerViewModel>().ReverseMap();

			Mapper.CreateMap<AnswerType, UpdateAnswerViewModel>();
			Mapper.CreateMap<AnswerType, UpdateAnswerViewModel>().ReverseMap();

			Mapper.CreateMap<AnswerType, DeleteAnswerViewModel>();
			Mapper.CreateMap<AnswerType, DeleteAnswerViewModel>().ReverseMap();

			Mapper.CreateMap<QuestionType, IndexQuestionViewModel>();
			Mapper.CreateMap<QuestionType, IndexQuestionViewModel>().ReverseMap();

			Mapper.CreateMap<QuestionType, DetailsQuestionViewModel>();
			Mapper.CreateMap<QuestionType, DetailsQuestionViewModel>().ReverseMap();

			Mapper.CreateMap<QuestionType, CreateQuestionViewModel>();
			Mapper.CreateMap<QuestionType, CreateQuestionViewModel>().ReverseMap();

			Mapper.CreateMap<QuestionType, UpdateQuestionViewModel>();
			Mapper.CreateMap<QuestionType, UpdateQuestionViewModel>().ReverseMap();

			Mapper.CreateMap<QuestionType, DeleteQuestionViewModel>();
			Mapper.CreateMap<QuestionType, DeleteQuestionViewModel>().ReverseMap();
		}
    }
}
