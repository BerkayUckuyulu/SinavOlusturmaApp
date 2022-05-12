using AutoMapper;
using Business.Interfaces;
using Dtos.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.Cache;
using UI.Models;

namespace UI.Controllers
{
    public class ExamController : Controller
    {
        private readonly ITitleAndContentsCache _titleCache;
        private readonly IMapper _mapper;
        private readonly IExamService _examService;

        public ExamController(ITitleAndContentsCache titleCache, IMapper mapper, IExamService examService)
        {
            _titleCache = titleCache;
            _mapper = mapper;
            _examService = examService;
        }

        public IActionResult SelectExamTitle()
        {


            var titlesAndContents = _titleCache.TitleCache();
            ExamModel examModel = new ExamModel
            {
                Titles = new SelectList(titlesAndContents, "TitleId", "TitleName")
            };



            return View(examModel);


        }
        [HttpPost]
        public IActionResult SelectExamTitle(ExamModel examModel)
        {


            var titleAndContents = _titleCache.TitleCache();

            var selectedTitle = titleAndContents.Find(x => x.TitleId == examModel.TitleId);


            examModel.Content = selectedTitle.Content;
            examModel.TitleName = selectedTitle.TitleName;
            examModel.Titles = new SelectList(titleAndContents, "TitleId", "TitleName", examModel.TitleId);



            return View(examModel);

        }

        [HttpPost]
        public IActionResult CreateTest(ExamModel model)
        {


            var titleAndContents = _titleCache.TitleCache();

            var selectedTitle = titleAndContents.Find(x => x.TitleId == model.TitleId);
            model.TitleName = selectedTitle.TitleName;
            model.Content = selectedTitle.Content;
            List<string> options = new List<string> { "A", "B", "C", "D" };
            model.Options = new SelectList(options);

            return View(model);
        }
        [HttpPost]
        public IActionResult CreateTestLast(ExamModel model)
        {
            var titleAndContents = _titleCache.TitleCache();

            var selectedTitle = titleAndContents.Find(x => x.TitleId == model.TitleId);
            model.TitleName = selectedTitle.TitleName;
            model.Content = selectedTitle.Content;
            var userName = User.Identity.Name;
            model.AppUserName = userName;

            var createdExamDto = _mapper.Map<ExamCreateDto>(model);

            _examService.CreateExam(createdExamDto);


            return RedirectToAction("ListExams");
        }

        public IActionResult ListExams()
        {
            var userName = User.Identity.Name;
            var examListDto = _examService.ListExams(userName);
            return View(examListDto);

        }
        
        public IActionResult RemoveExam(int id)
        {
            _examService.RemoveExam(id);

            return RedirectToAction("ListExams");
        }

        public IActionResult StartExam(int id)
        {
            var examResolveDtos = _examService.GetAllExam();
            var examResolveDto = examResolveDtos.Result.Find(x => x.Id == id);
            return View(examResolveDto);
        }
        [HttpPost]
        public IActionResult GetAnswers(AjaxData ajaxData)
        {
            var x = "İyi kötü bitti :)";
            return Json(x);
        }
     
    }
}
