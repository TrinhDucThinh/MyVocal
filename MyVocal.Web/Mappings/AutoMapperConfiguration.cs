using AutoMapper;
using MyVocal.Model.Models;
using MyVocal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVocal.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Question, QuestionViewModel>();
            Mapper.CreateMap<QuestionCategory, QuestionCategoryViewModel>();
            Mapper.CreateMap<Semantic, SemanticViewModel>();
            Mapper.CreateMap<Subject, SubjectViewModel>();
            Mapper.CreateMap<SubjectGroup, SubjectGroupViewModel>();
            Mapper.CreateMap<Word, WordViewModel>();
            Mapper.CreateMap<WordCategory, WordCategoryViewModel>();
        }
    }
}