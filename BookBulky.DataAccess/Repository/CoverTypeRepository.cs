using BookBulky.DataAccess.Repository.IRepository;
using BookBulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBulky.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public CoverTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public void Update(CoverType coverType)
        {
            _applicationDbContext.CoverTypes.Update(coverType); 
        }
    }
}
