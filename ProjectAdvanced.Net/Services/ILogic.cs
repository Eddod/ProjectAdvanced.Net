using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAdvanced.Net.Services
{
    public interface ILogic<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T NewEntity);
        Task<T> Update(T NewEntity);
        Task<T> Delete(int id);
    }
}
