using ConsoleApp17.Classes;
using ConsoleApp17.Structs;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ConsoleApp17
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Item sword = new Item("sword", 20, 10);
			Item shield = new Item("shield", 30, 15);
			Item potion = new Item("potion", 5, 1);

			InventoryComponent inventory = new() 
			{ 
				{ sword, 50 },
				{ sword, 50 },
				{ shield, 10 },
				{ potion, 100 }
			};

			//InventoryComponent ic = new((sword, 10),(shield, 20),(shield, 20));

			inventory.Print();

			Console.WriteLine(inventory.GetCount(sword));
			Console.WriteLine(inventory.GetCount(new Item("bow", 15, 5)));

			inventory.SortByCountAscending();
			inventory.SortByCountDescending();

			inventory.Remove(potion, 90);
			inventory.Print();

			inventory.Remove(shield);
			inventory.Print();
		}
	}
}
