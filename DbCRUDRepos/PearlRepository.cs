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
            var added = await _db.Pearls.AddAsync(pearl); //Adds to database or creates? Unused?

            int affected = await _db.SaveChangesAsync(); //?
            if (affected == 1)
                return pearl;
            else
                return null;
        }

        public async Task<Pearl> DeleteAsync(int pearlId)
        {
            var pearlDel = await _db.Pearls.FindAsync(pearlId); //Probably wrong
            _db.Pearls.Remove(pearlDel);

            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return pearlDel;
            else
                return null;
        }

        public async Task<IEnumerable<Pearl>> ReadAllAsync()
        {
            return await Task.Run(() => _db.Pearls); //?
        }

        public async Task<Pearl> ReadAsync(int pearlId)
        {
            return await _db.Pearls.FindAsync(pearlId); //Probably wrong
        }

        public async Task<Pearl> UpdateAsync(Pearl pearl)
        {
            _db.Pearls.Update(pearl);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return pearl;
            else
                return null;
        }
        public PearlRepository(NecklaceDb db) //Constructor
        {
            _db = db;
        }
    }
}
