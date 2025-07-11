using ConsoleApp17.Structs;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp17.Classes
{
    class InventoryComponent : IEnumerable
    {
        public InventoryComponent(params (Item, int)[] items)
        {
            foreach (var item in items)
            {
                Add(item.Item1, item.Item2);
            }
        }
        public IEnumerator<KeyValuePair<Item, int>> GetEnumerator()
        {
            foreach (var item in Items)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Dictionary<Item, int> Items { get; private set; } = [];
        public void Add(Item item, int count = 1)
        {
            if (!Items.TryAdd(item, count))
            {
                Items[item] += count;
            }
        }
        public void Remove(Item item, int count = 0)
        {
            if (!Items.TryGetValue(item, out int itemCount))
            {
                throw new ArgumentException("Элемента нет в инвентаре", nameof(item));
            }
            if (itemCount < count)
            {
                throw new ArgumentException("Недостаточно предметов в инвентаре", nameof(item));
            }
            if (count == 0 || itemCount == count)
            {
                Items.Remove(item);
                return;
            }
            Items[item] -= count;
        }
        public void Print()
        {
            foreach (var i in Items)
            {
                Console.WriteLine(i.Key.name + " " + i.Value);
            }
        }
        public int GetCount(Item item)
        {
            if (Items.TryGetValue(item, out int itemCount))
            {
                return itemCount;
            }
            return 0;
        }
        public void SortByCountAscending()
        {
            Items = Items.OrderBy(x => x.Value).ToDictionary();
        }
        public void SortByCountDescending()
        {
            Items = Items.OrderByDescending(x => x.Value).ToDictionary();            
        }

        
    }
}
