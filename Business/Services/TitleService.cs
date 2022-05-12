using Business.Interfaces;
using DataAccess.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TitleService:ITitleService
    {
        private readonly ITitleRepository _titleRepository;

        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public List<TitleAndContent> GetTitles()
        {
            
            return _titleRepository.DataExtraction();
        }
       
    }
}
