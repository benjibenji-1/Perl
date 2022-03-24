using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace
{
    public class Necklace
    {
        public int ID { get; set; }

        public virtual List<Pearl> _pearls { get; set; } = new List<Pearl>();

        public int price { 
            get
            {
                return Price();
            }
            set { }
        }
        public void Sort()
        {
            _pearls.Sort();
        }
        public override string ToString()
        {
            int returnPrice = 0;
            int NumberOfPearls = this._pearls.Count;
            foreach (var item in this._pearls)
            {
                returnPrice += item.Price;
            }
            return $"Necklace {this.ID}: {NumberOfPearls} Pearls, Price: {returnPrice} SEK";
        }
        public void ShowPearls()
        {
            foreach (var item in this._pearls)
            {
                Console.WriteLine($"{item}");
            }
        }
        public int Price()
        {
            int price = 0;
            if (_pearls == null)
            {
                return 0;
            }
            else
            {
                foreach (var pearl in this._pearls)
                {
                    price += pearl.Price;
                }
            }
            return price;
        }
        public static class Factory
        {
            public static Necklace CreateRandom()
            {
                var returnN = new Necklace();
                var rndList = new List<Pearl>();
                var rnd = new Random();
                int pearls = rnd.Next(10, 51);
                for (int i = 0; i < pearls; i++)
                {
                    Pearl pearl = Pearl.Factory.CreateRandomPearl();
                    rndList.Add(pearl);
                }
                returnN._pearls = rndList;
                return returnN;
            }
        }
        public Necklace()
        {
        }
    }
}