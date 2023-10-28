using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Employee
{
    public class EmployeeDTO
    {
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public DateTime HireDate
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
    }
}
