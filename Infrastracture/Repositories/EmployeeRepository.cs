using Core.Entities.EmployeeManagement;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task SoftDeleteAsync(int id)
        {
            var t = await _dbContext.Set<Employee>().FindAsync(id);
            t.IsDeleted = true;
            _dbContext.Entry(t).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}
