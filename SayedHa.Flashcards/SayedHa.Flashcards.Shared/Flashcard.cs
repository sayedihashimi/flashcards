﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayedHa.Flashcards.Shared {
    public class Flashcard {
        public string QuestionText { get; set; }
        // TODO: Change the name of this property and ShowText
        public string Answer { get; set; }
        public string ImageUrl { get; set; }
        public bool ShowText { get; set; }
        public string Audio { get; set; }
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