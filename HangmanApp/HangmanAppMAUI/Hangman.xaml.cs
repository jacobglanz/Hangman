namespace HangmanAppMAUI;
using HangmanSystem;
using Microsoft.Maui.Graphics.Text;

public partial class Hangman : ContentPage
{
    Game game;
    public Hangman()
    {
        InitializeComponent();
        SetUpPage();
        StartNewGame();
    }

    private void SetUpPage()
    {
        foreach(Button b in AllLetters.Children)
        {
            Letter ltr = Game.AllLetters[AllLetters.IndexOf(b)];
            b.Clicked += LetterBtn_Clicked;
            b.BindingContext = ltr;
            b.SetBinding(BackgroundColorProperty, nameof(Letter.BackColorMaui));
            b.SetBinding(Button.TextColorProperty, nameof(Letter.ColorMaui));
            b.SetBinding(Button.BorderColorProperty, nameof(Letter.ColorMaui));
            b.SetBinding(IsEnabledProperty, nameof(Letter.IsEnabled));
        }
    }

    private void StartNewGame()
    {
        game = new Game();
        BindingContext = game;
        game.PropertyChanged += Game_PropertyChanged;
        game.GameEnded += Game_GameEnded;
        SetWordLetters();
    }

    private void SetWordLetters()
    {
        WordLetterLabels.Clear();
        foreach (Letter l in game.WordLetters)
        {
            var g = new Grid()
            {
                BindingContext = game.WordLetters[WordLetterLabels.Children.Count],
                WidthRequest = 30,
                HeightRequest = 30,
            };
            Label lbl = new()
            {
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                Padding = 0,
            };
            lbl.SetBinding(Label.TextProperty, nameof(Letter.Value));
            g.Add(lbl);
            BoxView bv = new()
            {
                BackgroundColor = Colors.Black,
                HeightRequest = 4,
                VerticalOptions = LayoutOptions.End
            };
            bv.SetBinding(BoxView.IsVisibleProperty, nameof(Letter.IsEnabled));
            g.Add(bv);
            WordLetterLabels.Add(g);
        }
    }

    private void ChangeImage()
    {
        Img.Source = game.WrongGuesses == 0 ? "s0p.gif" : $"s{game.WrongGuesses}p.png";
    }

    private void GuessLetter(string letter)
    {
        game.GuessLetter(letter);
    }

    private void ReveleHint()
    {
        game.ReveleHint();
    }

    private void Game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(game.WrongGuesses))
        {
            ChangeImage();
        }
    }

    private void Game_GameEnded(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        StartNewGame();
    }

    private void LetterBtn_Clicked(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            GuessLetter(b.Text);
        }
    }

    private void HintBtn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(HintLbl.Text))
        {
            ReveleHint();
        }
    }

}