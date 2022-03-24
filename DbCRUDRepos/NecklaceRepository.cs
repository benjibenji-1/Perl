using PearlNecklace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCRUDRepos
{
	public class NecklaceRepository : INecklaceRepository
	{
		NecklaceDb _db = null;

		public async Task<Necklace> CreateAsync(Necklace neck)
		{
			var added = await _db.Necklaces.AddAsync(neck);

			int affected = await _db.SaveChangesAsync();
			if (affected == (neck._pearls.Count + 1))
				return neck;
			else
				return null;
		}

		public async Task<Necklace> DeleteAsync(int necklaceId)
		{
			var neckDel = await _db.Necklaces.FindAsync(necklaceId);
			_db.Necklaces.Remove(neckDel);

			int affected = await _db.SaveChangesAsync();
			if (affected == (neckDel._pearls.Count + 1))
				return neckDel;
			else
				return null;
		}

		public async Task<Necklace> ReadAsync(int neckId)
		{
			var necklace = await _db.Necklaces.FindAsync(neckId);
			var pearls = _db.Pearls.ToList();           //Needed if I want EFC to load the embedded pearls
			return necklace;
		}

		public async Task<IEnumerable<Necklace>> ReadAllAsync()
		{
			return await Task.Run(() =>
            {
				var necklaces = _db.Necklaces.ToList();
				var pearls = _db.Pearls.ToList();
				return necklaces;
            });
		}

		public async Task<Necklace> UpdateAsync(Necklace neck)
		{
			_db.Necklaces.Update(neck); //No db interaction until SaveChangesAsync
			await _db.SaveChangesAsync();
			return neck;
		}

		public NecklaceRepository(NecklaceDb db)
		{
			_db = db;
		}
	}
}
