using OvetimePolicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Utility
{
    public static class GetCalculatorMethod
    {
        public static decimal Calculator( decimal baseSalary,float overtimeHours,string methodName )
        {
            var overTimeCalculatorType = typeof(OverTimeCalculator);
            var calcMethod = overTimeCalculatorType.GetMethod(methodName);
            var res = calcMethod.Invoke(null, new object[] { baseSalary, overtimeHours });
            var overtimePay = (decimal)(res ?? 0);
            return overtimePay;

        }
    }
}
