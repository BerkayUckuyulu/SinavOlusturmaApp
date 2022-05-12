using DataAccess.Interfaces;
using Entities;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly IDbContext _context;
        private readonly ITitleRepository _titleRepository;

        public ExamRepository(IDbContext context, ITitleRepository titleRepository)
        {
            _context = context;
            _titleRepository = titleRepository;
        }

        public void Create(Exam exam)
        {                   
                   
                _context.Set<Exam>().Add(exam);
                _context.SaveChanges();
            
        }
       
        public void Remove(object id)
        {
            var deletedExam = _context.Set<Exam>().Find(id);
            _context.Set<Exam>().Remove(deletedExam);
            _context.SaveChanges();
        }

        public async Task<List<Exam>> GetAllAsync()
        {
            return await _context.Set<Exam>().ToListAsync();
        }       
    }
}

