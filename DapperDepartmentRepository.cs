using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public DapperDepartmentRepository(IDbConnection conn)
        {
            _connection = conn;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("Select * from Departments");
        }
        public void InsertDepartment(string name)
        {
            _connection.Execute("Select * from Departments (Name) values (@name)", new { name});
        }

    }
}
