using System;
using System.Collections.Generic;
using System.Linq;

public class phase1
{
	public struct item{
		public string name;
		public decimal cost;
		public decimal value;
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

	public decimal greedySearch(List<item> knapsack, int cap)
	{
		decimal soFar = 0, totalCost = 0;

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

	public decimal partial(List<item> knapsack, int cap)
	{
		decimal soFar = 0, totalCost = 0;

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

	public static void Main(string[] args)
	{
		phase1 phase = new phase1();
		List<item> knapsack = new List<item>();

		string filename;
		Console.Write("enter the filename: ");
		filename = Console.ReadLine();

		Tuple<int, List<item>> tuple = phase.CSVin(filename);

		int capacity = tuple.Item1;
		knapsack = tuple.Item2;

		decimal highVal = phase.greedySearch(knapsack.OrderByDescending(x => x.value).ToList(), capacity);
		decimal lowCost = phase.greedySearch(knapsack.OrderBy(x => x.cost).ToList(), capacity);
		decimal ratio = phase.greedySearch(knapsack.OrderByDescending(x => x.value / x.cost).ToList(), capacity);
		decimal part = phase.partial(knapsack.OrderByDescending(x => x.value / x.cost).ToList(), capacity);

		Console.WriteLine("highVal: " + highVal);
		Console.WriteLine("lowCost: " + lowCost);
		Console.WriteLine("ratio: " + ratio);
		Console.WriteLine("partial: " + part);
		Console.ReadKey();
	}
}



