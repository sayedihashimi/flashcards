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
            AnswerAudioParts = new List<string>() {
                $"flashcards/media/audio/number-{Answer}.mp3"
            };

            QuestionAudioParts = new List<string>();
            QuestionAudioParts.Add($"flashcards/media/audio/number-{Num1}.mp3");
            QuestionAudioParts.Add($"flashcards/media/audio/math-plus.mp3");
            QuestionAudioParts.Add($"flashcards/media/audio/number-{Num2}.mp3");
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
