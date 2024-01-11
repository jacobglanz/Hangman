﻿using gnuciDictionary;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HangmanSystem
{
    public class Game : INotifyPropertyChanged
    {
        Random rnd = new();

        List<Word> AllWords;
        int _wrongGuesses = 0;
        int _gamesWon = 0;
        int _gamesPlayed = 0;
        string _hint = "";
        string _description = "";

        public static System.Drawing.Color InitialBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
        public static System.Drawing.Color WhiteInitialLetterColor = System.Drawing.Color.White;
        public static System.Drawing.Color GreenWinColor = System.Drawing.Color.FromArgb(46, 204, 113);
        public static System.Drawing.Color RedLossColor = System.Drawing.Color.FromArgb(192, 57, 43);
        public static System.Drawing.Color GrayDisabledColor = System.Drawing.Color.Gray;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Game()
        {
            AllWords = EnglishDictionary.GetAllWords().Where(
                w => w.Value.Length >= 7
                && w.Value.Length <= 11
                && !w.Definition.Contains(w.Value)
                && !string.IsNullOrEmpty(w.Definition)
                && w.Value.All(c => char.IsLetter(c))
            ).ToList();

            for (char c = 'A'; c <= 'Z'; c++)
            {
                AllLetters.Add(new Letter() { PublicValue = c.ToString() });
            }

            StartGame();
        }

        internal Word CurrentWord { get; private set; }

        public List<Letter> WordLetters { get; internal set; } = new();

        public List<Letter> AllLetters { get; private set; } = new();

        public string Hint
        {
            get => _hint;
            private set
            {
                _hint = value;
                InvokePropertyChanged();
            }
        }

        public int WrongGuesses
        {
            get => _wrongGuesses;
            private set
            {
                _wrongGuesses = value;
                InvokePropertyChanged();
            }
        }

        public int GamesPlayed
        {
            get => _gamesPlayed;
            internal set
            {
                _gamesPlayed = value;
                InvokePropertyChanged("Description");
            }
        }

        public int GamesWon
        {
            get => _gamesWon;
            internal set
            {
                _gamesWon = value;
                InvokePropertyChanged("Description");
            }
        }

        public string Description
        {
            get => $"{GamesWon} / {GamesPlayed} words";
        }

        void StartGame()
        {
            if (AllWords.Count > 0)
            {
                CurrentWord = AllWords[rnd.Next(AllWords.Count)];
                CurrentWord.Value = CurrentWord.Value.ToUpper();
                AllWords.Remove(CurrentWord);

                foreach (char c in CurrentWord.Value)
                {
                    WordLetters.Add(new Letter() { PrivateValue = c.ToString() });
                }
                AllLetters.ForEach(l => l.Reset(false));
            }
        }

        public void GuessLetter(string letter)
        {
            letter = letter.ToUpper();
            Letter ltr = AllLetters.FirstOrDefault(l => l.PublicValue == letter);
            ltr.BackColor = WhiteInitialLetterColor;
            if (!ltr.IsEnabled)
            {
                return;
            }
            ltr.IsEnabled = false;
            if (CurrentWord.Value.Contains(letter))
            {
                ltr.Color = GreenWinColor;
                WordLetters.
                    Where(l => l.PrivateValue == letter).ToList().
                    ForEach(l => { l.PublicValue = l.PrivateValue; l.IsEnabled = false; }
                );
            }
            else
            {
                ltr.Color = RedLossColor;
                WrongGuesses += 1;
            }

            if (DetectGameEnd())
            {
                RestartGame();
            }
        }

        private bool DetectGameEnd()
        {
            bool endThisGame = false;

            if (WrongGuesses >= 7)
            {
                WordLetters.ForEach(l => { l.PublicValue = l.PrivateValue; l.IsEnabled = false; });
                endThisGame = true;
            }
            else if (WordLetters.TrueForAll(l => l.PublicValue != ""))
            {
                GamesWon += 1;
                endThisGame = true;
            }

            return endThisGame;
        }

        private async void RestartGame()
        {
            GamesPlayed += 1;
            AllLetters.Where(l => l.IsEnabled).ToList().ForEach(l =>
            {
                l.IsEnabled = false;
                l.BackColor = WhiteInitialLetterColor;
                l.Color = GrayDisabledColor;
            });
            await Task.Delay(2500);
            Hint = "";
            WordLetters.Clear();
            StartGame();
            WrongGuesses = 0;
        }

        public void ReveleHint()
        {
            Hint = CurrentWord.Definition;
        }

        void InvokePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
