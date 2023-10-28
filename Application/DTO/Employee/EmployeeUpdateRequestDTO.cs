using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Employee
{
    public class EmployeeUpdateRequestDTO : BaseDTO
    {
        public int Id
        {
            get; set;
        }
       
    }
}
