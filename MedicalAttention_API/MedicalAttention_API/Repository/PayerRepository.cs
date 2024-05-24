using Dapper;
using MedicalAttention_API.Entities;
using MedicalAttention_API.Entities.DTO;
using MedicalAttention_API.Repository.IRepository;
using System.Data;

namespace MedicalAttention_API.Repository
{
    public class PayerRepository : IPayerRepository
    {
        private readonly IDbConnection connection;

        public PayerRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        public async Task<IEnumerable<Payer>> GetPayer()
        {
            var query = "SELECT * FROM Payer";
            return await connection.QueryAsync<Payer>(query);
        }

        public async Task<Payer> GetPayerById(int id)
        {
            var query = "SELECT * FROM Payer WHERE Id = @Id";
            return await connection.QuerySingleOrDefaultAsync<Payer>(query,new { Id = id });
        }

        public async Task<int> AddPayer(PayerDTO Payer)
        {
            var query = "INSERT INTO Payer (Name, City) VALUES (@Name, @City) RETURNING Id";
            return await connection.ExecuteScalarAsync<int>(query, Payer);
        }

        public async Task<bool> DeletePayer(int id)
        {
            var query = "DELETE FROM Payer WHERE Id = @Id";
            var result = await connection.ExecuteAsync(query, new { Id = id });
            return result > 0;
        }

        public async Task<bool> UpdatePayer(Payer Payer)
        {
            var query = "UPDATE Payer SET Name = @Name, City = @City WHERE Id = @Id";
            var result = await connection.ExecuteAsync(query, Payer);
            return result > 0;
        }
    }
}
