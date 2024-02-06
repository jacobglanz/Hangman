namespace HangmanAppMAUI;
using HangmanSystem;
using Microsoft.Maui.Graphics.Text;

public partial class Hangman : ContentPage
{
    Game activeGame;
    List<Button> lstButtons = new();
    List<Game> lstGames = new() { new Game(), new Game(), new Game() };

    public Hangman()
    {
        InitializeComponent();

        activeGame = lstGames[0];
        BindingContext = activeGame;

        GameRoom1Rb.BindingContext = lstGames[0];
        GameRoom2Rb.BindingContext = lstGames[1];
        GameRoom3Rb.BindingContext = lstGames[2];

        lstGames.ForEach(g => g.PropertyChanged += Game_PropertyChanged);

        this.Loaded += Hangman_Loaded;
    }

    private void SetGameBoard()
    {
        SetAllLettes();
        SetWordLetters();
        SetIamge();
    }

    private void SetAllLettes()
    {
        foreach (Button b in AllLetters.Children)
        {
            b.Clicked += LetterBtn_Clicked;
            b.SetBinding(BackgroundColorProperty, nameof(Letter.BackColorMaui));
            b.SetBinding(Button.TextColorProperty, nameof(Letter.ColorMaui));
            b.SetBinding(Button.BorderColorProperty, nameof(Letter.ColorMaui));
            b.SetBinding(IsEnabledProperty, nameof(Letter.IsEnabled));
        }
        AllLetters.Children.ToList().ForEach(l => lstButtons.Add((Button)l));
    }

    private void SetWordLetters()
    {
        WordLetterLabels.Clear();
        foreach (Letter l in activeGame.WordLetters)
        {
            var g = new Grid()
            {
                BindingContext = activeGame.WordLetters[WordLetterLabels.Children.Count],
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
            bv.SetBinding(IsVisibleProperty, nameof(Letter.IsEnabled));
            g.Add(bv);
            WordLetterLabels.Add(g);
        }
    }

    private void SetIamge()
    {
        Img.Source = activeGame.WrongGuesses == 0 ? "s0p.gif" : $"s{activeGame.WrongGuesses}p.png";
    }



    private void LetterBtn_Clicked(object sender, EventArgs e)
    {
        if (sender is Button b)
        {
            activeGame.GuessLetter(b.Text);
        }
    }
    private void HintBtn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(HintLbl.Text))
        {
            activeGame.ReveleHint();
        }
    }
    private void GameRoomRb_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton rb && rb.IsChecked && rb.BindingContext is Game game)
        {
            activeGame = game;
            BindingContext = activeGame;
            SetGameBoard();
        }
    }
    private void Game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Game.WrongGuesses))
        {
            SetIamge();
        }
    }
    private void Hangman_Loaded(object sender, EventArgs e)
    {
        SetGameBoard();
    }
}