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
        List<Pearl> _pearls = new List<Pearl>();

        public void Sort()
        {
            _pearls.Sort();
        }

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
        public Pearlbag()
        {
            for (int i = 0; i < 35; i++)
            {
                _pearls.Add(new Pearl());
            }
        }

    }
}
