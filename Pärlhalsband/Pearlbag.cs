using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PearlNecklace;


namespace PearlNecklace
{
    class Pearlbag : IPearlbag
    {
        public List<Pearl> _pearls = new List<Pearl>();

        public int Find(Pearl otherPearl)
        {
            int matches = 0;
            foreach (var pearl in _pearls)
            {
                if (pearl.Equals(otherPearl))
                {
                    matches++;
                }
            }
            return matches;
        }

        public Pearlbag(int numberOfPearls)
        {
            for (int i = 0; i < numberOfPearls; i++)
            {
                _pearls.Add(new Pearl());
            }
        }

    }
}
