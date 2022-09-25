
namespace Snake
{
    partial class Fm_main
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
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonRecords = new System.Windows.Forms.Button();
            this.buttonLevelHard = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonStartGame.Location = new System.Drawing.Point(57, 76);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(201, 46);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Играть";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // buttonRecords
            // 
            this.buttonRecords.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonRecords.Location = new System.Drawing.Point(57, 128);
            this.buttonRecords.Name = "buttonRecords";
            this.buttonRecords.Size = new System.Drawing.Size(201, 46);
            this.buttonRecords.TabIndex = 1;
            this.buttonRecords.Text = "Рекорды";
            this.buttonRecords.UseVisualStyleBackColor = false;
            this.buttonRecords.Click += new System.EventHandler(this.buttonRecords_Click);
            // 
            // buttonLevelHard
            // 
            this.buttonLevelHard.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonLevelHard.Location = new System.Drawing.Point(57, 180);
            this.buttonLevelHard.Name = "buttonLevelHard";
            this.buttonLevelHard.Size = new System.Drawing.Size(201, 46);
            this.buttonLevelHard.TabIndex = 2;
            this.buttonLevelHard.Text = "Сложность";
            this.buttonLevelHard.UseVisualStyleBackColor = false;
            this.buttonLevelHard.Click += new System.EventHandler(this.buttonLevelHard_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonClose.Location = new System.Drawing.Point(57, 232);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(201, 46);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Выход";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Fm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(306, 366);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonLevelHard);
            this.Controls.Add(this.buttonRecords);
            this.Controls.Add(this.buttonStartGame);
            this.Name = "Fm_main";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Button buttonRecords;
        private System.Windows.Forms.Button buttonLevelHard;
        private System.Windows.Forms.Button buttonClose;
    }
}