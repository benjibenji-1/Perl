using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PearlNecklace;


namespace PearlNecklace
{
	internal class Pearl : IPearl
	{
		public int Size { get; set; }
		public PearlColor Color { get; set; }
		public PearlShape Shape { get; set; }
		public PearlType Type { get; set; }
		public int Price { get
			{
				if (Type == PearlType.Saltwater)
				{
					return (Size * 50) * 2;
				}
				else
				{
					return Size * 50;
				}
			}
		}

		public int CompareTo(IPearl other)
        {
			if (Size != other.Size)
				return Size.CompareTo(other.Size);
			if (Color != other.Color)
				return Color.CompareTo(other.Color);
			return Shape.CompareTo(other.Shape);
        }
		public void RandomInit()
		{
			var rnd = new Random();
			Size = rnd.Next(5,26);
			Color = (PearlColor)rnd.Next((int)PearlColor.Black, (int)PearlColor.Pink + 1);
			Shape = (PearlShape)rnd.Next((int)PearlShape.Round, (int)PearlShape.Tear + 1);
			Type = (PearlType)rnd.Next((int)PearlType.Freshwater, (int)PearlType.Saltwater + 1);
		}

		public Pearl()
		{
			RandomInit();
		}

		public override string ToString()
		{
			return $"{Size}mm\n{Color}\n{Shape}\n{Type}\n{Price} sek\n \n";
		}

        public bool Equals(IPearl other)
        {
			return (Size, Color, Shape, Type) == (other.Size, other.Color, other.Shape, other.Type);
		}
	}
}
