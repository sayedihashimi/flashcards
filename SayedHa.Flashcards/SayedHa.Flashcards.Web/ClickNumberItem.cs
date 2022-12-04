using SayedHa.Flashcards.Shared;
using System.Diagnostics;

namespace SayedHa.Flashcards.Web {
    public class ClickNumberItem {
        public int Number { get; set; }
        public bool Enabled { get; set; } = true;
        public bool CurrentlySelected { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
    }

    public class SpecialCharItem {
        public SpecialCharItem(string specialChar) {
            Debug.Assert(!string.IsNullOrEmpty(specialChar));
            SpecialChar = specialChar;
        }
        protected SpecialCharacters specialCharacters { get; set; }
        public string SpecialChar { get; set; }
        public bool Enabled { get; set; } = true;


    }
    public class SpecialCharacters {
        public SpecialCharacters() {
            specialChars = new List<string>
            {
                "&#x1F34D;","&#x1F347;","&#x1F348;","&#x1F349;","&#x1F34A;","&#x1F34B;","&#x1F96D;","&#x1F34E;","&#x1F34F;",
                "&#x1F350;","&#x1F352;","&#x1F353","&#x1F345","&#x1F966","&#x1F344","&#x1F95E","&#x1F9C0","&#x1F354","&#x1F35F",
                "&#x1F355","&#x1F37F","&#x1F366","&#x1F367","&#x1F368","&#x1F697","&#x1F3CE","&#x1F6F9","&#x1231A","&#x1FA90",
                "&#x1F383","&#x1F3C0","&#x1F3C8","&#x1F3B8","&#x1F4EA","&#x1F923","&#x1F601","&#x1F600","&#x1F912","&#x1F4A9"
            };
            specialChars.Shuffle();
        }

        private List<string> specialChars;
        private int currentIndex = 0;
        public string CurrentSpecialChar => specialChars[currentIndex % (specialChars.Count - 1)];
        public void MoveNext() {
            currentIndex = currentIndex + 1 < specialChars.Count ? currentIndex + 1 : 0;
        }
    }
}
