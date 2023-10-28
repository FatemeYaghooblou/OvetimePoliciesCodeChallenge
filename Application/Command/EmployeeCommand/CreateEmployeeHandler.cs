
using Application.Mapper.EmployeeMapper;
using Core.Entities.EmployeeManagement;
using Core.IRepository;
using Infrastracture.Utility;
using MediatR;
using OvetimePolicies;
using System.Reflection;

namespace Application.Command.EmployeeCommands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

           
            Employee model = EmployeeMapper.Mapper.Map<Employee>(request);

            if (model is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            model.Created = DateTime.Now;
            model.CreatedBy = 1;
            model.OvertimePay = GetCalculatorMethod.Calculator(request.Data.BaseSalary, request.Data.OvertimeHours, request.OverTimeCalculator);
            model.TotalPay = TotalPayCalculator(request.Data.BaseSalary, request.Data.Bonus, model.OvertimePay);
            await _employeeRepository.AddAsync(model);

        }


        private decimal TotalPayCalculator(decimal baseSalary, decimal bonus, decimal overtimePay)
        {

            decimal totalPay = baseSalary + overtimePay + bonus;
            return totalPay;
        }
    }



}
