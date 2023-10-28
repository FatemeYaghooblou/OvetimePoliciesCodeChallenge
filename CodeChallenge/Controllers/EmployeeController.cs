using Application.Command;
using Application.Command.EmployeeCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace WebApi.Controllers
{
  
    [ApiController]
   // [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public EmployeeController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        // GET: EmployeeController
       

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand createPersonCommand, CancellationToken cancellationToken)
        {

            try
            {
                if (_mediatr != null && createPersonCommand != null)
                {
                    await _mediatr.Send(createPersonCommand, cancellationToken);
                }
                return Ok("Success");
            }
            catch
            {
                return Ok("Error");
            }
        }

        // POST: EmployeeController/Edit/5
        [HttpPut("Update")]
        public async Task<IActionResult> Edit(UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken)
        {
            try
            {
                await _mediatr.Send(updateEmployeeCommand, cancellationToken);
                return Ok("Success");
            }
            catch
            {
                return Ok("Error");
            }
        }

        // POST: EmployeeController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _mediatr.Send(command, cancellationToken);
                return Ok("Success");
            }
            catch
            {
                return Ok("Error");
            }
        }
    }
}
