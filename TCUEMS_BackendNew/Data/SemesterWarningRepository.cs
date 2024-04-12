using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using TCUEMS_BackendNew.Models;

namespace TCUEMS_BackendNew.Data
{
    public class SemesterWarningRepository : ISemesterWarningRepository
    {
        private readonly string _connectionString;

        public SemesterWarningRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<SemesterWarning>> GetAllSemesterWarnings()
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return await dbConnection.QueryAsync<SemesterWarning>("SELECT * FROM Semester_Warning_View");
        }

        public async Task<IEnumerable<SemesterWarning>> GetWarningsByStudentId(int studentId)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return await dbConnection.QueryAsync<SemesterWarning>("SELECT * FROM Semester_Warning_View WHERE W_std_no = @studentId", new { studentId });
        }

        public async Task<IEnumerable<SemesterWarning>> GetSemesterWarningsByCriteria(SemesterWarning criteria)
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            await dbConnection.OpenAsync();

            string sqlQuery = "SELECT * FROM Semester_Warning_View WHERE 1 = 1";

            var queryParams = new DynamicParameters();

            if (!string.IsNullOrEmpty(criteria.w_dept_no))
            {
                sqlQuery += " AND W_dept_no = @DeptNameS";
                queryParams.Add("@DeptNameS", criteria.w_dept_no);
            }

            if (!string.IsNullOrEmpty(criteria.w_smtr))
            {
                sqlQuery += " AND W_smtr = @WSmtr";
                queryParams.Add("@WSmtr", criteria.w_smtr);
            }

            if (!string.IsNullOrEmpty(criteria.w_std_no))
            {
                sqlQuery += " AND W_std_no = @WStdNo";
                queryParams.Add("@WStdNo", criteria.w_std_no);
            }

            return await dbConnection.QueryAsync<SemesterWarning>(sqlQuery, queryParams);
        }
    }
}
