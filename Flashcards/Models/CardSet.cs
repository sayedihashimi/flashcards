using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Flashcards.Models {
    public class CardSet {
        public string Name {
            get;
            set;
        }
        public List<Card> Cards {
            get;
            set;
        }

        public static CardSet BuildFromJson(string json){
            CardSet result = JsonConvert.DeserializeObject<CardSet>(json);
            return result;
        }
    }
}
