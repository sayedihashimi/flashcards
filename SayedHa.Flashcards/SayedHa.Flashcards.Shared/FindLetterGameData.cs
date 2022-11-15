using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayedHa.Flashcards.Shared {
    public class FindLetterGameData {
        public List<FindLetterGameDataItem> LettersToDisplay { get; set; }
        public bool RandomizeLettersToDisplay { get; set; }
        public List<LetterAudioInfo> LettersToAnnounce { get; set; }
        public bool RandomizeLettersToAnnounce { get; set; }

        public FindLetterGameData() :this(false, true) {
        }
        public FindLetterGameData(bool randomizeLettersToDisplay, bool randomizeLettersToAnnounce) {
            RandomizeLettersToDisplay = randomizeLettersToDisplay;
            RandomizeLettersToAnnounce = randomizeLettersToAnnounce;
            Reset();
        }

        private int _letterToAnnounceIndex = 0;

        public LetterAudioInfo LetterToAnnounce {
            get {
                if (LettersToAnnounce?.Count >= _letterToAnnounceIndex) {
                    return LettersToAnnounce[_letterToAnnounceIndex];
                }

                return null;
            }
        }

        public void MoveNextLetterToAnnounce(){
            _letterToAnnounceIndex++;
        }
        public bool HasWon() {
            foreach(var letter in LettersToDisplay) {
                if (!letter.HasBeenSelected) {
                    return false;
                }
            }

            return true;
        }

        public void Reset() {
            _letterToAnnounceIndex = 0;
            LettersToDisplay = new List<FindLetterGameDataItem>();
            LettersToAnnounce = new List<LetterAudioInfo>();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            foreach (var ch in chars) {
                LettersToDisplay.Add(new FindLetterGameDataItem {
                    Letter = ch.ToString(),
                    HasBeenSelected = false
                });
                LettersToAnnounce.Add(new LetterAudioInfo {
                    Letter = ch.ToString(),
                    AudioFilePath = $"/flashcards/media/audio/letter-{ch.ToString().ToLowerInvariant()}.mp3"
                });
            }
            if (RandomizeLettersToDisplay) {
                LettersToDisplay.Shuffle();
            }
            if (RandomizeLettersToAnnounce) {
                LettersToAnnounce.Shuffle();
            }
        }
    }
    public class FindLetterGameDataItem {
        public string Letter { get; set; }
        public bool HasBeenSelected { get; set; }
    }
    public class LetterAudioInfo {
        public string Letter { get; set; }
        public string AudioFilePath { get; set; }
    }
}
