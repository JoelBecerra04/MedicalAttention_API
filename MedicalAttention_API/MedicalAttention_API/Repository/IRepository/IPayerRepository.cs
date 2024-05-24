using MedicalAttention_API.Entities;
using MedicalAttention_API.Entities.DTO;

namespace MedicalAttention_API.Repository.IRepository
{
    public interface IPayerRepository
    {
        public Task<IEnumerable<Payer>> GetPayer();

        public Task<Payer> GetPayerById(int id);

        public Task<int> AddPayer(PayerDTO payer);

        public Task<bool> DeletePayer(int id);

        public Task<bool> UpdatePayer(Payer payer);
    }
}
