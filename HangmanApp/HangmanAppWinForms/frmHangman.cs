using HangmanSystem;

namespace HangmanApp
{
    public partial class frmHangman : Form
    {
        Game game = new();
        List<Button> lstAllButtons;
        public frmHangman()
        {
            InitializeComponent();

            lstAllButtons = new() { btnA, btnB, btnC, btnD, btnE, btnF, btnG, btnH, btnI, btnJ, btnK, btnL, btnM, btnN, btnO, btnP, btnQ, btnR, btnS, btnT, btnU, btnV, btnW, btnX, btnY, btnZ };
            lstAllButtons.ForEach(b =>
            {
                Letter ltr = game.AllLetters[lstAllButtons.IndexOf(b)];
                BindingSource binding = new() { DataSource = ltr };

                b.DataBindings.Add("Text", binding, nameof(Letter.Value));
                b.DataBindings.Add("BackColor", binding, nameof(Letter.BackColor));
                b.DataBindings.Add("ForeColor", binding, nameof(Letter.Color));
                b.Click += BtnLetter_Click;
            });

            lblStatus.DataBindings.Add("Text", game, nameof(game.Description));
            lblHint.DataBindings.Add("Text", game, nameof(game.Hint));
            SetWordLetters();
            btnHint.Click += BtnHint_Click;
            game.PropertyChanged += Game_PropertyChanged;
        }

        private void SetWordLetters()
        {
            tblWord.Controls.Clear();
            tblWord.ColumnCount = game.WordLetters.Count;
            game.WordLetters.ForEach(l =>
            {
                Label lbl = GetNewLabel();
                lbl.DataBindings.Add("Text", l, nameof(Letter.Value));
                tblWord.Controls.Add(lbl);
            });
        }

        private Label GetNewLabel()
        {
            Padding padding = new() { Top = 3, Left = 3, Bottom = 3, Right = 3 };
            Label lbl = new()
            {
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.WhiteSmoke,
                Anchor = AnchorStyles.None,
                Height = 50,
                Width = 50,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.Black,
                Margin = padding,
                Enabled = false,
            };
            return lbl;
        }

        private void GuessLetter(Button btn)
        {
            game.GuessLetter(btn.Text);
            btn.Tag = false;
        }

        private void ReveleHint()
        {
            game.ReveleHint();
        }

        private void BtnLetter_Click(object? sender, EventArgs e)
        {
            if (sender is Button b && b.Tag == null)
            {
                GuessLetter(b);
            }
        }

        private void BtnHint_Click(object? sender, EventArgs e)
        {
            ReveleHint();
        }

        private void Game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(game.WrongGuesses) && game.WrongGuesses == 0)
            {
                SetWordLetters();
            }
        }
    }
}