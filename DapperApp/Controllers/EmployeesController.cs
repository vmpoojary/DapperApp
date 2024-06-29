using DapperApp.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployee _employee;
        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet("get-employees")]
        public async  Task<IActionResult> GetEmployees()
        {
            var response = await _employee.GetEmployees();
            return Ok(response);

        }

        [HttpGet("get-employee")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            var response=await _employee.GetEmployee(id);
            return Ok(response);
        }
    }
}
