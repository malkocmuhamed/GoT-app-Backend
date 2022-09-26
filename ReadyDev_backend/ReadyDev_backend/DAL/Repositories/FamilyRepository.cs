using Microsoft.EntityFrameworkCore;
using ReadyDev_backend.DAL.Interfaces;
using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.DAL.Repositories
{
    public class FamilyRepository: IFamilyRepository
    {
        got_databaseContext _context;

        public FamilyRepository(got_databaseContext context)
        {
            this._context = context;
        }

        public List<Family> GetFamiliesByUser(int userId)
        {
            return _context.Families.Where(family => family.UserId == userId).ToList();
        }

        public void CreateFamily(Family family)
        {
            _context.Families.Add(family);
             _context.SaveChanges();
        }

        public IEnumerable<Family> GetAllFamilies()
        {
            return _context.Families;
        }

        public void EditFamily(Family family)
        {
            _context.Families.Update(family);
            _context.SaveChangesAsync();
        }

        public void DeleteFamily(Family family)
        {
            _context.Families.Remove(family);
            _context.SaveChangesAsync();
        }

        public async Task<Family> GetFamilyById(int id)
        {
            return await _context.Families.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
