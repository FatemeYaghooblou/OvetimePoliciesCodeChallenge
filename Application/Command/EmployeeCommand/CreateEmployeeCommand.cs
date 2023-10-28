
using Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.EmployeeCommands
{
    public class CreateEmployeeCommand : IRequest
    {
        public CreateEmployeeCommand()
        {
             Data = new();
        }
        public EmployeeCreateRequestDTO  Data { get; set; }
        public string OverTimeCalculator { get; set; } = "";
    }
}
