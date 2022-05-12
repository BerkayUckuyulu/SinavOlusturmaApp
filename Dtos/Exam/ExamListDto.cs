using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Exam
{
    public class ExamListDto
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public string? TitleName { get; set; }
        public string? Content { get; set; }
        public string CreatedDate { get; set; }


    }
}
