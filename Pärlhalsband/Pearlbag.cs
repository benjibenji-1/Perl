using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PearlNecklace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace PearlNecklace
{
    public class Pearlbag
    {
        public int ID { get; set; }
        public virtual List<Pearl> _pearls { get; set; }
        public int numberOfPearls 
        { 
            get 
            { 
                return _pearls.Count;
            }
            set { }
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

        public static class Factory
        {
            public static Pearlbag CreateRandomPearlbag()
            {
                var returnBag = new Pearlbag();
                var rndList = new List<Pearl>();
                var rnd = new Random();
                int pearls = rnd.Next(10, 51);
                for (int i = 0; i < pearls; i++)
                {
                    Pearl pearl = Pearl.Factory.CreateRandomPearl();
                    rndList.Add(pearl);
                }
                returnBag._pearls = rndList;
                return returnBag;
            }
        }
        public Pearlbag()
        {
        }
    }
}
