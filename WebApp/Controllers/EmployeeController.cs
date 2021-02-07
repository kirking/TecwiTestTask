using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Service;
using BLL.Models;

namespace WebApp.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService = new EmployeeService();

        [HttpPost]
        [Route("add")]
        public async Task<bool> PostEmployee(EmployeeModel model)
        {
            return await employeeService.AddAsync(model);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<bool> SoftDelete(int employeeId)
        {
            var result = await employeeService.SoftDelete(employeeId);
            return result;
        }

        [HttpGet]
        [Route("browse")]
        public async Task<Object> GetAllEmployees()
        {
            var result = await employeeService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("changename")]
        public async Task<bool> ChangeName(int employeeId, string newName)
        {
            var result = await employeeService.ChangeName(employeeId, newName);
            return result;
        }

        [HttpPost]
        [Route("changeposition")]
        public async Task<bool> ChangePosition(int employeeId, string newPosition)
        {
            var result = await employeeService.ChangePosition(employeeId, newPosition);
            return result;
        }

        [HttpPost]
        [Route("changeage")]
        public async Task<bool> ChangeAge(int employeeId, string newAge)
        {
            var result = await employeeService.ChangeAge(employeeId, newAge);
            return result;
        }

        [HttpPost]
        [Route("changeStartDate")]
        public async Task<bool> ChangeStartDate(int employeeId, string newStartDate)
        {
            var result = await employeeService.ChangeStartDate(employeeId, newStartDate);
            return result;
        }
    }
}
