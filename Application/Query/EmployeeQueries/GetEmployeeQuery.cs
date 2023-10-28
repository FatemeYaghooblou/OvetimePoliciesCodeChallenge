
using Application.DTO.Employee;
using Core.Entities.EmployeeManagement;
using MediatR;
using System.Linq.Expressions;

namespace Application.Query.EmployeeQueries
{
    public class GetEmployeeQuery : IRequest<List<EmployeeDTO>>
    {
        public Expression<Func<Employee, bool>> Predicate
        {
            get; set;
        }
    }
}
