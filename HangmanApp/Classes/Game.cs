﻿using gnuciDictionary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HangmanSystem
{
    public class Game : INotifyPropertyChanged
    {
        private static Random rnd = new();

        private static List<Word> AllWords = new();
        private static int _gamesWon = 0;
        private static int _gamesPlayed = 0;
        private int _wrongGuesses = 0;
        private string _hint = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        public Game()
        {
            SetAllLetters();;
            AllWords = EnglishDictionary.GetAllWords().Where(
                w => w.Value.Length >= 7
                && w.Value.Length <= 11
                && !w.Definition.Contains(w.Value)
                && !string.IsNullOrEmpty(w.Definition)
                && w.Value.All(c => char.IsLetter(c))
            ).ToList();

            StartNewGame();
        }

        public static System.Drawing.Color ColorInitialBack = System.Drawing.Color.FromArgb(52, 152, 219);
        public static System.Drawing.Color ColorWhiteInitialLetter = System.Drawing.Color.White;
        public static System.Drawing.Color ColorGreenWin = System.Drawing.Color.FromArgb(46, 204, 113);
        public static System.Drawing.Color ColorRedLoss = System.Drawing.Color.FromArgb(192, 57, 43);
        public static System.Drawing.Color ColorGrayDisabled = System.Drawing.Color.Gray;
        public static int GamesPlayed
        {
            get => _gamesPlayed;
            internal set
            {
                _gamesPlayed = value;
            }
        }
        public static int GamesWon
        {
            get => _gamesWon;
            internal set
            {
                _gamesWon = value;
            }
        }
        public List<Letter> AllLetters { get; private set; } = SetAllLetters();

        private static List<Letter> SetAllLetters()
        {
            List<Letter> letters = new();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                letters.Add(new Letter() { Value = c.ToString() });
            }
            return letters;
        }

        internal Word CurrentWord { get; private set; }
        public List<Letter> WordLetters { get; internal set; } = new();
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
                InvokePropertyChanged("Description");
            }
        }

        public string Description
        {
            get => $"{7 - WrongGuesses} tries left\n{GamesWon}/{GamesPlayed} words";
        }

        private void StartNewGame()
        {
            if (AllWords.Count > 0)
            {
                CurrentWord = AllWords[rnd.Next(AllWords.Count)];
                CurrentWord.Value = CurrentWord.Value.ToUpper();
                AllWords.Remove(CurrentWord);
                WordLetters.Clear();
                CurrentWord.Value.ToList().ForEach(c => WordLetters.Add(new Letter()));
                AllLetters.ForEach(l =>
                {
                    l.IsEnabled = true;
                    l.BackColor = ColorInitialBack;
                    l.Color = ColorWhiteInitialLetter;
                });
                this.WrongGuesses = 0;
            }
            else
            {
                throw new Exception("I don't have any other words left for you 😢");
            }
        }

        public void GuessLetter(string letter)
        {
            letter = letter.ToUpper();
            Letter ltr = AllLetters.FirstOrDefault(l => l.Value == letter);
            ltr.BackColor = ColorWhiteInitialLetter;

            if (ltr.IsEnabled)
            {
                ltr.IsEnabled = false;
                if (CurrentWord.Value.Contains(letter))
                {
                    ltr.Color = ColorGreenWin;
                    AddValuesToWordLetter(letter);
                }
                else
                {
                    ltr.Color = ColorRedLoss;
                    WrongGuesses += 1;
                }

                if (DetectGameEnd())
                {
                    GamesPlayed++;
                    EndGame();
                }
            }
        }

        bool DetectGameEnd()
        {
            if (WrongGuesses == 7)
            {
                AddValuesToWordLetter();
                return true;
            }
            else if (WordLetters.TrueForAll(l => l.Value != ""))
            {
                GamesWon += 1;
                return true;
            }

            return false;
        }

        private async void EndGame()
        {
            AllLetters.Where(l => l.IsEnabled).ToList().ForEach(l =>
            {
                l.IsEnabled = false;
                l.BackColor = ColorWhiteInitialLetter;
                l.Color = ColorGrayDisabled;
            });
            await Task.Delay(2500);
            StartNewGame();
        }

        public void ReveleHint()
        {
            Hint = CurrentWord.Definition;
        }

        private void AddValuesToWordLetter(string letter = "")
        {
            int i = 0;
            CurrentWord.Value.ToList().ForEach(l =>
            {
                if (string.IsNullOrEmpty(letter) || l.ToString() == letter)
                {
                    Letter wl = WordLetters[i];
                    wl.Value = l.ToString();
                    wl.IsEnabled = false;
                }
                i++;
            });
        }

        void InvokePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
