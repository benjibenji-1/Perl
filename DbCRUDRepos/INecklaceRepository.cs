using PearlNecklace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCRUDRepos
{
	public interface INecklaceRepository
	{
		Task<Necklace> CreateAsync(Necklace neck);
		Task<IEnumerable<Necklace>> ReadAllAsync();
		Task<Necklace> ReadAsync(Guid necklaceId);
		Task<Necklace> UpdateAsync(Necklace neck);
		Task<Necklace> DeleteAsync(Guid necklaceId);
	}
}
