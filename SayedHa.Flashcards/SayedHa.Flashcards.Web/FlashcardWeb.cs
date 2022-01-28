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
using SayedHa.Flashcards.Shared;
using System.Diagnostics;

namespace SayedHa.Flashcards.Web {
    public class FlashcardWeb {
        private readonly HttpClient _httpClient;
        private readonly FlashcardManager _flashcardManager;

        public FlashcardWeb(HttpClient httpClient, FlashcardManager flashcardManager) {
            _httpClient = httpClient;
            _flashcardManager = flashcardManager;
        }

        public string FlashcardFolder { get; set; } = @"flashcards";

        public async Task<List<Flashcard>> GetFlashcardsAsync(string filename) {
            Debug.Assert(!string.IsNullOrEmpty(filename));
            Debug.Assert(_httpClient != null);
            // if filename doesn't end with .json add it
            var cleanedFilename = filename.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ?
                                    filename :
                                    $"{filename}.json";
            var flashcardJson = await _httpClient.GetStringAsync($"flashcards/{cleanedFilename}");

            return _flashcardManager.GetFlashcardsFromJson(flashcardJson);
        }
    }
}
