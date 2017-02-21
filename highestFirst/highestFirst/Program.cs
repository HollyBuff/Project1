using System;
using System.Collections.Generic;
using System.Linq;

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


		public Tuple<double, List<item>> ehaustiveSearch(List<item> knapsack, int cap)
		{
			double bestValue = 0;
			int bestPosition = 0;
			int size = knapsack.Count();

			var permutations = (long)Math.Pow(2, size);

			for (int i = 0; i < permutations; i++)
			{
				double total = 0;
				double weight = 0;
				for (int j = 0; j < size; j++)
				{
					if (((i >> j) & 1) != 1)
						continue;
					total += knapsack[j].value;
					weight += knapsack[j].cost;
				}
				if (weight <= cap && total > bestValue)
				{
					bestPosition = i;
					bestValue = total;
				}
			}
			var include = new List<item>();
			for (int j = 0; j < size; j++)
			{
				if (((bestPosition >> j) & 1) == 1)
					include.Add(knapsack[j]);
			}
			return Tuple.Create(bestValue, include);
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

			Tuple<double, List<item>> tuple2 = phase.ehaustiveSearch(knapsack.OrderByDescending(x => x.value / x.cost).ToList(), capacity);
			List <item> exList = tuple2.Item2;
			double exhaustive = tuple2.Item1;

			Console.WriteLine("highVal: " + highVal);
			Console.WriteLine("lowCost: " + lowCost);
			Console.WriteLine("ratio: " + ratio);
			Console.WriteLine("partial: " + part);

			Console.Write("exhaustive: " + exhaustive);
			foreach (var thing in exList)
				Console.Write(thing.name + ",");
			Console.ReadKey();
		}
	}
}


