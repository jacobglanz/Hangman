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
        List<Button> lstwordbuttons = new();

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
            //SM What does this loop do? It never goes into the loop.
            foreach (Control c in tblWord.Controls)
            {
                if (c is Button)
                {
                    lstwordbuttons.Add((Button)c);
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
            //SM Why do you make the letters of the word a button?
            //It looks like a button to me, Am i missing something?
            //SM This is my question. Why do you need it to be buttons?
            randomwordlst.ForEach(c => tblWord.Controls.Add(GetNewButton()));
            tblWord.ColumnCount = randomwordlst.Count;
        }

        private Button GetNewButton(string letter = "")
        {
            Padding padding = new() { Top = 3, Left = 3, Bottom = 3, Right = 3 };
            Button btn = new()
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
            return btn;
        }

        private void GuessLetter(Button btn)
        {
            //SM You won't be able to click the button if it's not enabled.
            //JG When btn clicked it get's disabled and marked either correct or incorrect. If user starts a new game it get's enabled
            //    and if you try to click it again nothing happens because its disabled already.
            //SM The only code that is calling this procedure is the button click event. That event will ONLY be raised if the user clicks the button.
            //The user will ONLY be able to click the button if it is enabled.
            if (btn.Enabled)
            {
                btn.Enabled = false;
                if (randomword.Contains(btn.Text))
                {
                    btn.BackColor = btnwinbackcolor;
                    DetectWin();
                }
                else
                {
                    btn.BackColor = btnlossbackcolor;
                    Lives -= 1;
                    DetectLoss();
                }
                SetWordButtons(btn);
                DisplayGameStatus();
            }
        }

        private void SetWordButtons(Button btn)
        {
            int counter = 0;

            foreach (Control c in tblWord.Controls)
            {
                if (c is Button)
                {
                    string s = randomwordlst[counter].ToString();
                    if (s == btn.Text)
                    {
                        c.Text = s;
                        c.BackColor = btnwinbackcolor;
                    }
                    else if (c.Text == "" && gamestatus == GameStatusEnum.Lost && c.Text == "")
                    {
                        c.Text = s;
                        c.BackColor = btnlossbackcolor;
                    }
                    counter++;
                }
            }
        }

        private void DetectWin()
        {
            bool iswin = true;
            foreach (Control c in tblWord.Controls)
            {
                if (c.Text == "")
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

        private void DetectLoss()
        {
            bool isloss = true;
            if (Lives > 0)
            {
                isloss = false;
            }
            if (isloss)
            {
                gamestatus = GameStatusEnum.Lost;
                ResetLetterButtons();
                SetStartButtonText();
                btnHint.Enabled = false;
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