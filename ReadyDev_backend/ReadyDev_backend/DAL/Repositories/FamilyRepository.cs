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

        public async Task CreateFamily(Family family)
        {
            _context.Families.Add(family);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Family> GetAllFamilies()
        {
            return _context.Families;
        }

        public async Task EditFamily(Family family)
        {
            _context.Families.Update(family);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFamily(Family family)
        {
            _context.Families.Remove(family);
            await _context.SaveChangesAsync();
        }

        public async Task<Family> GetFamilyById(int id)
        {
            return await _context.Families.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
