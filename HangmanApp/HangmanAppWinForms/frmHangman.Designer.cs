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
            lblStatus = new Label();
            tblAllLetters = new TableLayoutPanel();
            btnY = new Button();
            btnX = new Button();
            btnW = new Button();
            btnV = new Button();
            btnU = new Button();
            btnT = new Button();
            btnS = new Button();
            btnR = new Button();
            btnQ = new Button();
            btnP = new Button();
            btnO = new Button();
            btnN = new Button();
            btnM = new Button();
            btnL = new Button();
            btnK = new Button();
            btnJ = new Button();
            btnI = new Button();
            btnH = new Button();
            btnG = new Button();
            btnF = new Button();
            btnE = new Button();
            btnD = new Button();
            btnC = new Button();
            btnB = new Button();
            btnA = new Button();
            btnZ = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnHint = new Button();
            btnStart = new Button();
            lblHint = new Label();
            tblWord = new TableLayoutPanel();
            tblMain.SuspendLayout();
            tblAllLetters.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblStatus, 0, 1);
            tblMain.Controls.Add(tableLayoutPanel1, 0, 0);
            tblMain.Controls.Add(lblHint, 0, 3);
            tblMain.Controls.Add(tblWord, 0, 2);
            tblMain.Controls.Add(tblAllLetters, 0, 4);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 5;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(548, 582);
            tblMain.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.None;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(248, 69);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 21);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
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
            tblAllLetters.Controls.Add(btnY, 4, 4);
            tblAllLetters.Controls.Add(btnX, 3, 4);
            tblAllLetters.Controls.Add(btnW, 2, 4);
            tblAllLetters.Controls.Add(btnV, 1, 4);
            tblAllLetters.Controls.Add(btnU, 0, 4);
            tblAllLetters.Controls.Add(btnT, 4, 3);
            tblAllLetters.Controls.Add(btnS, 3, 3);
            tblAllLetters.Controls.Add(btnR, 2, 3);
            tblAllLetters.Controls.Add(btnQ, 1, 3);
            tblAllLetters.Controls.Add(btnP, 0, 3);
            tblAllLetters.Controls.Add(btnO, 4, 2);
            tblAllLetters.Controls.Add(btnN, 3, 2);
            tblAllLetters.Controls.Add(btnM, 2, 2);
            tblAllLetters.Controls.Add(btnL, 1, 2);
            tblAllLetters.Controls.Add(btnK, 0, 2);
            tblAllLetters.Controls.Add(btnJ, 4, 1);
            tblAllLetters.Controls.Add(btnI, 3, 1);
            tblAllLetters.Controls.Add(btnH, 2, 1);
            tblAllLetters.Controls.Add(btnG, 1, 1);
            tblAllLetters.Controls.Add(btnF, 0, 1);
            tblAllLetters.Controls.Add(btnE, 4, 0);
            tblAllLetters.Controls.Add(btnD, 3, 0);
            tblAllLetters.Controls.Add(btnC, 2, 0);
            tblAllLetters.Controls.Add(btnB, 1, 0);
            tblAllLetters.Controls.Add(btnA, 0, 0);
            tblAllLetters.Controls.Add(btnZ, 2, 5);
            tblAllLetters.Location = new Point(134, 228);
            tblAllLetters.MinimumSize = new Size(250, 250);
            tblAllLetters.Name = "tblAllLetters";
            tblAllLetters.RowCount = 6;
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblAllLetters.Size = new Size(280, 336);
            tblAllLetters.TabIndex = 3;
            // 
            // btnY
            // 
            btnY.Anchor = AnchorStyles.None;
            btnY.BackColor = Color.AliceBlue;
            btnY.Enabled = false;
            btnY.Location = new Point(227, 227);
            btnY.Name = "btnY";
            btnY.Size = new Size(50, 50);
            btnY.TabIndex = 24;
            btnY.Text = "Y";
            btnY.UseVisualStyleBackColor = false;
            // 
            // btnX
            // 
            btnX.Anchor = AnchorStyles.None;
            btnX.BackColor = Color.AliceBlue;
            btnX.Enabled = false;
            btnX.Location = new Point(171, 227);
            btnX.Name = "btnX";
            btnX.Size = new Size(50, 50);
            btnX.TabIndex = 23;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            // 
            // btnW
            // 
            btnW.Anchor = AnchorStyles.None;
            btnW.BackColor = Color.AliceBlue;
            btnW.Enabled = false;
            btnW.Location = new Point(115, 227);
            btnW.Name = "btnW";
            btnW.Size = new Size(50, 50);
            btnW.TabIndex = 22;
            btnW.Text = "W";
            btnW.UseVisualStyleBackColor = false;
            // 
            // btnV
            // 
            btnV.Anchor = AnchorStyles.None;
            btnV.BackColor = Color.AliceBlue;
            btnV.Enabled = false;
            btnV.Location = new Point(59, 227);
            btnV.Name = "btnV";
            btnV.Size = new Size(50, 50);
            btnV.TabIndex = 21;
            btnV.Text = "V";
            btnV.UseVisualStyleBackColor = false;
            // 
            // btnU
            // 
            btnU.Anchor = AnchorStyles.None;
            btnU.BackColor = Color.AliceBlue;
            btnU.Enabled = false;
            btnU.Location = new Point(3, 227);
            btnU.Name = "btnU";
            btnU.Size = new Size(50, 50);
            btnU.TabIndex = 20;
            btnU.Text = "U";
            btnU.UseVisualStyleBackColor = false;
            // 
            // btnT
            // 
            btnT.Anchor = AnchorStyles.None;
            btnT.BackColor = Color.AliceBlue;
            btnT.Enabled = false;
            btnT.Location = new Point(227, 171);
            btnT.Name = "btnT";
            btnT.Size = new Size(50, 50);
            btnT.TabIndex = 19;
            btnT.Text = "T";
            btnT.UseVisualStyleBackColor = false;
            // 
            // btnS
            // 
            btnS.Anchor = AnchorStyles.None;
            btnS.BackColor = Color.AliceBlue;
            btnS.Enabled = false;
            btnS.Location = new Point(171, 171);
            btnS.Name = "btnS";
            btnS.Size = new Size(50, 50);
            btnS.TabIndex = 18;
            btnS.Text = "S";
            btnS.UseVisualStyleBackColor = false;
            // 
            // btnR
            // 
            btnR.Anchor = AnchorStyles.None;
            btnR.BackColor = Color.AliceBlue;
            btnR.Enabled = false;
            btnR.Location = new Point(115, 171);
            btnR.Name = "btnR";
            btnR.Size = new Size(50, 50);
            btnR.TabIndex = 17;
            btnR.Text = "R";
            btnR.UseVisualStyleBackColor = false;
            // 
            // btnQ
            // 
            btnQ.Anchor = AnchorStyles.None;
            btnQ.BackColor = Color.AliceBlue;
            btnQ.Enabled = false;
            btnQ.Location = new Point(59, 171);
            btnQ.Name = "btnQ";
            btnQ.Size = new Size(50, 50);
            btnQ.TabIndex = 16;
            btnQ.Text = "Q";
            btnQ.UseVisualStyleBackColor = false;
            // 
            // btnP
            // 
            btnP.Anchor = AnchorStyles.None;
            btnP.BackColor = Color.AliceBlue;
            btnP.Enabled = false;
            btnP.Location = new Point(3, 171);
            btnP.Name = "btnP";
            btnP.Size = new Size(50, 50);
            btnP.TabIndex = 15;
            btnP.Text = "P";
            btnP.UseVisualStyleBackColor = false;
            // 
            // btnO
            // 
            btnO.Anchor = AnchorStyles.None;
            btnO.BackColor = Color.AliceBlue;
            btnO.Enabled = false;
            btnO.Location = new Point(227, 115);
            btnO.Name = "btnO";
            btnO.Size = new Size(50, 50);
            btnO.TabIndex = 14;
            btnO.Text = "O";
            btnO.UseVisualStyleBackColor = false;
            // 
            // btnN
            // 
            btnN.Anchor = AnchorStyles.None;
            btnN.BackColor = Color.AliceBlue;
            btnN.Enabled = false;
            btnN.Location = new Point(171, 115);
            btnN.Name = "btnN";
            btnN.Size = new Size(50, 50);
            btnN.TabIndex = 13;
            btnN.Text = "N";
            btnN.UseVisualStyleBackColor = false;
            // 
            // btnM
            // 
            btnM.Anchor = AnchorStyles.None;
            btnM.BackColor = Color.AliceBlue;
            btnM.Enabled = false;
            btnM.Location = new Point(115, 115);
            btnM.Name = "btnM";
            btnM.Size = new Size(50, 50);
            btnM.TabIndex = 12;
            btnM.Text = "M";
            btnM.UseVisualStyleBackColor = false;
            // 
            // btnL
            // 
            btnL.Anchor = AnchorStyles.None;
            btnL.BackColor = Color.AliceBlue;
            btnL.Enabled = false;
            btnL.Location = new Point(59, 115);
            btnL.Name = "btnL";
            btnL.Size = new Size(50, 50);
            btnL.TabIndex = 11;
            btnL.Text = "L";
            btnL.UseVisualStyleBackColor = false;
            // 
            // btnK
            // 
            btnK.Anchor = AnchorStyles.None;
            btnK.BackColor = Color.AliceBlue;
            btnK.Enabled = false;
            btnK.Location = new Point(3, 115);
            btnK.Name = "btnK";
            btnK.Size = new Size(50, 50);
            btnK.TabIndex = 10;
            btnK.Text = "K";
            btnK.UseVisualStyleBackColor = false;
            // 
            // btnJ
            // 
            btnJ.Anchor = AnchorStyles.None;
            btnJ.BackColor = Color.AliceBlue;
            btnJ.Enabled = false;
            btnJ.Location = new Point(227, 59);
            btnJ.Name = "btnJ";
            btnJ.Size = new Size(50, 50);
            btnJ.TabIndex = 9;
            btnJ.Text = "J";
            btnJ.UseVisualStyleBackColor = false;
            // 
            // btnI
            // 
            btnI.Anchor = AnchorStyles.None;
            btnI.BackColor = Color.AliceBlue;
            btnI.Enabled = false;
            btnI.Location = new Point(171, 59);
            btnI.Name = "btnI";
            btnI.Size = new Size(50, 50);
            btnI.TabIndex = 8;
            btnI.Text = "I";
            btnI.UseVisualStyleBackColor = false;
            // 
            // btnH
            // 
            btnH.Anchor = AnchorStyles.None;
            btnH.BackColor = Color.AliceBlue;
            btnH.Enabled = false;
            btnH.Location = new Point(115, 59);
            btnH.Name = "btnH";
            btnH.Size = new Size(50, 50);
            btnH.TabIndex = 7;
            btnH.Text = "H";
            btnH.UseVisualStyleBackColor = false;
            // 
            // btnG
            // 
            btnG.Anchor = AnchorStyles.None;
            btnG.BackColor = Color.AliceBlue;
            btnG.Enabled = false;
            btnG.Location = new Point(59, 59);
            btnG.Name = "btnG";
            btnG.Size = new Size(50, 50);
            btnG.TabIndex = 6;
            btnG.Text = "G";
            btnG.UseVisualStyleBackColor = false;
            // 
            // btnF
            // 
            btnF.Anchor = AnchorStyles.None;
            btnF.BackColor = Color.AliceBlue;
            btnF.Enabled = false;
            btnF.Location = new Point(3, 59);
            btnF.Name = "btnF";
            btnF.Size = new Size(50, 50);
            btnF.TabIndex = 5;
            btnF.Text = "F";
            btnF.UseVisualStyleBackColor = false;
            // 
            // btnE
            // 
            btnE.Anchor = AnchorStyles.None;
            btnE.BackColor = Color.AliceBlue;
            btnE.Enabled = false;
            btnE.Location = new Point(227, 3);
            btnE.Name = "btnE";
            btnE.Size = new Size(50, 50);
            btnE.TabIndex = 4;
            btnE.Text = "E";
            btnE.UseVisualStyleBackColor = false;
            // 
            // btnD
            // 
            btnD.Anchor = AnchorStyles.None;
            btnD.BackColor = Color.AliceBlue;
            btnD.Enabled = false;
            btnD.Location = new Point(171, 3);
            btnD.Name = "btnD";
            btnD.Size = new Size(50, 50);
            btnD.TabIndex = 3;
            btnD.Text = "D";
            btnD.UseVisualStyleBackColor = false;
            // 
            // btnC
            // 
            btnC.Anchor = AnchorStyles.None;
            btnC.BackColor = Color.AliceBlue;
            btnC.Enabled = false;
            btnC.Location = new Point(115, 3);
            btnC.Name = "btnC";
            btnC.Size = new Size(50, 50);
            btnC.TabIndex = 2;
            btnC.Text = "C";
            btnC.UseVisualStyleBackColor = false;
            // 
            // btnB
            // 
            btnB.Anchor = AnchorStyles.None;
            btnB.BackColor = Color.AliceBlue;
            btnB.Enabled = false;
            btnB.Location = new Point(59, 3);
            btnB.Name = "btnB";
            btnB.Size = new Size(50, 50);
            btnB.TabIndex = 1;
            btnB.Text = "B";
            btnB.UseVisualStyleBackColor = false;
            // 
            // btnA
            // 
            btnA.Anchor = AnchorStyles.None;
            btnA.BackColor = Color.AliceBlue;
            btnA.Enabled = false;
            btnA.Location = new Point(3, 3);
            btnA.Name = "btnA";
            btnA.Size = new Size(50, 50);
            btnA.TabIndex = 0;
            btnA.Text = "A";
            btnA.UseVisualStyleBackColor = false;
            // 
            // btnZ
            // 
            btnZ.Anchor = AnchorStyles.None;
            btnZ.BackColor = Color.AliceBlue;
            btnZ.Enabled = false;
            btnZ.Location = new Point(115, 283);
            btnZ.Name = "btnZ";
            btnZ.Size = new Size(50, 50);
            btnZ.TabIndex = 25;
            btnZ.Text = "Z";
            btnZ.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnHint, 1, 0);
            tableLayoutPanel1.Controls.Add(btnStart, 0, 0);
            tableLayoutPanel1.Location = new Point(116, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(315, 44);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnHint
            // 
            btnHint.Anchor = AnchorStyles.None;
            btnHint.BackColor = Color.AliceBlue;
            btnHint.Enabled = false;
            btnHint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnHint.Location = new Point(180, 3);
            btnHint.Name = "btnHint";
            btnHint.Size = new Size(112, 38);
            btnHint.TabIndex = 1;
            btnHint.Tag = "";
            btnHint.Text = "Hint";
            btnHint.UseVisualStyleBackColor = false;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.None;
            btnStart.BackColor = Color.SkyBlue;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(22, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 38);
            btnStart.TabIndex = 0;
            btnStart.Tag = "";
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // lblHint
            // 
            lblHint.Anchor = AnchorStyles.None;
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            lblHint.Location = new Point(274, 176);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(0, 17);
            lblHint.TabIndex = 5;
            lblHint.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblWord
            // 
            tblWord.Anchor = AnchorStyles.None;
            tblWord.AutoSize = true;
            tblWord.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblWord.ColumnCount = 1;
            tblWord.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tblWord.Location = new Point(224, 105);
            tblWord.Margin = new Padding(0);
            tblWord.Name = "tblWord";
            tblWord.RowCount = 1;
            tblWord.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tblWord.Size = new Size(100, 50);
            tblWord.TabIndex = 1;
            // 
            // frmHangman
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 582);
            Controls.Add(tblMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(350, 0);
            Name = "frmHangman";
            Text = "Hangman";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblAllLetters.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblAllLetters;
        private Label lblStatus;
        private Button btnStart;
        private Button btnA;
        private Button btnY;
        private Button btnX;
        private Button btnW;
        private Button btnV;
        private Button btnU;
        private Button btnT;
        private Button btnS;
        private Button btnR;
        private Button btnQ;
        private Button btnP;
        private Button btnO;
        private Button btnN;
        private Button btnM;
        private Button btnL;
        private Button btnK;
        private Button btnJ;
        private Button btnI;
        private Button btnH;
        private Button btnG;
        private Button btnF;
        private Button btnE;
        private Button btnD;
        private Button btnC;
        private Button btnB;
        private Button btnZ;
        private TableLayoutPanel tblWord;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnHint;
        private Label lblHint;
    }
}