using System.Data;
using gnuciDictionary;

namespace HangmanApp
{
    public partial class frmHangman : Form
    {
        List<Word> lstwords;
        string randomword = "";
        List<Button> lstletterbuttons = new();

        private enum GameStatusEnum { Inactive, Playing, Won, Lost };
        GameStatusEnum gamestatus = GameStatusEnum.Inactive;

        Color btndefaultbackcolor = Color.AliceBlue;
        Color btnwinbackcolor = Color.LightGreen;
        Color btnlossbackcolor = Color.PaleVioletRed;

        string path = Application.StartupPath + @"\images\hangman.ico";
        
        int Lives = 5;

        public frmHangman()
        {
            InitializeComponent();
            SetLetterButtons();
            DisplayGameStatus();
            btnStart.Click += BtnStart_Click;

            lstwords = EnglishDictionary.GetAllWords().Where(w =>
                w.Value.All(c => char.IsLetter(c))
                && w.Value.Length >= 4
                && w.Value.Length <= 7)
                .ToList();
        }

        //SM Why do you need to add the letters here? Why don't you add them in UI designer?
        private void SetLetterButtons()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Button btn = GetNewButton(c.ToString());
                tblAllLetters.Controls.Add(btn);
                lstletterbuttons.Add(btn);
                btn.Click += BtnLetter_Click;

                if (c == 'Z')
                {
                    tblAllLetters.SetColumnSpan(btn, 5);
                }
            }
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

        private void DisplayGameStatus()
        {
            lblStatus.Text = gamestatus switch
            {
                GameStatusEnum.Inactive => "Click Start to Begin Playing",
                GameStatusEnum.Playing => Lives + "/5 Lives left",
                GameStatusEnum.Won => "You Won",
                _ => "You Lost"
            };
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

        private void GuessLetter(Button btn)
        {
            //SM You won't be able to click the button if it's not enabled.
            if (btn.Enabled)
            {
                btn.Enabled = false;

                if (randomword.Contains(btn.Text))
                {
                    btn.BackColor = btnwinbackcolor;
                    if (SetWordButtons(btn))
                    {
                        gamestatus = GameStatusEnum.Won;
                        ResetLetterButtons();
                    }
                }
                else
                {
                    btn.BackColor = btnlossbackcolor;
                    Lives -= 1;
                    if (Lives < 1)
                    {
                        gamestatus = GameStatusEnum.Lost;
                        ResetLetterButtons();
                        SetWordButtons(btn);
                    }
                }

                DisplayGameStatus();
            }
        }

        private bool SetWordButtons(Button btn)
        {
            List<char> lst = randomword.ToList();
            int counter = 0;
            bool iswin = true;

            foreach (Control c in tblWord.Controls)
            {
                if (c is Button)
                {
                    string s = lst[counter].ToString();
                    if (gamestatus == GameStatusEnum.Playing)
                    {
                        if (btn.Text == s)
                        {
                            c.BackColor = btnwinbackcolor;
                            c.Text = s;
                        }
                        else if (c.Text == "")
                        {
                            iswin = false;
                        }
                    }
                    //SM This else in not needed. It will never get in here, and it should never get here.
                    //Because the program should not get in this procedure if it's not playing.
                    else if (c.Text == "")
                    {
                        c.BackColor = btnlossbackcolor;
                        c.Text = s;
                    }
                    counter++;
                }
            }
            return iswin;
        }

        private void StartGame()
        {
            gamestatus = GameStatusEnum.Playing;
            Lives = 5;
            btnStart.Text = "Restart";
            SetTableWord();
            DisplayGameStatus();
            ResetLetterButtons();
        }

        private void SetTableWord()
        {
            randomword = lstwords[new Random().Next(lstwords.Count)].Value.ToUpper();
            List<char> lst = randomword.ToList();
            tblWord.Controls.Clear();
            //SM Why do you make the letters of the word a button?
            //And why don't you use lst?
            randomword.ToList().ForEach(c => tblWord.Controls.Add(GetNewButton()));
            tblWord.ColumnCount = lst.Count;
            //SM Why do you change the width of the form every time? It doesn't look good that the form is changing sizes every time there's a new word.
            this.Width = lst.Count * 60;
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

    }
}
