using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace
{
    class Necklace
    {
        public int ID { get; set; }

        public Pearlbag pearlBag = Pearlbag.Factory.CreateRandomPearlbag();
        public int price { 
            get
            {
                return Price();
            }
            set { }
        }

        public void Sort()
        {
            pearlBag._pearls.Sort();
        }

        public override string ToString()
        {
            string returnString = "";
            int returnPrice = 0;
            foreach (var item in this.pearlBag._pearls)
            {
                returnString += $"{item} ";
                returnPrice += item.Price;
            }
            return $"{returnString}\n Total price of necklace:{returnPrice} ";
        }

        public int Price()
        {
            int price = 0;
            foreach (var pearl in pearlBag._pearls)
            {
                price += pearl.Price;
            }
            return price;
        }

        public Necklace()
        {
        }
    }
}