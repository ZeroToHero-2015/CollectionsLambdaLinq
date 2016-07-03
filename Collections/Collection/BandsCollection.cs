using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections.Collection
{
    public class BandsCollection : Collection<Band>
    {
        public BandsCollection(IEnumerable<Band> bands) : base(bands.ToList()) { }

        protected override void InsertItem(int index, Band item)
        {
            base.InsertItem(index, item);

            string bandAfter = (index + 1) >= Items.Count ? "on the last position" : $"before {Items[index + 1].Name}";
            string bandBefore = index > 0 ? $"after {Items[index - 1].Name}" : "on the first position";

            Console.WriteLine($"Band {item.Name} was inserted into the collection at index {index}, {bandBefore} and {bandAfter}");
        }

        protected override void RemoveItem(int index)
        {
            var bandToBeRemoved = Items[index].Name;

            base.RemoveItem(index);

            var newBandAtIndex = index >= Items.Count ? "it was the last band" : string.Format($"now {Items[index].Name} is at index {index}");

            Console.WriteLine($"Removed {bandToBeRemoved}, {newBandAtIndex}");
        }

        protected override void SetItem(int index, Band item)
        {
            string bandToBeReplaced = Items[index].Name;

            base.SetItem(index, item);

            Console.WriteLine($"{bandToBeReplaced} was replaced with {item.Name} at index {index}");
        }

        protected override void ClearItems()
        {
            base.ClearItems();         
        }
    }
}
