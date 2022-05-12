using Dtos.Exam;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IExamService
    {
        Task CreateExam(ExamCreateDto examCreateDto);
        List<ExamListDto> ListExams(string userName);
        Task<List<ExamResolveDto>> GetAllExam();
        void RemoveExam(int id);
    }
}
