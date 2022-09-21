using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.DAL.Interfaces
{
    public interface IFamilyRepository
    {
        public IEnumerable<Family> GetAllFamilies();

        public Task CreateFamily(Family family);

        public Task<Family> GetFamilyById(int id);

        public Task EditFamily(Family family);

        public Task DeleteFamily(Family family);
    }
}
