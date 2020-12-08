using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Factory
{
    public class AnnualMonthlySalary : EmployeeDTO
    {
        public AnnualMonthlySalary(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleName = employee.RoleName;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
            AnnualSalary = employee.MonthlySalary * 12;
        }
    }
}
