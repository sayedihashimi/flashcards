using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayedHa.Flashcards.Shared {
    public class NumberTableGame {
        private readonly int _numberOfItems;
        private List<NumberTableGameItem> _items;

        public int NumberOfItems {
            get {
                return _numberOfItems;
            }
        }
        public NumberTableGame(int numItems) {
            Debug.Assert(numItems > 0);
            _numberOfItems = numItems;

            Items = new List<NumberTableGameItem>(_numberOfItems);
            for(int i = 0; i < _numberOfItems; i++) {
                Items.Add(new NumberTableGameItem(i + 1));
            }
            Items.Shuffle();
        }

        protected void InitIndexes() {
            Debug.Assert(_numberOfItems > 0);
            var ntgItems = new List<NumberTableGameItem>(_numberOfItems);
            // randomize the index list now
            ntgItems.Shuffle();
            _items = ntgItems;
            Items = ntgItems;
        }
        public List<NumberTableGameItem> Items { get; protected set; }
    }

    public class NumberTableGameItem {
        public NumberTableGameItem(int value) {
            Value = value;
        }
        public int Value { get; protected set; }
        public bool HasBeenSelected { get; set; }
    }
}
