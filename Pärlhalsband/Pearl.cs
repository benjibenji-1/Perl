using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PearlNecklace;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PearlNecklace
{
	public enum PearlColor { Black, White, Pink }
	public enum PearlShape { Round, Tear }
	public enum PearlType { Freshwater, Saltwater }
	public class Pearl
	{
		//const int MinPearlSize = 5;
		//const int MaxPearlSize = 25;
		[Key]
		[Column("ID")]
		public int ID { get; set; }

		[Column("NecklaceID")]
		[ForeignKey(nameof(necklaceID))]
		public int necklaceID { get; set; }
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
            set
            {

            }
		}

		public int CompareTo(Pearl other)
        {
			if (this.Size != other.Size)
				return this.Size.CompareTo(other.Size);
			if (this.Color != other.Color)
				return this.Color.CompareTo(other.Color);

			return this.Shape.CompareTo(other.Shape);
        }
		public void RandomInit()
		{
			var rnd = new Random();
			Size = rnd.Next(5,26);
			Color = (PearlColor)rnd.Next((int)PearlColor.Black, (int)PearlColor.Pink + 1);
			Shape = (PearlShape)rnd.Next((int)PearlShape.Round, (int)PearlShape.Tear + 1);
			Type = (PearlType)rnd.Next((int)PearlType.Freshwater, (int)PearlType.Saltwater + 1);
		}

		public static class Factory
		{
			public static Pearl CreateRandomPearl()
			{
				var p = new Pearl();
				p.RandomInit();
				return p;
			}
		}

		public override string ToString()
		{
			return $"{Size}mm\n{Color}\n{Shape}\n{Type}\n{Price} sek\n \n";
		}

		public bool Equals(Pearl other) => (this.Size, this.Color, this.Shape, this.Type) == (other.Size, other.Color, other.Shape, other.Type);
		public override bool Equals(object obj) => Equals(obj as Pearl);
		public override int GetHashCode() => (Size, Color, Shape, Type).GetHashCode();

	}
}
