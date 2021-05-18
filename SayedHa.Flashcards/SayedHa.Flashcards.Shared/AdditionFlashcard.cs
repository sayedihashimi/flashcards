using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayedHa.Flashcards.Shared
{
    public class AdditionFlashcard : Flashcard
    {
        public AdditionFlashcard(int minValue, int maxValue): base() {
            var random = new Random();
            Num1 =  random.Next(minValue, maxValue);
            Num2 = random.Next(minValue, maxValue);
            QuestionText = $"{Num1} + {Num2}";
            Answer = $"{Num1 + Num2}";
            Audio = $"flashcards/media/audio/number-{Answer}.wav";
        }

        public int Num1 { get; private set; }
        public int Num2 { get; private set; }
        public override string QuestionText {
            get;
            set;
        }

        public override FlashcardType Type { get => FlashcardType.Addition; }
    }
}
