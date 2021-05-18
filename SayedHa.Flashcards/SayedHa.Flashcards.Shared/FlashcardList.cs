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
        private IList<Flashcard> _flashcards;
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
