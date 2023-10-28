using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.EmployeeManagement
{
    public class Employee: BaseEntity
    {
       
        public string? Name
        {
            get; set;
        }
        public string? LastName
        {
            get; set;
        }
      
        public decimal BaseSalary
        {
            get; set;
        }
        public decimal Bonus
        {
            get; set;
        }
        public decimal TotalPay
        {
            get; set;
        }
        public decimal OvertimePay
        {
            get; set;
        }
        public float OvertimeHours
        {
            get; set;
        }
        //Employee employee = new Employee { Name = "John Doe", Salary = new Salary { BaseSalary = 5000.00m, BonusPay = 1000.00m, OvertimePay = 500.00m } };

        //public decimal CalculateSalary()
        //{
        //    // Your implementation here
        //}
    }


}
