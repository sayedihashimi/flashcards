// This file is part of SayedHa.Flashcards.
//
// SayedHa.Flashcards is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// SayedHa.Flashcards is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with SayedHa.Flashcards.  If not, see <https://www.gnu.org/licenses/>.
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
