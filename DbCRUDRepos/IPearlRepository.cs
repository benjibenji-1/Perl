using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PearlNecklace;

namespace DbCRUDRepos
{
    public interface IPearlRepository
    {
        Task<Pearl> CreateAsync(Pearl pearl);
        Task<IEnumerable<Pearl>> ReadAllAsync();
        Task<Pearl> ReadAsync(int pearlId);
        Task<Pearl> UpdateAsync(Pearl pearl);
        Task<Pearl> DeleteAsync(int pearlId);
    }
}
