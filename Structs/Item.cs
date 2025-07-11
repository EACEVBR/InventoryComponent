namespace ConsoleApp17.Structs
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
}
