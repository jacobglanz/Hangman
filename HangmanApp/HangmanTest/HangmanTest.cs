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
        public void PlayGame()
        {
            Game game = new();

            string desc = game.Description;
            do
            {
                string c = Convert.ToChar(rnd.Next(65, 91)).ToString();
                if (game.WordLetters.Count(l => l.PublicValue == c) == 0)
                {
                    game.GuessLetter(c);
                }
            }
            while (game.Description == desc);
        }

        [Test]
        public void RestartGame()
        {
            Game game = new();

            string desc = game.Description;
            do
            {
                string c = Convert.ToChar(rnd.Next(65, 91)).ToString();
                if (game.WordLetters.Count(l => l.PublicValue == c) == 0)
                {
                    game.GuessLetter(c);
                }
            }
            while (game.Description == desc);
        }

        [Test]
        public void WhenGuessingALetterItGetsDisabled()
        {
            Game game = new();
            string s = Convert.ToChar(rnd.Next(65, 91)).ToString();
            Letter ltr = game.AllLetters.First(l => l.PublicValue == s);
            TestContext.WriteLine($"Letter {ltr.PublicValue} should get disabled after it's geussed");
            TestContext.WriteLine($"Runing GuessLetter({ltr.PublicValue})");

            game.GuessLetter(s);

            Assert.IsTrue(!ltr.IsEnabled, $"Letter {ltr.PublicValue} was not disabled");
            TestContext.WriteLine($"Letter {ltr.PublicValue} was disabled");
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
                Assert.IsTrue(c.ToString() == ltr.PublicValue, $"Letter should be {c} but is {ltr.PublicValue}");
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

            bool empty = game.WordLetters.TrueForAll(l => string.IsNullOrEmpty(l.PublicValue));

            Assert.IsTrue(empty, "Not all WordLetters PublicValue are empty");
            TestContext.WriteLine("All WordLetters PublicValue are empty");
        }

        [Test]
        public void AllLettersIsEnabledIsTrue()
        {

        }

    }
}