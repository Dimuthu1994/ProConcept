using Microsoft.AspNetCore.Mvc;

namespace ProConcept.Controllers
{

    public class EmployeeController : Controller
    {

        public string Index()
        {
            return "List of employees";
        }

        public string DeleteEmployee(int id)
        {
            return "controller = Employee action = DeleteEmployee";
        }
    }
}
