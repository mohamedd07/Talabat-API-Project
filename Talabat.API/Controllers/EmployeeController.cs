using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications.EmployeeSpec;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseApiController
    {
        private readonly IGenericRepository<Employee> _employeeRepo;

        public EmployeeController(IGenericRepository<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var spec = new EmployeeWithDepartmentSpecifications();
            var employee = await _employeeRepo.GetAllWithSpecAsync(spec);

            return Ok(employee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var spec = new EmployeeWithDepartmentSpecifications(id);
            var employee = await _employeeRepo.GetWithSpecAsync(spec);

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }
    }
}
