using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        public async Task<EmployeeEntity> AddAsync(EmployeeEntity entity)
        {
            using (var context = new DatabaseContext(DatabaseContext.options.databaseOptions))
            {
                entity.IsDeleted = false;
                await context.Employees.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            return entity;
        }

        public void Delete(int id)
        {
            EmployeeEntity foundItem;
            using (var context = new DatabaseContext(DatabaseContext.options.databaseOptions))
            {
                foundItem = context.Employees.FirstOrDefault(i => i.Id == id);
                context.Remove(foundItem);
                context.SaveChangesAsync();
            }
        }

        public async Task<List<EmployeeEntity>> GetEntitiesAsync()
        {
            List<EmployeeEntity> employeeEntities;
            List<EmployeeEntity> result = new List<EmployeeEntity>();
            using (var context = new DatabaseContext(DatabaseContext.options.databaseOptions))
            {
                employeeEntities = await context.Employees.ToListAsync();
                foreach (var employee in employeeEntities)
                {
                    if (employee.IsDeleted == false)
                    {
                        result.Add(employee);
                    }
                }
            }
            return result;
        }

        public async Task<EmployeeEntity> GetEntityByIdAsync(int id)
        {
            EmployeeEntity employeeEntity;
            using (var context = new DatabaseContext(DatabaseContext.options.databaseOptions))
            {
                employeeEntity = await context.Employees.FirstOrDefaultAsync(i => i.Id == id);
            }
            return employeeEntity;
        }

        public void Update(EmployeeEntity entity)
        {
            using (var context = new DatabaseContext(DatabaseContext.options.databaseOptions))
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChangesAsync();
            }
        }
    }
}
