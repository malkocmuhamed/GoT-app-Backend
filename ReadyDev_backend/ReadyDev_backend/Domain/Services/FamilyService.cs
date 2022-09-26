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

        public void CreateFamily(Family family)
        {
             _familyRepository.CreateFamily(family);
        }

        public List<Family> GetFamiliesByUser(int userId)
        {
           return  _familyRepository.GetFamiliesByUser(userId);
        }

        public IEnumerable<Family> GetAllFamilies()
        {
            return _familyRepository.GetAllFamilies();
        }

        public void EditFamily(Family familyInDB, Family family)
        {
            familyInDB.FamilyName = family.FamilyName;
            familyInDB.Logo = family.Logo;
            familyInDB.Representative = family.Representative;
             _familyRepository.EditFamily(familyInDB);
        }

        public void DeleteFamily(Family family)
        {
            _familyRepository.DeleteFamily(family);
        }

        public async Task<Family> GetFamilyById(int id)
        {
            return await _familyRepository.GetFamilyById(id);
        }
    }
}
