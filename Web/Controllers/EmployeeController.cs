using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<List<EmployeeDTO>> GetEmployeeAsync(int? employeeId)
        {
            try
            {
                var result = await employeeService.GetEmployeeAsync(employeeId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}