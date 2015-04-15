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

            string bandAfter = "before " + Items[index + 1].Name;
            string bandBefore = index > 0 ? "after " + Items[index - 1].Name : "on the first position";

            Console.WriteLine("Band {0} was inserted into the collection at index {1}, {2} and {3}", item.Name, index, bandBefore, bandAfter);
        }

        protected override void RemoveItem(int index)
        {
            var bandToBeRemoved = Items[index].Name;
      
            base.RemoveItem(index);

            Console.WriteLine("Removed {0}, now {1} is at index {2}", bandToBeRemoved, Items[index].Name, index);
        }

        protected override void SetItem(int index, Band item)
        {
            string bandToBeReplaced = Items[index].Name;

            base.SetItem(index, item);

            Console.WriteLine("{0} was replaced with {1} at index {2}", bandToBeReplaced, item.Name, index);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }
    }
}
