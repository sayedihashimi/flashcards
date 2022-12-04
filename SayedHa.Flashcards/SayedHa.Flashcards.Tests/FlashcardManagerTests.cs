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
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace SayedHa.Flashcards.Tests {
    public class FlashcardManagerTests {
        [Fact]
        public void TestGetAsJson() {
            var flashcards = new List<Flashcard>() {
                new Flashcard {
                    Answer="some text1",
                    ImageUrl = "https://demo.com/someimage1.png"
                },
                new Flashcard {
                    Answer="some text2",
                    ImageUrl = "https://demo.com/someimage2.png"
                },
                new Flashcard {
                    Answer="some text3",
                    ImageUrl = "https://demo.com/someimage3.png"
                }
            };

            var fm = new FlashcardManager();
            var result = fm.GetFlashcardsAsJson(flashcards);
            Assert.True(!string.IsNullOrEmpty(result));
            Assert.True(result.Length > 0);
            Assert.True(result.IndexOf("some text1") < result.IndexOf("some text2"));
            Assert.True(result.IndexOf("some text2") < result.IndexOf("some text3"));
            Assert.True(result.IndexOf("https://demo.com/someimage1.png") < result.IndexOf("https://demo.com/someimage3.png"));
        }

        [Fact]
        public async Task TestGetFlashcardsFromJsonFileAsync() {
            var assemblyDir = new FileInfo(new System.Uri(Assembly.GetExecutingAssembly().Location).LocalPath).Directory.FullName;
            var filepath = Path.Join(assemblyDir, "sample-files", "sample1.json");

            if (!File.Exists(filepath)) {
                throw new TestException($"file not found at {filepath}");
            }

            var fm = new FlashcardManager();
            var result = await fm.GetFlashcardsFromJsonFileAsync(filepath);
            Assert.NotNull(result);
            Assert.True(result.Count == 10);
            Assert.True(string.Equals("some text1", result[0].QuestionText));
        }
    }
}
