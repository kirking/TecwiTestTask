using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeRepository employeeRepository;

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository();
                }
                return employeeRepository;

            }
        }
    }
}
