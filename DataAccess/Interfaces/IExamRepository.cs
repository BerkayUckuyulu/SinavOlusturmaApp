using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IExamRepository
    {
        void Create(Exam exam);
        void Remove(object id);
        Task<List<Exam>> GetAllAsync();



    }
}
