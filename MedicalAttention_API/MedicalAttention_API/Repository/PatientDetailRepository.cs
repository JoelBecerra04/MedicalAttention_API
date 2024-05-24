using Dapper;
using MedicalAttention_API.Entities;
using MedicalAttention_API.Entities.DTO;
using MedicalAttention_API.Repository.IRepository;
using System.Data;

namespace MedicalAttention_API.Repository
{
    public class PatientDetailRepository : IPatientDetailRepository
    {
        private readonly IDbConnection connection;

        public PatientDetailRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        public async Task<IEnumerable<PatientDetailsDTO>> GetPatientDetails()
        {
            var query = @"SELECT
                            P.Last_Name || ', ' || P.First_Name AS Full_Name,
                            STRING_AGG(DISTINCT F.City, ', ' ORDER BY F.City) AS Cities,
                            CASE
                                WHEN P.Age < 16 THEN 'A'
                                ELSE 'B'
                            END AS Category,
	                        COUNT(Pa.City)
                        FROM
                            Patient P
                        LEFT JOIN
                            Encounter E ON P.Id = E.Patient_Id
                        LEFT JOIN
                            Facility F ON F.Id = E.Facility_Id
                        LEFT JOIN
                            Payer Pa ON Pa.Id = E.Payer_Id
                        GROUP BY
                            P.Id, P.First_Name, P.Last_Name, P.Age
	                        HAVING COUNT(DISTINCT Pa.City) >= 2";

            return await connection.QueryAsync<PatientDetailsDTO>(query);
        }


    }
}
