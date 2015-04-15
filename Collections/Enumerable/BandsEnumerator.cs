using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections.Enumerable
{
    public class BandsEnumerator : IEnumerator<Band>
    {
        public Band Current { get { return currentBand; } }
        object IEnumerator.Current
        {
            get { return Current; }
        }

        private Band[] collection;
        private int currentIndex;
        private Band currentBand;

        public BandsEnumerator(IEnumerable<Band> bandsCollection)
        {
            collection = bandsCollection.ToArray();
            //până la primul apel al "MoveNext", enumeratorul este poziționat înainte de primul element
            currentIndex = -1;
            currentBand = null;
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            currentIndex++;

            if (currentIndex >= collection.Count())
            {
                return false;
            }

            currentBand = collection[currentIndex];
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
