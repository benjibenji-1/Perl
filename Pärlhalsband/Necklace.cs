using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace
{
    class Necklace : Pearlbag
    {
        List<Pearl> _necklacePearls = new List<Pearl>();
        public void Sort()
        {
            _pearls.Sort();
        }
        public override string ToString()
        {
            string returnString = "";
            foreach (var item in this._pearls)
            {
                returnString += $"{item} ";
            }
            return returnString;
        }
        public Necklace(Pearlbag pearlbag)
        {
            _necklacePearls = pearlbag._pearls;
            Sort();
        }
    }
}