namespace Ex05.UI
{
    partial class FormGameSettings
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
            this.buttonDone = new System.Windows.Forms.Button();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(231, 230);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(123, 34);
            this.buttonDone.TabIndex = 21;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(190, 170);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(164, 26);
            this.textBoxPlayer2.TabIndex = 20;
            this.textBoxPlayer2.Text = "[Computer]";
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(190, 138);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(164, 26);
            this.textBoxPlayer1.TabIndex = 19;
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(66, 170);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.checkBoxPlayer2.TabIndex = 18;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckStateChanged += new System.EventHandler(this.CheckBoxPlayer2_CheckStateChanged);
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(62, 138);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.labelPlayer1.TabIndex = 17;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(35, 105);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(64, 20);
            this.labelPlayers.TabIndex = 16;
            this.labelPlayers.Text = "Players:";
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(242, 57);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(85, 24);
            this.radioButton10.TabIndex = 15;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "10 x 10";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(149, 57);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(67, 24);
            this.radioButton8.TabIndex = 14;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "8 x 8";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(56, 57);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(67, 24);
            this.radioButton6.TabIndex = 13;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "6 x 6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(35, 23);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.labelBoardSize.TabIndex = 12;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 306);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.radioButton10);
            this.Controls.Add(this.radioButton8);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.labelBoardSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGameSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        public string PlayerOneName
        {
            get { return textBoxPlayer1.Text; }
        }
        public string PlayerTwoName
        {
            get { return textBoxPlayer2.Text; }
        }

        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        public int OneOrTwoPlayers
        {
            get { return checkBoxPlayer2.Checked ? 2 : 1; }
        }
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label labelBoardSize;
    }
}