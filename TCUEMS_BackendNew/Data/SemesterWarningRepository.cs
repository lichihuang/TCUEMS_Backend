using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using TCUEMS_BackendNew.Models;

namespace TCUEMS_BackendNew.Data
{
    public class SemesterWarningRepository : ISemesterWarningRepository
    {
        private readonly string _connectionString; // 定義資料庫連接字串
        private readonly ILogger<SemesterWarningRepository> _logger; // 定義日誌記錄介面

        // 注入資料庫連接字串和日誌記錄
        public SemesterWarningRepository(string connectionString, ILogger<SemesterWarningRepository> logger)
        {
            _connectionString = connectionString; // 初始化資料庫連接字串
            _logger = logger; // 初始化日誌記錄
        }

        // 異步方法取得所有學期警告
        public async Task<IEnumerable<SemesterWarning>> GetAllSemesterWarnings()
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return await dbConnection.QueryAsync<SemesterWarning>("SELECT * FROM Semester_Warning_View");
        }

        // 異步方法根據條件取得學期警告
        public async Task<IEnumerable<SemesterWarning>> GetSemesterWarningsByCriteria(SemesterWarning criteria)
        {
            using SqlConnection dbConnection = new SqlConnection(_connectionString);
            await dbConnection.OpenAsync();

            // L查詢語句
            string sqlQuery = "SELECT * FROM Semester_Warning_View WHERE 1 = 1";
            var queryParams = new DynamicParameters();

            if (!string.IsNullOrEmpty(criteria.w_dept_no))
            {
                sqlQuery += " AND w_dept_no = @DeptNo";
                queryParams.Add("@DeptNo", criteria.w_dept_no);
            }

            if (!string.IsNullOrEmpty(criteria.w_smtr))
            {
                sqlQuery += " AND w_smtr = @WSmtr";
                queryParams.Add("@WSmtr", criteria.w_smtr);
            }

            if (!string.IsNullOrEmpty(criteria.w_std_no))
            {
                sqlQuery += " AND w_std_no = @WStdNo";
                queryParams.Add("@WStdNo", criteria.w_std_no);
            }


            // 記錄
            _logger.LogInformation("Generated SQL Query: {SqlQuery}", sqlQuery);
            foreach (var param in queryParams.ParameterNames)
            {
                _logger.LogInformation("Parameter: {ParameterName} = {ParameterValue}", param, queryParams.Get<object>(param));
            }

            var results = await dbConnection.QueryAsync<SemesterWarning>(sqlQuery, queryParams);
            return results;
        }
    }
}
