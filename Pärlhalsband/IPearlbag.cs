using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PearlNecklace;


namespace PearlNecklace
{
    internal interface IPearlbag
    {
        void Sort();

        int Find(Pearl otherPearl); //Hitta pärla, size color shape, om finns ja/nej(kanske index)
    }
}
