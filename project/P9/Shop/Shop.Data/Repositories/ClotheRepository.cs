using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Core;

namespace Shop.Data.Repositories
{
    public class ClotheRepository
    {
        private ShopContext _context;
        private readonly ILogger _logger;
        public ClotheRepository(ShopContext context , ILoggerFactory logger)
        {
            this._context = context;
            this._logger = logger.CreateLogger("ClothProvider");
        }

        public async Task AddCloth(Clothe clothe)
        {
            var newId = this._context.Clothes.Select(ArgIterator => ArgIterator.Id).Max() + 1;
            clothe.Id = newId;
            await _context.Clothes.AddAsync(clothe);
            await _context.SaveChangesAsync();
        }

        public List<Clothe> GetAllClothes()
        {
            return this._context.Clothes.ToList();
        }

        public Clothe GetClothById(int id)
        {
            return _context.Clothes.Where(cloth => cloth.Id == id).FirstOrDefault();
        }

        public Clothe UpdateClotheName(int Id,string NewName)
        {
            var clothe = _context.Clothes.Where(cloth => cloth.Id == Id).FirstOrDefault();
            var temp = _context.Clothes.ToList();
            var idx = temp.IndexOf(clothe);
            clothe.Name = NewName;
            temp[idx] = clothe;
            _context.Clothes = (DbSet<Clothe>)temp.AsQueryable();
            _context.SaveChangesAsync();
            return temp[idx];
        }

        public List<Clothe> DeleteClothByIds(int[] Ids)
        {
            _context.Clothes = (DbSet<Clothe>)_context.Clothes.Where(c => !Ids.Contains(c.Id));
            _context.SaveChangesAsync();
            return _context.Clothes.ToList();
        }

        public List<Clothe> DeleteCloth(Clothe clothe)
        {
            _context.Clothes = (DbSet<Clothe>)_context.Clothes.Where(c => !(clothe.Id == c.Id));
            _context.SaveChangesAsync();
            return _context.Clothes.ToList();
        }
    }
}