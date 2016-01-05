using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StartUpMentor.Model.Common;
using StartUpMentor.DAL.Models;
using StartUpMentor.UI.Models;

namespace StartUpMentor.UI.AutoMapperUIMapping
{
    public class UIMappingConfiguration : Profile
	    {
        protected override void Configure()
        {

			Mapper.CreateMap<IAnswer, IndexAnswerViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IAnswer, IndexAnswerViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IAnswer, DetailsAnswerViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IAnswer, DetailsAnswerViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IAnswer, CreateAnswerViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IAnswer, CreateAnswerViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IAnswer, UpdateAnswerViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IAnswer, UpdateAnswerViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IAnswer, DeleteAnswerViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IAnswer, DeleteAnswerViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IQuestion, IndexQuestionViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IQuestion, IndexQuestionViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IQuestion, DetailsQuestionViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IQuestion, DetailsQuestionViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IQuestion, CreateQuestionViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IQuestion, CreateQuestionViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IQuestion, UpdateQuestionViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IQuestion, UpdateQuestionViewModel>().ReverseMap().ConstructUsingServiceLocator();

			Mapper.CreateMap<IQuestion, DeleteQuestionViewModel>().ConstructUsingServiceLocator();
			Mapper.CreateMap<IQuestion, DeleteQuestionViewModel>().ReverseMap().ConstructUsingServiceLocator();
		}
    }
}
