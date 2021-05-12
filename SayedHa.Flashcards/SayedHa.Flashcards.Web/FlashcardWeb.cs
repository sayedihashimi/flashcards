using Microsoft.Extensions.Hosting;
using SayedHa.Flashcards.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
