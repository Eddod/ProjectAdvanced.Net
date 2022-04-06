using Microsoft.EntityFrameworkCore;
using ProjectAdvanced.Net.DbModels;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAdvanced.Net.Services
{
    public class TimeReportRepository : ITimeReport<TimeReport>
    {
        private WebAppDbContext _dbcontext;
        public TimeReportRepository(WebAppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<TimeReport> Add(TimeReport NewEntity)
        {
            var result = await _dbcontext.TblTimereports.AddAsync(NewEntity);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeReport> Delete(int id)
        {
            var result = await _dbcontext.TblTimereports.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _dbcontext.Remove(result);
                await _dbcontext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            return await _dbcontext.TblTimereports.ToListAsync();
        }

        public async Task<TimeReport> GetSingle(int id)
        {
            var result = await _dbcontext.TblTimereports.FirstOrDefaultAsync(e => e.Id== id);

            if (result != null)
            {
                return result;
            }
            return null;
        }
        
        public async Task<TimeReport> Update(TimeReport NewEntity)
        {
            var result = await _dbcontext.TblTimereports.
                FirstOrDefaultAsync(e => e.Id == NewEntity.Id);
            if (result != null)
            {
                result.EmployeeId = NewEntity.EmployeeId;
                result.ProjectId = NewEntity.ProjectId;
                result.Week = NewEntity.Week;
                result.WorkHours = NewEntity.WorkHours;

                await _dbcontext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TimeReport> GetPersonHours(int id, int week)
        {
            var weekHours = await _dbcontext.TblTimereports.
                Include(tr => tr.Employee).
                FirstOrDefaultAsync(e => e.EmployeeId == id && e.Week == week );
            if (weekHours != null)
            {
                return weekHours;
            }
            return null;
        }
    }
}
