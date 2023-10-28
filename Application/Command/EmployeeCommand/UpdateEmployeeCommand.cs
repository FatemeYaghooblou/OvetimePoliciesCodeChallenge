using Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.EmployeeCommands
{
    public class UpdateEmployeeCommand : IRequest
    {
        public UpdateEmployeeCommand()
        {
            Data = new();
        }
        public EmployeeUpdateRequestDTO Data
        {
            get; set;
        }
        public string OverTimeCalculator { get; set; } = "";
    }
}
