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
        public string SpecialChar { get; set; }
        public bool Enabled { get; set; } = true;
    }
}
