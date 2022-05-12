using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models
{
    public class ExamModel
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public string? TitleName { get; set; }
        public SelectList Titles { get; set; }
        public SelectList Options { get; set; }
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
        public string AppUserName { get; set; }
        public string DateTime { get; set; }

    }
    public class AjaxData
    {
        public string givenAnswer1 { get; set; }
        public string givenAnswer2 { get; set; }
        public string givenAnswer3 { get; set; }
        public string givenAnswer4 { get; set; }
    }
}
