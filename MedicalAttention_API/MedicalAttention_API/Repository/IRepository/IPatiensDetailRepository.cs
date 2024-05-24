using MedicalAttention_API.Entities.DTO;


namespace MedicalAttention_API.Repository.IRepository
{
    public interface IPatientDetailRepository
    {
        public Task<IEnumerable<PatientDetailsDTO>> GetPatientDetails();

    }
}
