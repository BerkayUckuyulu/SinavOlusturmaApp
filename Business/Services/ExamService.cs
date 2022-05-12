using AutoMapper;
using Business.Interfaces;
using DataAccess.Interfaces;
using Dtos.Exam;
using Entities;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class ExamService : IExamService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public ExamService(IExamRepository examRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateExam(ExamCreateDto examCreateDto)
        {
            var createdExam = _mapper.Map<Exam>(examCreateDto);
            var x = await _userManager.FindByNameAsync(examCreateDto.AppUserName);
            createdExam.UserId = x.Id;
            _examRepository.Create(createdExam);


        }

        public  List<ExamListDto> ListExams(string userName)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            var exams= _examRepository.GetAllAsync();
            var usersExam=exams.Result.Where(x => x.UserId == user.Id).OrderByDescending(x=>x.Id).ToList();
            var examListDto=_mapper.Map<List<ExamListDto>>(usersExam);
            return examListDto;
           
        }
        public async Task<List<ExamResolveDto>> GetAllExam()
        {
           var exams= await _examRepository.GetAllAsync();
           return  _mapper.Map<List<ExamResolveDto>>(exams);
        }

        public void RemoveExam(int id)
        {
            _examRepository.Remove(id);
        }

    }
}
