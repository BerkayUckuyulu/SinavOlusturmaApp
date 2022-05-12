using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ITitleRepository
    {
        List<TitleAndContent> DataExtraction();
        string GetTitleAndContents(int id);
        string GetContentLink(int id);
    }
}
