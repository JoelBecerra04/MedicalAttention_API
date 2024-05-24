using Dapper;
using MedicalAttention_API.Entities;
using MedicalAttention_API.Entities.DTO;
using MedicalAttention_API.Repository.IRepository;
using System.Data;

namespace MedicalAttention_API.Repository
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly IDbConnection connection;

        public FacilityRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        public async Task<IEnumerable<Facility>> GetFacilities()
        {
            var query = "SELECT * FROM Facility";
            return await connection.QueryAsync<Facility>(query);
        }

        public async Task<Facility> GetFacilityById(int id)
        {
            var query = "SELECT * FROM Facility WHERE Id = @Id";
            return await connection.QuerySingleOrDefaultAsync<Facility>(query,new { Id = id });
        }

        public async Task<int> AddFacility(FacilityDTO facility)
        {
            var query = "INSERT INTO Facility (Name, City) VALUES (@Name, @City) RETURNING Id";
            return await connection.ExecuteScalarAsync<int>(query, facility);
        }

        public async Task<bool> DeleteFacility(int id)
        {
            var query = "DELETE FROM Facility WHERE Id = @Id";
            var result = await connection.ExecuteAsync(query, new { Id = id });
            return result > 0;
        }

        public async Task<bool> UpdateFacility(Facility facility)
        {
            var query = "UPDATE Facility SET Name = @Name, City = @City WHERE Id = @Id";
            var result = await connection.ExecuteAsync(query, facility);
            return result > 0;
        }
    }
}
