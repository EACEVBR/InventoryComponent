using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ConsoleApp17
{
	struct Item
	{
		public string name;
		public float cost;
		public float weight;
		public Item(string name, float cost, float weight)
		{
			this.name = name;
			this.cost = cost;
			this.weight = weight;
		}
	}
	class InventoryComponent 
	{ 
		private Dictionary< Item, int> items = new(); 
		public Dictionary<Item, int> Items { get => items; }

		public void Add(Item item, int count = 1) 
		{
			if (items.ContainsKey(item))
			{
				items[item] += count;
			}
			else 
			{ 
				items.Add(item, count);
			}
		}
		public void Remove(Item item, int count = 0) 
		{
			if (!items.ContainsKey(item))
			{
				throw new ArgumentException("Элемента нет в инвентаре", nameof(item));
			}
			if (items[item] < count) 
			{
				throw new ArgumentException("Не достаточно предметов в инвентаре", nameof(item));
			}
			if (count == 0 || items[item] == count)
			{
				items.Remove(item);
				return;
			}
			items[item] -= count;
		}
		public void PrintInventory()
		{
			foreach (var i in items)
			{
				Console.WriteLine(i.Key.name + " " + i.Value);
			}
		}
		public void PrintCount(Item item)
		{
			if (items.ContainsKey(item))
			{
				Console.WriteLine(items[item]);
			}
			else
			{
				Console.WriteLine(0);
			}
		}
		public void PrintSortedByCountAscending()
		{
			foreach (var i in items.OrderBy(x => x.Value))
			{
				Console.WriteLine(i.Key.name + " " + i.Value);
			}
		}

		public void PrintSortedByCountDescending()
		{
			foreach (var i in items.OrderByDescending(x => x.Value))
			{
				Console.WriteLine(i.Key.name + " " + i.Value);
			}
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Item sword = new Item("sword", 20, 10);
			Item shield = new Item("shield", 30, 15);
			Item potion = new Item("potion", 5, 1);

			InventoryComponent inventory = new InventoryComponent();

			inventory.Add(sword, 50);
			inventory.Add(shield, 10);
			inventory.Add(potion, 100);

			inventory.PrintInventory();

			inventory.PrintCount(sword);
			inventory.PrintCount(new Item("bow", 15, 5));

			inventory.PrintSortedByCountAscending();
			inventory.PrintSortedByCountDescending();

			inventory.Remove(potion, 90);
			inventory.PrintInventory();

			inventory.Remove(shield);
			inventory.PrintInventory();
		}
	}
}
