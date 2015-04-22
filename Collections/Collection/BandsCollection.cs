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

            string bandAfter = (index + 1) >= Items.Count ? "on the last position" : "before " + Items[index + 1].Name;
            string bandBefore = index > 0 ? "after " + Items[index - 1].Name : "on the first position";

            Console.WriteLine("Band {0} was inserted into the collection at index {1}, {2} and {3}", item.Name, index, bandBefore, bandAfter);
        }

        protected override void RemoveItem(int index)
        {
            var bandToBeRemoved = Items[index].Name;

            base.RemoveItem(index);

            var newBandAtIndex = index >= Items.Count ? "it was the last band" : String.Format("now {0} is at index {1}", Items[index].Name, index);

            Console.WriteLine("Removed {0}, {1}", bandToBeRemoved, newBandAtIndex);
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
