using MedicalAttention_API.Entities;
using MedicalAttention_API.Entities.DTO;


namespace MedicalAttention_API.Repository.IRepository
{
    public interface IFacilityRepository
    {
        public Task<IEnumerable<Facility>> GetFacilities();

        public Task<Facility> GetFacilityById(int id);

        public Task<int> AddFacility(FacilityDTO facility);

        public Task<bool> DeleteFacility(int id);

        public Task<bool> UpdateFacility(Facility facility);
    }
}
