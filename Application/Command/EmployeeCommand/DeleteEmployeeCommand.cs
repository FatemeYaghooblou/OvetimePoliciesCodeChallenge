﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
