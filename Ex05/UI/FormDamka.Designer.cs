using System;
using System.Windows.Forms;

namespace Ex05.UI
{
    partial class FormDamka
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
        /// 
        const int width = 50;
        const int height = 50;
        const int margin = 20;
        const int topMargin = 80;
        private void InitializeComponent()
        {
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelName1 = new System.Windows.Forms.Label();
            this.labelName2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(60, 40);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(65, 20);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Player 1";
            this.labelPlayer1.Click += new System.EventHandler(this.labelPlayer1_Click);
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(340, 40);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(65, 20);
            this.labelPlayer2.TabIndex = 1;
            this.labelPlayer2.Text = "Player 2";
            // 
            // labelName1
            // 
            this.labelName1.AutoSize = true;
            this.labelName1.Location = new System.Drawing.Point(60, 60);
            this.labelName1.Name = "labelName1";
            this.labelName1.Size = new System.Drawing.Size(0, 20);
            this.labelName1.TabIndex = 2;
            this.labelName1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelName2
            // 
            this.labelName2.AutoSize = true;
            this.labelName2.Location = new System.Drawing.Point(340, 60);
            this.labelName2.Name = "labelName2";
            this.labelName2.Size = new System.Drawing.Size(0, 20);
            this.labelName2.TabIndex = 3;
            this.labelName2.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // FormDamka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 515);
            this.Controls.Add(this.labelName2);
            this.Controls.Add(this.labelName1);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Name = "FormDamka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.FormDamka_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormDamka_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        public FormDamka()
        {
            InitializeComponent();
        }


        #endregion

        private int m_BoardSize;
        private string m_PlayerOneName;
        private string m_PlayerTwoName;
        private int m_NumOfPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelName1;
        private System.Windows.Forms.Label labelName2;

    }
}