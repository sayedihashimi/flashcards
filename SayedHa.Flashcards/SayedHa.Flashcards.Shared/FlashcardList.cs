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
    public interface IFlashcardList {
        Flashcard GetCurrent();
        Flashcard GetNext();
        Flashcard GetPrevious();
        void MoveNext();
        void MovePrevious();
    }

    public class FlashcardList : IFlashcardList {
        private int _currentIndex = 0;

        protected FlashcardList() { }
        public FlashcardList(IList<Flashcard> flashcards) {
            Debug.Assert(flashcards != null);
            Flashcards = flashcards;
        }

        protected IList<Flashcard> Flashcards {
            get;set;
        }

        public Flashcard GetCurrent() => Flashcards[_currentIndex];

        public Flashcard GetNext() => Flashcards[(_currentIndex + 1) >= Flashcards.Count ? 0 : _currentIndex + 1];

        public Flashcard GetPrevious() => Flashcards[_currentIndex - 1 < 0 ? Flashcards.Count - 1 : _currentIndex - 1];

        public void MoveNext() {
            _currentIndex = _currentIndex + 1 >= Flashcards.Count ? 0 : _currentIndex + 1;
        }

        public void MovePrevious() {
            _currentIndex = _currentIndex - 1 < 0 ? Flashcards.Count - 1 : _currentIndex - 1;
        }
    }

    public class AdditionFlashcardList : FlashcardList {
        public AdditionFlashcardList(int minQuestionValue, int maxQuestionValue, int numberOfCards) : base() {
            Debug.Assert(numberOfCards > 0);
            Debug.Assert(minQuestionValue < maxQuestionValue);

            List<Flashcard> cards = new List<Flashcard>(numberOfCards);
            for(var i = 0; i<numberOfCards; i++) {
                cards.Add(new AdditionFlashcard(minQuestionValue, maxQuestionValue));
            }
            Flashcards = cards;
        }
    }
}
