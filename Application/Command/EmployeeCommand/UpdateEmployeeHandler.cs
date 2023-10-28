using Application.Mapper.EmployeeMapper;
using Core.Entities.EmployeeManagement;
using Core.IRepository;
using Infrastracture.Utility;
using MediatR;

namespace Application.Command.EmployeeCommands
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {


            Employee model = EmployeeMapper.Mapper.Map<Employee>(request);
            if (model is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            model.Modified = DateTime.Now;
            model.ModifiedBy = 1;
            model.OvertimePay = GetCalculatorMethod.Calculator(request.Data.BaseSalary, request.Data.OvertimeHours, request.OverTimeCalculator);
            model.TotalPay = TotalPayCalculator(request.Data.BaseSalary, request.Data.Bonus, model.OvertimePay);
            await _employeeRepository.UpdateAsync(model);

        }
        private decimal TotalPayCalculator(decimal baseSalary, decimal bonus, decimal overtimePay)
        {

            decimal totalPay = baseSalary + overtimePay + bonus;
            return totalPay;
        }
    }
}
