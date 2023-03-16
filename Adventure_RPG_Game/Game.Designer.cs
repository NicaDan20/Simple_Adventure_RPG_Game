
namespace Adventure_RPG_Game
{
    partial class Game
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_hit_points = new System.Windows.Forms.Label();
            this.label_gold = new System.Windows.Forms.Label();
            this.label_experience = new System.Windows.Forms.Label();
            this.label_level = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.LawnGreen;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(407, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Experience:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DeepPink;
            this.label3.Location = new System.Drawing.Point(667, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(222, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gold: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label_hit_points
            // 
            this.label_hit_points.AutoSize = true;
            this.label_hit_points.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_hit_points.ForeColor = System.Drawing.Color.LawnGreen;
            this.label_hit_points.Location = new System.Drawing.Point(111, 19);
            this.label_hit_points.Name = "label_hit_points";
            this.label_hit_points.Size = new System.Drawing.Size(0, 18);
            this.label_hit_points.TabIndex = 4;
            // 
            // label_gold
            // 
            this.label_gold.AutoSize = true;
            this.label_gold.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_gold.ForeColor = System.Drawing.Color.Gold;
            this.label_gold.Location = new System.Drawing.Point(284, 19);
            this.label_gold.Name = "label_gold";
            this.label_gold.Size = new System.Drawing.Size(0, 18);
            this.label_gold.TabIndex = 5;
            this.label_gold.Click += new System.EventHandler(this.label6_Click);
            // 
            // label_experience
            // 
            this.label_experience.AutoSize = true;
            this.label_experience.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_experience.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_experience.Location = new System.Drawing.Point(500, 19);
            this.label_experience.Name = "label_experience";
            this.label_experience.Size = new System.Drawing.Size(0, 18);
            this.label_experience.TabIndex = 6;
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_level.ForeColor = System.Drawing.Color.DeepPink;
            this.label_level.Location = new System.Drawing.Point(709, 19);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(0, 18);
            this.label_level.TabIndex = 7;
            this.label_level.Click += new System.EventHandler(this.label8_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label_level);
            this.Controls.Add(this.label_experience);
            this.Controls.Add(this.label_gold);
            this.Controls.Add(this.label_hit_points);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_hit_points;
        private System.Windows.Forms.Label label_gold;
        private System.Windows.Forms.Label label_experience;
        private System.Windows.Forms.Label label_level;
    }
}

