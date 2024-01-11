namespace HangmanAppMAUI;
using HangmanSystem;

public partial class Hangman : ContentPage
{
    Game game = new();
    public Hangman()
    {
        InitializeComponent();
        BindingContext = game;
        SetWordLetters();
        game.PropertyChanged += Game_PropertyChanged;
    }

    private void SetWordLetters()
    {
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

    private void Game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(game.WrongGuesses))
        {
            if (game.WrongGuesses == 0)
            {
                WordLetterLabels.Clear();
                SetWordLetters();
                Img.Source = "s0p.gif";
            }
            else
            {
                Img.Source = $"s{game.WrongGuesses}p.png";
            }
        }
    }

    private void GuessLetter(string letter)
    {
        game.GuessLetter(letter);
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
        game.ReveleHint();
    }
}