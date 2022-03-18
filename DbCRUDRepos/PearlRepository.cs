using PearlNecklace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCRUDRepos
{
    public class PearlRepository : IPearlRepository
    {
        NecklaceDb _db = null;

        public async Task<Pearl> CreateAsync(Pearl pearl) //Create? Add?
        {
            var added = await _db.Pearls.AddAsync(pearl); //Adds to database or creates?

            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return pearl;
            else
                return null;
        }

        public Task<Pearl> DeleteAsync(int pearlId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pearl>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pearl> ReadAsync(int pearlId)
        {
            throw new NotImplementedException();
        }

        public Task<Pearl> UpdateAsync(Pearl pearl)
        {
            throw new NotImplementedException();
        }
    }
}
