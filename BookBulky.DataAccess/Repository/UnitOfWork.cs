using BookBulky.DataAccess.Repository.IRepository;
using BookBulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
            Category = new CategoryRepository(_applicationDbContext);
            CoverType = new CoverTypeRepository(_applicationDbContext);
            Product = new ProductRepository(_applicationDbContext);
        }

        public ICategoryRepository Category{ get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public IProductRepository Product { get; private set; }


        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
