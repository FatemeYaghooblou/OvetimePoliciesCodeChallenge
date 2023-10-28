using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class BaseDTO
    {
        public string Name
        {
            get; set;
        }
        public string LastName
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
        //public decimal TotalPay
        //{
        //    get; set;
        //}
        //public decimal OvertimePay
        //{
        //    get; set;
        //}
        public float OvertimeHours
        {
            get; set;
        }
    }
}
