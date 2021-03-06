using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeManagementContext _context;
        public EmployeeController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: api/employee
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.Include(employee => employee.Departments).ToListAsync();

            return Ok(employees);
        }

        // GET: api/employee/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeDTO employee)
        {
            ICollection<Department> departments = _context.Departments.Where(x => employee.Departments.Contains(x.Id)).ToList();
            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Age = employee.Age,
                PhoneNumber = employee.PhoneNumber,
                Departments = departments
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Delete: api/employee/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
