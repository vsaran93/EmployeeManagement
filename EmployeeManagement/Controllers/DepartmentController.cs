using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly EmployeeManagementContext _context;
        public DepartmentController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: api/department/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        //POST: api/department
        [HttpPost]
        public async Task<ActionResult<Department>> Create(Department department)
        {
            var newDepartment = new Department
            {
                Name = department.Name
            };

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
