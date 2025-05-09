﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
        Employee? GetById(int id, bool withBookings);
    }
}
