using Microsoft.EntityFrameworkCore;
using ProjectAdvanced.Net.DbModels;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAdvanced.Net.Services
{
    public class EmployeeRepository : ILogic<Employee>
    {
        private WebAppDbContext _dbcontext;
        public EmployeeRepository(WebAppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        public async Task<Employee> Add(Employee NewEntity)
        {
            var result = await _dbcontext.TblEmployees.AddAsync(NewEntity);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var result = await _dbcontext.TblEmployees.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (result != null)
            {
                _dbcontext.TblEmployees.Remove(result);
                await _dbcontext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbcontext.TblEmployees.ToListAsync();
        }

        public async Task<Employee> GetSingle(int id)
        {
            var person = await _dbcontext.TblEmployees.
                Include(tr=>tr.TimeReport).
                FirstOrDefaultAsync(e => e.EmployeeId == id);
           
            if (person != null)
            {
                return person;
            }
            return null;
        }

        public async Task<Employee> Update(Employee NewEntity)
        {
            var result = await _dbcontext.TblEmployees.
                FirstOrDefaultAsync(e => e.EmployeeId == NewEntity.EmployeeId);
            if (result != null)
            {
                result.FirstName = NewEntity.FirstName;
                result.LastName = NewEntity.LastName;
                result.PersonalNumber = NewEntity.PersonalNumber;

                await _dbcontext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
