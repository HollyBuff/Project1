using System;
using System.Collections.Generic;
using System.Linq;
//using treeSort;


namespace first
{
	public class phase1
	{
		public struct item
		{
			public string name;
			public double cost;
			public double value;
		}

		public Tuple<int, List<item>> CSVin(string filename)
		{
			List<item> knapsack = new List<item>();

			string[] lines = System.IO.File.ReadAllLines(@filename);

			int cap;
			cap = int.Parse(lines[0]);

			foreach (var stuff in lines.Skip(1))
			{
				var temp = stuff.Split(',');

				item thing;

				thing.name = temp[0];
				thing.cost = int.Parse(temp[1]);
				thing.value = int.Parse(temp[2]);
				knapsack.Add(thing);
			}

			return Tuple.Create(cap, knapsack);
		}

		public double greedySearch(List<item> knapsack, int cap)
		{
			double soFar = 0, totalCost = 0;

			foreach (var next in knapsack)
			{
				if ((totalCost += next.cost) <= cap)
				{
					soFar += next.value;
				}
				else
					break;
			}
			return soFar;
		}

		public double partial(List<item> knapsack, int cap)
		{
			double soFar = 0, totalCost = 0;

			foreach (var next in knapsack)
			{
				if ((totalCost + next.cost) <= cap)
				{
					totalCost += next.cost;
					soFar += next.value;
				}
				else
				{
					soFar += ((next.value * (cap - totalCost)) / next.cost);
					break;
				}
			}
			return soFar;
		}

		public static void Main()
		{
			phase1 phase = new phase1();
			List<item> knapsack = new List<item>();

			string filename;
			Console.Write("enter the filename: ");
			filename = Console.ReadLine();

			Tuple<int, List<item>> tuple = phase.CSVin(filename);

			int capacity = tuple.Item1;
			knapsack = tuple.Item2;


			//tree = makeTree(knapsack);

			double highVal = phase.greedySearch(knapsack.OrderByDescending(x => x.value).ToList(), capacity);
			double lowCost = phase.greedySearch(knapsack.OrderBy(x => x.cost).ToList(), capacity);
			double ratio = phase.greedySearch(knapsack.OrderByDescending(x => x.value / x.cost).ToList(), capacity);
			double part = phase.partial(knapsack.OrderByDescending(x => x.value / x.cost).ToList(), capacity);

			Console.WriteLine("highVal: " + highVal);
			Console.WriteLine("lowCost: " + lowCost);
			Console.WriteLine("ratio: " + ratio);
			Console.WriteLine("partial: " + part);
			Console.ReadKey();
		}
	}
}


