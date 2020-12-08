using Core.DTO;
using Core.Entities;
using Core.Factory;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDTO>> GetEmployeeAsync(int? employeeId)
        {
            try
            {
                var employees = await employeeRepository.GetEmployees();

                if (!employeeId.HasValue)
                {
                    return GetEmployeeDTOs(employees);
                }
                else
                {
                    return GetEmployeeDTOs(employees.Where(x => x.Id == employeeId).ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<EmployeeDTO> GetEmployeeDTOs(List<Employee> employees)
        {
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();

            foreach (var employee in employees)
            {
                if (employee.ContractTypeName == "HourlySalaryEmployee")
                {
                    AnnualHourlySalary annualHourlySalary = new AnnualHourlySalary(employee);
                    employeeDTOs.Add(annualHourlySalary);
                }
                else
                {
                    AnnualMonthlySalary annualMonthlySalary = new AnnualMonthlySalary(employee);
                    employeeDTOs.Add(annualMonthlySalary);
                }
            }

            return employeeDTOs;
        }
    }
}
