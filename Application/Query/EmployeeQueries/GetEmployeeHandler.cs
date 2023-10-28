using Application.DTO;
using Application.DTO.Employee;
using Application.Mapper;
using Application.Mapper.EmployeeMapper;
using Core.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query.EmployeeQueries
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeeQuery query, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.Get(query.Predicate);
            var v = employee.ToList();
            try
            {
                var employee_= EmployeeMapper.Mapper.Map<List<EmployeeDTO>>(v);
                return employee_;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
