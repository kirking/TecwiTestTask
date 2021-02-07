using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using AutoMapper;
using BLL.AutoMapper;
using DAL.Entities;

namespace BLL.Service
{
    public class EmployeeService : IEmployeeService
    {
        public IUnitOfWork unitOfWork = new DAL.UnitOfWork.UnitOfWork();
        public Mapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>(); }));

        public async Task<bool> AddAsync(EmployeeModel model)
        {
            try
            {
                EmployeeEntity product = mapper.Map<EmployeeEntity>(model);
                var result = await unitOfWork.EmployeeRepository.AddAsync(product);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            if (unitOfWork.EmployeeRepository.GetEntityByIdAsync(id) != null)
            {
                unitOfWork.EmployeeRepository.Delete(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SoftDelete(int employeeId)
        {
            try
            {
                var employee = await unitOfWork.EmployeeRepository.GetEntityByIdAsync(employeeId);
                if (employee != null && employee.IsDeleted == false)
                {
                    employee.IsDeleted = true;
                    unitOfWork.EmployeeRepository.Update(employee);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return true;
            }
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            try
            {
                List<EmployeeEntity> employeeEntities = await unitOfWork.EmployeeRepository.GetEntitiesAsync();
                List<EmployeeModel> employeeModels = new List<EmployeeModel>();
                foreach (EmployeeEntity employeeEntity in employeeEntities)
                {
                    employeeModels.Add(mapper.Map<EmployeeModel>(employeeEntity));
                }
                return employeeModels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ChangeName(int employeeId, string newName)
        {
            try
            {
                var employee = await unitOfWork.EmployeeRepository.GetEntityByIdAsync(employeeId);
                if (newName != null && employee != null && employee.IsDeleted == false)
                {
                    employee.Name = newName;
                    unitOfWork.EmployeeRepository.Update(mapper.Map<EmployeeEntity>(employee));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return true;
            }
        }

        public async Task<bool> ChangePosition(int employeeId, string newPosition)
        {
            try
            {
                var employee = await unitOfWork.EmployeeRepository.GetEntityByIdAsync(employeeId);
                if (newPosition != null && employee != null && employee.IsDeleted == false)
                {
                    employee.Position = newPosition;
                    unitOfWork.EmployeeRepository.Update(mapper.Map<EmployeeEntity>(employee));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return true;
            }
        }

        public async Task<bool> ChangeAge(int employeeId, string newAge)
        {
            try
            {
                int newAgeInt = int.Parse(newAge);
                var employee = await unitOfWork.EmployeeRepository.GetEntityByIdAsync(employeeId);
                if (newAgeInt != null && employee != null && employee.IsDeleted == false)
                {
                    employee.Age = newAgeInt;
                    unitOfWork.EmployeeRepository.Update(mapper.Map<EmployeeEntity>(employee));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return true;
            }
        }

        public async Task<bool> ChangeStartDate(int employeeId, string newDate)
        {
            try
            {
                DateTime newDateTime = Convert.ToDateTime(newDate);
                var employee = await unitOfWork.EmployeeRepository.GetEntityByIdAsync(employeeId);
                if (newDateTime != null && employee != null && employee.IsDeleted == false)
                {
                    employee.StartDate = newDateTime;
                    unitOfWork.EmployeeRepository.Update(mapper.Map<EmployeeEntity>(employee));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return true;
            }
        }
    }
}
