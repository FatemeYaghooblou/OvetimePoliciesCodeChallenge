
using Application.Command;
using Application.Command.EmployeeCommands;
using Application.DTO.Employee;
using Application.Query.EmployeeQueries;
using Core.Entities.EmployeeManagement;
using Core.IRepository;
using Infrastracture;
using Infrastracture.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(
       opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
   );


builder.Services.AddTransient<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IRequestHandler<GetEmployeeQuery, List<EmployeeDTO>>, GetEmployeeHandler>();
builder.Services.AddTransient<IRequestHandler<CreateEmployeeCommand>, CreateEmployeeHandler>();
builder.Services.AddTransient<IRequestHandler<SoftDeleteEmployeeCommand>, SoftDeleteEmployeeHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateEmployeeCommand>, UpdateEmployeeHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteEmployeeCommand>, DeleteEmployeeHandler>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.SaveChangesAsync();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();





//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();