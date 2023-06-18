using _8_StoredProceduresWithEFDAL.Entities;
using _8_StoredProceduresWithEFDAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_StoredProceduresWithEFDAL
{
    public partial class AppDbContext
    {
        private AppDbContextProcedures _procedures;
        public virtual AppDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null)
                    _procedures = new AppDbContextProcedures(this);
                return _procedures;
            }
        }
    }

    public class AppDbContextProcedures
    {
        private readonly AppDbContext _context;
        public AppDbContextProcedures(AppDbContext context)
        {
            _context = context;
        }

        public IList<EmployeeModel> UspGetEmployees()
        {
            IList<EmployeeModel> employeeList = new List<EmployeeModel>();
            using (var command = _context.Database.GetDbConnection()
                .CreateCommand())
            {
                command.CommandText = "usp_getemployees";
                command.CommandType = CommandType.StoredProcedure;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.EmployeeId = reader.GetInt32("EmployeeId");
                        employee.Name = reader.GetString("Name");
                        employee.Address = reader.GetString("Address");
                        employee.DepartmentId = reader.GetInt32("DepartmentId");
                        employee.DepartmentName = reader.GetString("DepartmentName");
                        employeeList.Add(employee);
                    }
                }
                _context.Database.CloseConnection();
            }
            return employeeList;
        }

        public Employee UspGetEmployee(int EmployeeId)
        {
            Employee employee = new Employee();
            using (var command = _context.Database.GetDbConnection()
                .CreateCommand())
            {
                command.CommandText = "usp_getemployee";
                command.CommandType = CommandType.StoredProcedure;
                var parameter = new SqlParameter("EmployeeId", EmployeeId);
                command.Parameters.Add(parameter);
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employee.EmployeeId = reader.GetInt32("EmployeeId");
                        employee.Name = reader.GetString("Name");
                        employee.Address = reader.GetString("Address");
                        employee.DepartmentId = reader.GetInt32("DepartmentId");
                        break;
                    }
                }
                _context.Database.CloseConnection();
            }
            return employee;
        }

        public bool UspAddEmployee(Employee employee)
        {
            bool status = false;
            using (var command = _context.Database.GetDbConnection()
                .CreateCommand())
            {
                command.CommandText = "usp_addemployee";
                command.CommandType = CommandType.StoredProcedure;
                var paramName = new SqlParameter("Name", employee.Name);
                var paramAddress = new SqlParameter("Address", employee.Address);
                var paramDepartmentId = new SqlParameter("DepartmentId",
                    employee.DepartmentId);
                //output parameter
                var paramStatus = new SqlParameter()
                {
                    ParameterName = "@Status",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(paramName);
                command.Parameters.Add(paramAddress);
                command.Parameters.Add(paramDepartmentId);
                command.Parameters.Add(paramStatus);
                _context.Database.OpenConnection();
                command.ExecuteNonQuery();
                _context.Database.CloseConnection();
                if ((int)paramStatus.Value > 0)
                    status = true;
            }
            return status;
        }
    }
}
