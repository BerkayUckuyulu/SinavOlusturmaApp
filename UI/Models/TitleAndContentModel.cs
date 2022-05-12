using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models
{
    public class TitleAndContentModel
    {
        public int Id { get; set; }
        public string TitleName { get; set; }
        public string Content { get; set; }
        public SelectList Titles { get; set; }

    }
}
