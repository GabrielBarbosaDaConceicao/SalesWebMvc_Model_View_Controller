using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.Include(x => x.Department).ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(d => d.Department).FirstOrDefault(s => s.Id == id);
        }
        public void Update(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Update(seller);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Remove(seller);
            _context.SaveChanges();
        }
    }
}
