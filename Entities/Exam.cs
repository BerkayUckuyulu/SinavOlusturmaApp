using Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Exam:BaseEntity
    {
        public int TitleId { get; set; }
        public string? TitleName { get; set; }
        public string? Content { get; set; }
        public string? Question1 { get; set; }
        public string? A1 { get; set; }
        public string? B1 { get; set; }
        public string? C1 { get; set; }
        public string? D1 { get; set; }
        public string? Answer1 { get; set; }
        public string? Question2 { get; set; }
        public string? A2 { get; set; }
        public string? B2 { get; set; }
        public string? C2 { get; set; }
        public string? D2 { get; set; }
        public string? Answer2 { get; set; }
        public string? Question3 { get; set; }
        public string? A3 { get; set; }
        public string? B3 { get; set; }
        public string? C3 { get; set; }
        public string? D3 { get; set; }
        public string? Answer3 { get; set; }
        public string? Question4 { get; set; }
        public string? A4 { get; set; }
        public string? B4 { get; set; }
        public string? C4 { get; set; }
        public string? D4 { get; set; }
        public string? Answer4 { get; set; }
        public AppUser AppUser { get; set; }
        public int UserId { get; set; }
        public string CreatedDate{ get; set; }


    }
}
