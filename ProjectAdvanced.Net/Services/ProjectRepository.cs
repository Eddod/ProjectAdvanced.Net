using Microsoft.EntityFrameworkCore;
using ProjectAdvanced.Net.DbModels;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAdvanced.Net.Services
{
    public class ProjectRepository : ILogic<Project>
    {
        private WebAppDbContext _dbcontext;
        public ProjectRepository(WebAppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<Project> Add(Project NewEntity)
        {
            var result = await _dbcontext.TblProjects.AddAsync(NewEntity);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var result = await _dbcontext.TblProjects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (result != null)
            {
                _dbcontext.Remove(result);
                await _dbcontext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _dbcontext.TblProjects.ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            var result = await _dbcontext.TblProjects.
                Include(tr=>tr.TimeReports).
                ThenInclude(e=>e.Employee).
                FirstOrDefaultAsync(e => e.ProjectId == id);

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Project> Update(Project NewEntity)
        {
            var result = await _dbcontext.TblProjects.
                FirstOrDefaultAsync(e => e.ProjectId == NewEntity.ProjectId);
            if (result != null)
            {
                result.ProjectDescription = NewEntity.ProjectDescription;

                await _dbcontext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        
    }
}
