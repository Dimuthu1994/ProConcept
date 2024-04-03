using System.Data.SqlClient;

namespace ProConcept.Models
{
    public class SQLDBLayer : IEmployeeRepository
    {
        public IConfiguration Configuration { get; }
        public SQLDBLayer(IConfiguration configuration)
        {

            Configuration = configuration;

        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("EmployeeContext")))
            {
                string query = "SELECT ID, NAME, SALARY, A.DEPARTMENT AS Department FROM TBLEMPLOYEE A LEFT JOIN TBLDEPARTMENT B ON A.DEPARTMENT = B.DEPT_ID;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = Convert.ToInt32(sdr["ID"]),
                                Name = sdr["NAME"].ToString(),
                                Salary = Convert.ToInt32(sdr["SALARY"]),
                                Department = Convert.ToInt32(sdr["Department"]),
                            });
                        }
                    }
                }
            }
            return employees;
        }

    }
}
