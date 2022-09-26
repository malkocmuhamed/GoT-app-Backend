using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.Domain.Interfaces
{
    public interface IFamilyService
    {
        public IEnumerable<Family> GetAllFamilies();

        public List<Family> GetFamiliesByUser(int userId);

        public void CreateFamily(Family family);

        public Task<Family> GetFamilyById(int id);

        public Task EditFamily(Family familyInDB, Family family);

        public void DeleteFamily(Family family);
    }
}
