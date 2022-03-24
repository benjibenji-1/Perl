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

        public List<Pearl> _pearls { get; set; }
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
            foreach (var pearl in _pearls)
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