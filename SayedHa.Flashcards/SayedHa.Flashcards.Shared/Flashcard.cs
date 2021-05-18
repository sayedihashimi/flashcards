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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayedHa.Flashcards.Shared {
    public class Flashcard {
        public virtual string QuestionText { get; set; }
        // TODO: Change the name of this property and ShowText
        public virtual string Answer { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual bool ShowText { get; set; }
        public virtual string Audio { get; set; }
        public virtual FlashcardType Type
        {
            get => FlashcardType.Standard;
        }
        [JsonIgnore()]
        public string TempId
        {
            get {
                var extratext = string.Empty;
                extratext += !string.IsNullOrEmpty(QuestionText) ? 
                                $"-{QuestionText}" : 
                                string.Empty;
                extratext += !string.IsNullOrEmpty(Answer) ? 
                                $"-{Answer}" : 
                                string.Empty;


                return $"card-{extratext}";
            }
        }
    }

    public class FlashcardManager {
        public List<Flashcard> GetFlashcardsFromJson(string json) =>
            !string.IsNullOrEmpty(json) ?
                JsonConvert.DeserializeObject<List<Flashcard>>(json) :
                null;

        public string GetFlashcardsAsJson(List<Flashcard> cards) =>
            cards != null ? 
                JsonConvert.SerializeObject(cards) : 
                null;

        public async Task<List<Flashcard>> GetFlashcardsFromJsonFileAsync(string filepath) =>
            !string.IsNullOrEmpty(filepath) ? 
                GetFlashcardsFromJson(await File.ReadAllTextAsync(filepath)) : 
                null;
    }
}
