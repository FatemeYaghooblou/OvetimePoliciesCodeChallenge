using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvetimePolicies
{
    public static class OverTimeCalculator
    {

        public static decimal CalculatorA(decimal baseSalary, float overtimeHours)
        {
            decimal overtimePay = (baseSalary / 2080m) * 1.5m * (decimal)overtimeHours;
            return overtimePay;
        }
        
        public static decimal CalculatorB(decimal baseSalary ,float overtimeHours)
        {
            
            decimal overtimePay = baseSalary / 2080m * 1.5m * (decimal)(overtimeHours > 40 ? overtimeHours - 40 : 0);
            return overtimePay;
        }
    
        public static decimal CalculatorC(decimal baseSalary, float overtimeHours)
        {
            decimal hourlyRate = baseSalary / 2080m;
            decimal overtimePay = 0m;
            if (overtimeHours > 0)
            {
                overtimePay = hourlyRate * 1.5m * (decimal)overtimeHours;
            }
            return overtimePay;
        }



    }
}
