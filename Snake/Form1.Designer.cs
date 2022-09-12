
namespace Snake
{
    partial class Fm_game_place
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelScore = new System.Windows.Forms.Label();
            this.timer_game_cycle = new System.Windows.Forms.Timer(this.components);
            this.timer_starting_game = new System.Windows.Forms.Timer(this.components);
            this.timer_of_big_apple = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(28, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(520, 520);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LabelScore
            // 
            this.LabelScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelScore.AutoSize = true;
            this.LabelScore.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelScore.Location = new System.Drawing.Point(240, 9);
            this.LabelScore.Name = "LabelScore";
            this.LabelScore.Size = new System.Drawing.Size(106, 41);
            this.LabelScore.TabIndex = 1;
            this.LabelScore.Text = "Счёт 0";
            this.LabelScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LabelScore.SizeChanged += new System.EventHandler(this.LabelScore_SizeChanged);
            // 
            // timer_game_cycle
            // 
            this.timer_game_cycle.Interval = 1000;
            this.timer_game_cycle.Tick += new System.EventHandler(this.timer_game_cycle_Tick);
            // 
            // timer_starting_game
            // 
            this.timer_starting_game.Tick += new System.EventHandler(this.timer_starting_game_Tick);
            // 
            // timer_of_big_apple
            // 
            this.timer_of_big_apple.Tick += new System.EventHandler(this.timer_of_big_apple_Tick);
            // 
            // Fm_game_place
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(567, 604);
            this.Controls.Add(this.LabelScore);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "Fm_game_place";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Fm_game_place_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Fm_game_place_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelScore;
        private System.Windows.Forms.Timer timer_game_cycle;
        private System.Windows.Forms.Timer timer_starting_game;
        private System.Windows.Forms.Timer timer_of_big_apple;
    }
}

