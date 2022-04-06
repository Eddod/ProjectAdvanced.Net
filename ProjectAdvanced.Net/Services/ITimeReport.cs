using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAdvanced.Net.Services
{
    public interface ITimeReport<TimeReport> : ILogic<TimeReport>
    {
        public Task<TimeReport> GetPersonHours(int id, int week);
    }
}
