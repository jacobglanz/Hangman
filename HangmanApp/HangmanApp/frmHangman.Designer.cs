namespace HangmanApp
{
    partial class frmHangman
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHangman));
            tblMain = new TableLayoutPanel();
            tblAllLetters = new TableLayoutPanel();
            tblWord = new TableLayoutPanel();
            btnStart = new Button();
            lblStatus = new Label();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblAllLetters, 0, 3);
            tblMain.Controls.Add(tblWord, 0, 1);
            tblMain.Controls.Add(btnStart, 0, 0);
            tblMain.Controls.Add(lblStatus, 0, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5562944F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.55897F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.90356445F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 66.98117F));
            tblMain.Size = new Size(463, 495);
            tblMain.TabIndex = 0;
            // 
            // tblAllLetters
            // 
            tblAllLetters.Anchor = AnchorStyles.None;
            tblAllLetters.AutoSize = true;
            tblAllLetters.ColumnCount = 5;
            tblAllLetters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblAllLetters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblAllLetters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblAllLetters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblAllLetters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblAllLetters.Location = new Point(231, 329);
            tblAllLetters.Name = "tblAllLetters";
            tblAllLetters.RowCount = 6;
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.Size = new Size(0, 0);
            tblAllLetters.TabIndex = 3;
            // 
            // tblWord
            // 
            tblWord.Anchor = AnchorStyles.None;
            tblWord.AutoSize = true;
            tblWord.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblWord.ColumnCount = 1;
            tblMain.SetColumnSpan(tblWord, 2);
            tblWord.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tblWord.Location = new Point(204, 68);
            tblWord.Name = "tblWord";
            tblWord.RowCount = 1;
            tblWord.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tblWord.Size = new Size(54, 50);
            tblWord.TabIndex = 1;
            tblWord.Visible = false;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.None;
            btnStart.BackColor = Color.SkyBlue;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(179, 16);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(104, 30);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.None;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(205, 133);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 21);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmHangman
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 495);
            Controls.Add(tblMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(350, 0);
            Name = "frmHangman";
            Text = "Hangman";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblWord;
        private TableLayoutPanel tblAllLetters;
        private Label lblStatus;
        private Button btnStart;
    }
}