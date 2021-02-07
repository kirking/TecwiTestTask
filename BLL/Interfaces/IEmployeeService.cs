using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IEmployeeService : ICrud<EmployeeModel>
    {
        Task<bool> ChangeName(int employeeId, string newName);
        Task<bool> ChangePosition(int employeeId, string newPosition);
        Task<bool> ChangeAge(int employeeId, string newAge);
        Task<bool> ChangeStartDate(int employeeId, string newStartDate);
    }
}
