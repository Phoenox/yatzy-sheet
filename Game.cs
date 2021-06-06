using System.Collections.Generic;
using System.Linq;

namespace Yatzysheet
{
	public class Game
	{
		public List<GameColumn> Columns { get; } = new List<GameColumn>();

		public Game(int numberOfColumns)
		{
			for (int i = 0; i < numberOfColumns; i++)
				Columns.Add(new GameColumn());
		}

		public int Total
		{
			get { return Columns.Sum(column => column.ColumnSum); }
			set { }
		}
	}

	public class GameColumn
	{
		public int? Ones { get; set; }
		public int? Twos { get; set; }
		public int? Threes { get; set; }
		public int? Fours { get; set; }
		public int? Fives { get; set; }
		public int? Sixes { get; set; }

		public int? Triple { get; set; }
		public int? Quadruple { get; set; }
		public int? FullHouse { get; set; }
		public int? SmallStreet { get; set; }
		public int? BigStreet { get; set; }
		public int? Yatzy { get; set; }
		public int? Chance { get; set; }

		public int ColumnSum
		{
			get { return TopSumWithBonus + LowSum; }
			set { }
		}

		public int TopSumWithBonus {
			get { return TopSum + Bonus; }
			set { }
		}

		public int TopSum {
			get
			{
				var sum = 0;
				sum += Ones ?? 0;
				sum += Twos ?? 0;
				sum += Threes ?? 0;
				sum += Fours ?? 0;
				sum += Fives ?? 0;
				sum += Sixes ?? 0;
				return sum;
			}
			set { }
		}

		public int Bonus {
			get { return TopSum >= 63 ? 35 : 0; }
			set { }
		}

		public int LowSum {
			get
			{
				var sum = 0;
				sum += Triple ?? 0;
				sum += Quadruple ?? 0;
				sum += FullHouse ?? 0;
				sum += SmallStreet ?? 0;
				sum += BigStreet ?? 0;
				sum += Yatzy ?? 0;
				sum += Chance ?? 0;
				return sum;
			}
			set { }
		}
	}
}
