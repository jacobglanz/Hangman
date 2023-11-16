using System.Data;
using gnuciDictionary;

namespace HangmanApp
{
    public partial class frmHangman : Form
    {
        List<Word> lstwords;
        string randomword;
        string randomworddefinition;
        List<char> randomwordlst;
        List<Button> lstletterbuttons = new();

        private enum GameStatusEnum { Inactive, Playing, Won, Lost };
        GameStatusEnum gamestatus = GameStatusEnum.Inactive;

        Color btndefaultbackcolor = Color.AliceBlue;
        Color btnwinbackcolor = Color.LightGreen;
        Color btnlossbackcolor = Color.PaleVioletRed;

        int Lives = 5;

        public frmHangman()
        {
            InitializeComponent();
            DisplayGameStatus();
            btnStart.Click += BtnStart_Click;
            btnHint.Click += BtnHint_Click;

            lstwords = EnglishDictionary.GetAllWords().Where(w => w.Value.All(c => char.IsLetter(c))
                && w.Value.Length >= 4 && w.Value.Length <= 7).ToList();

            foreach (Control c in tblAllLetters.Controls)
            {
                if (c is Button)
                {
                    Button btn = (Button)c;
                    lstletterbuttons.Add(btn);
                    btn.Click += BtnLetter_Click;
                }
            }
        }

        private void StartGame()
        {
            gamestatus = GameStatusEnum.Playing;
            Lives = 5;
            SetStartButtonText();
            SetTableWord();
            DisplayGameStatus();
            ResetLetterButtons();
            btnHint.Enabled = true;
            lblHint.Text = "";
        }

        private void SetTableWord()
        {
            Word w = lstwords[new Random().Next(lstwords.Count)];
            randomword = w.Value.ToUpper();
            randomworddefinition = w.Definition;
            randomwordlst = randomword.ToCharArray().ToList();
            tblWord.Controls.Clear();
            randomwordlst.ForEach(c => tblWord.Controls.Add(GetNewLabel()));
            tblWord.ColumnCount = 0;
            tblWord.ColumnCount = randomwordlst.Count;
        }

        private Label GetNewLabel(string letter = "")
        {
            Padding padding = new() { Top = 3, Left = 3, Bottom = 3, Right = 3 };
            Label lbl = new()
            {
                Text = letter,
                Name = "lbl" + letter,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = btndefaultbackcolor,
                Anchor = AnchorStyles.None,
                Height = 50,
                Width = 50,
                Margin = padding,
                Enabled = false
            };
            return lbl;
        }

        private void GuessLetter(Button btn)
        {
            btn.Enabled = false;
            if (randomword.Contains(btn.Text))
            {
                btn.BackColor = btnwinbackcolor;
                SetWordButtons(btn);
                DetectWin();
            }
            else
            {
                btn.BackColor = btnlossbackcolor;
                Lives -= 1;
                DetectLoss(btn);
            }
            DisplayGameStatus();
        }

        private void DetectWin()
        {
            bool iswin = true;
            foreach (Control c in tblWord.Controls)
            {
                if (c is Label && c.Text == "")
                {
                    iswin = false;
                }
            }
            if (iswin)
            {
                gamestatus = GameStatusEnum.Won;
                ResetLetterButtons();
                SetStartButtonText();
                btnHint.Enabled = false;
            }
        }

        private void DetectLoss(Button btn)
        {
            if (Lives < 1)
            {
                gamestatus = GameStatusEnum.Lost;
                SetWordButtons(btn);
                ResetLetterButtons();
                SetStartButtonText();
                btnHint.Enabled = false;
            }
        }

        private void SetWordButtons(Button btn)
        {
            int counter = 0;

            foreach (Control c in tblWord.Controls)
            {
                if (c is Label)
                {
                    string s = randomwordlst[counter].ToString();
                    if (s == btn.Text)
                    {
                        c.Text = s;
                        c.BackColor = btnwinbackcolor;
                    }
                    else if (c.Text == "" && gamestatus == GameStatusEnum.Lost)
                    {
                        c.Text = s;
                        c.BackColor = btnlossbackcolor;
                    }
                    counter++;
                }
            }
        }

        private void DisplayGameStatus()
        {
            lblStatus.Text = gamestatus switch
            {
                GameStatusEnum.Inactive => "Click Start to Begin Playing",
                GameStatusEnum.Playing => Lives + "/5 Lives left",
                GameStatusEnum.Won => "You Won",
                GameStatusEnum.Lost => "You Lost"
            };
        }

        private void SetStartButtonText()
        {
            btnStart.Text = gamestatus == GameStatusEnum.Playing ? "Restart" : "Start";
        }

        private void ResetLetterButtons()
        {
            switch (gamestatus)
            {
                case GameStatusEnum.Playing:
                    lstletterbuttons.ForEach(b => { b.BackColor = btndefaultbackcolor; b.Enabled = true; });
                    break;

                default:
                    lstletterbuttons.ForEach(b => b.Enabled = false);
                    break;
            }
        }

        private void ShowHint()
        {
            btnHint.Enabled = false;
            lblHint.Text = "Definition is: " + randomworddefinition;
        }

        private void BtnLetter_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                GuessLetter((Button)sender);
            }
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            StartGame();
        }

        private void BtnHint_Click(object? sender, EventArgs e)
        {
            ShowHint();
        }

    }
}