using Application.Mapper;
using Application.Mapper.EmployeeMapper;
using Core.Entities.EmployeeManagement;
using Core.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.EmployeeCommands
{
    public class SoftDeleteEmployeeHandler : IRequestHandler<SoftDeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public SoftDeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Handle(SoftDeleteEmployeeCommand softDeleteEmployeeCommand, CancellationToken cancellationToken)
        {

            var a = EmployeeMapper.Mapper.Map<Employee>(softDeleteEmployeeCommand);

            await _employeeRepository.SoftDeleteAsync(a.Id);


        }
    }
}
