﻿using Core.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task SoftDeleteAsync(int id);
    }
}
