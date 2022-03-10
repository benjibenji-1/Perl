using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace
{
    class Necklace
    {
        public Pearlbag pearlbag { get; set; }

        public void Sort()
        {
            pearlbag._pearls.Sort();
        }
        public override string ToString()
        {
            string returnString = "";
            int returnPrice = 0;
            foreach (var item in this.pearlbag._pearls)
            {
                returnString += $"{item} ";
                returnPrice += item.Price;
            }
            return $"{returnString}\n Total price of necklace:{returnPrice} ";
        }
        public Necklace()
        {
            this.pearlbag._pearls.Sort();
        }
    }
}