using AutoMapper;
using Dtos.Exam;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingForDtos.AutoMapper
{
    public  class ExamDtoProfile:Profile
    {
        public ExamDtoProfile()
        {
            CreateMap<ExamCreateDto, Exam>().ReverseMap();
            CreateMap<ExamListDto, Exam>().ReverseMap();
            CreateMap<ExamResolveDto, Exam>().ReverseMap();
        }
    }
}
