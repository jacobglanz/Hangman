using HangmanSystem;

namespace HangmanTest
{
    public class HangmanTests
    {
        Random rnd = new();
        List<string> lstAllLetters = new();

        [SetUp]
        public void Setup()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                lstAllLetters.Add(c.ToString());
            }
        }

        [Test]
        public void WhenGuessingALetterItGetsDisabled()
        {
            Game game = new();
            string s = Convert.ToChar(rnd.Next(65, 91)).ToString();
            Letter ltr = game.AllLetters.First(l => l.Value == s);
            TestContext.WriteLine($"Letter {ltr.Value} should get disabled after it's geussed");
            TestContext.WriteLine($"Runing GuessLetter({ltr.Value})");

            game.GuessLetter(s);

            Assert.IsTrue(!ltr.IsEnabled, $"Letter {ltr.Value} was not disabled");
            TestContext.WriteLine($"Letter {ltr.Value} was disabled");
        }

        [Test]
        public void HintShouldBeInitializedToAnEmptyString()
        {
            Game game = new();
            TestContext.WriteLine("Hint should be empty");

            bool hintIsEmpty = string.IsNullOrEmpty(game.Hint);

            Assert.IsTrue(hintIsEmpty, "Hint is not empty");
            TestContext.WriteLine("Hint is empty");
        }

        [Test]
        public void ReveleHint()
        {
            Game game = new();
            Assume.That(string.IsNullOrEmpty(game.Hint), "Hint is not empty");

            game.ReveleHint();
            bool hintIsNotEmpty = !string.IsNullOrEmpty(game.Hint);

            Assert.IsTrue(hintIsNotEmpty, "Hint is empty");
            TestContext.WriteLine("Hint is not empty");
        }

        [Test]
        public void AllLettersCountIs26()
        {
            Game game = new();

            TestContext.WriteLine("AllLetters count should be = 26");

            string msg = $"AllLetters count = {game.AllLetters.Count}";
            Assert.That(game.AllLetters.Count == 26, msg);
            TestContext.WriteLine(msg);
        }

        [Test]
        public void AllLettersIsSortedAtoZ()
        {
            Game game = new();

            int letterIndex = 0;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Letter ltr = game.AllLetters[letterIndex];
                Assert.IsTrue(c.ToString() == ltr.Value, $"Letter should be {c} but is {ltr.Value}");
                letterIndex++;
            }
            TestContext.WriteLine("AllLetters Sorted Correctly");
        }

        [Test]
        public void WordHasBetween7And11Letters()
        {
            Game game = new();
            TestContext.WriteLine("Word should have between 7 and 11 lettes");

            int n = game.WordLetters.Count;

            string msg = $"Word has {n} letters";
            Assert.That(n >= 7 && n <= 11, msg);
            TestContext.WriteLine(msg);
        }

        [Test]
        public void WordLettersPublicValuesAreEmpty()
        {
            Game game = new();
            TestContext.WriteLine("All WordLetters PublicValue should be empty");

            bool empty = game.WordLetters.TrueForAll(l => string.IsNullOrEmpty(l.Value));

            Assert.IsTrue(empty, "Not all WordLetters PublicValue are empty");
            TestContext.WriteLine("All WordLetters PublicValue are empty");
        }
    }
}