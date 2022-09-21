using ReadyDev_backend.DAL.Interfaces;
using ReadyDev_backend.Domain.Interfaces;
using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.Domain.Services
{
    public class FamilyService: IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;

        public FamilyService(IFamilyRepository familyRepository)
        {
            this._familyRepository = familyRepository;
        }

        public Task CreateFamily(Family family)
        {
            return _familyRepository.CreateFamily(family);
        }

        public IEnumerable<Family> GetAllFamilies()
        {
            return _familyRepository.GetAllFamilies();
        }

        public Task EditFamily(Family familyInDB, Family family)
        {
            familyInDB.FamilyName = family.FamilyName;
            familyInDB.Logo = family.Logo;
            familyInDB.Representative = family.Representative;
            return _familyRepository.EditFamily(familyInDB);
        }

        public Task DeleteFamily(Family family)
        {
            return _familyRepository.DeleteFamily(family);
        }

        public Task<Family> GetFamilyById(int id)
        {
            return _familyRepository.GetFamilyById(id);
        }
    }
}
