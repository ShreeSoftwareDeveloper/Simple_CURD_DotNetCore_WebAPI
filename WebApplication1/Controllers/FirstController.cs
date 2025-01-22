using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase   
    {
        private readonly FirstContext _first;
        public FirstController(FirstContext first)
        {
            _first = first;
        }
       // Get All the API
        [HttpGet]
        public async Task<string> GetHello()
        {
            return "Hello Shree Your Api Working Fine. Thanks for create the api.";
        }
        [HttpGet("Get Employee")]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await _first.Employees.ToListAsync();
        }
        [HttpGet("GetEmployee")]
        public async Task<IEnumerable<Employee>> GetEmp()
        {
            return await _first.Employees.ToListAsync();
        }
        [HttpGet("GetEmployees")]
        public async Task<List<Employee>> GetEmps()
        {
            return await _first.Employees.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var result= await _first.AddAsync(employee);
                        await _first.SaveChangesAsync();
            return result.Entity;
        }
        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<Employee>> GetById(int Id)
        {
            return await _first.Employees.FindAsync(Id);
        }
        [HttpPut]
        public async Task<string> UpdateEmployee(Employee employee)
        {
            var employees = await _first.Employees.FindAsync(employee.Id);
            if(employees!=null)
            {
                employees.Name = employee.Name;
                employees.Mobile = employee.Mobile;
                await _first.SaveChangesAsync();
            }
            else
            {
                return "Id is not matched";
            }
            return "Data updated Succesfuuly";
        }
        [HttpDelete]
        public async Task<string> DeleteEmployee(int id)
        {
            var result = await _first.Employees.FindAsync(id);
           if(result!=null)
            {
               _first.Employees.Remove(result);
                await _first.SaveChangesAsync();
            }
            else
            {
                return "Id not Matched";

            }
            return "Deleted Succefully";

        }

    }
}
