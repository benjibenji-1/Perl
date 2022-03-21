using PearlNecklace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCRUDRepos
{
	internal class NecklaceRepository : INecklaceRepository
	{
		NecklaceDb _db = null;

		public async Task<Necklace> CreateAsync(Necklace neck)
		{
			var added = await _db.Necklaces.AddAsync(neck);

			int affected = await _db.SaveChangesAsync();
			if (affected == 1)
				return neck;
			else
				return null;
		}

		public async Task<Necklace> DeleteAsync(Guid necklaceId)
		{
			var neckDel = await _db.Necklaces.FindAsync(necklaceId);
			_db.Necklaces.Remove(neckDel);

			int affected = await _db.SaveChangesAsync();
			if (affected == 1)
				return neckDel;
			else
				return null;
		}

		public async Task<Necklace> ReadAsync(Guid neckId)
		{
			return await _db.Necklaces.FindAsync(neckId);
		}

		public async Task<IEnumerable<Necklace>> ReadAllAsync()
		{
			return await Task.Run(() => _db.Necklaces);
		}

		public async Task<Necklace> UpdateAsync(Necklace neck)
		{
			_db.Necklaces.Update(neck);
			int	affected = await _db.SaveChangesAsync();
			if (affected == 1)
				return neck;
			else
				return null;
		}

		public NecklaceRepository(NecklaceDb db)
		{
			_db = db;
		}
	}
}
