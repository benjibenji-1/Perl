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
    class Pearlbag
    {

        public List<Pearl> _pearls = new List<Pearl>();
        public int numberOfPearls 
        { 
            get 
            { 
                return _pearls.Count;
            } 
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
            for (int i = 0; i < numberOfPearls; i++)
            {
                _pearls.Add(new Pearl());
            }
        }

    }
}
