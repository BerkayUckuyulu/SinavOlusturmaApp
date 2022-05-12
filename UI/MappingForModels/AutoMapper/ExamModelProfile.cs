using AutoMapper;
using Dtos.Exam;
using UI.Models;

namespace UI.MappingForModels.AutoMapper
{
    public class ExamModelProfile:Profile
    {
        public ExamModelProfile()
        {
            CreateMap<ExamModel, ExamCreateDto>().ReverseMap();
        }
    }
}
