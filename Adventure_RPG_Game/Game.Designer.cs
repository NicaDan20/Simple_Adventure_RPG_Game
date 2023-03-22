
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
            this.label5 = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnGoNorth = new System.Windows.Forms.Button();
            this.btnGoEast = new System.Windows.Forms.Button();
            this.btnGoSouth = new System.Windows.Forms.Button();
            this.btnGoWest = new System.Windows.Forms.Button();
            this.txtBoxLocation = new System.Windows.Forms.RichTextBox();
            this.txtBoxMessages = new System.Windows.Forms.RichTextBox();
            this.gridQuests = new System.Windows.Forms.DataGridView();
            this.gridInventory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select Action";
            // 
            // cboWeapons
            // 
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(103, 144);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(121, 23);
            this.cboWeapons.TabIndex = 9;
            // 
            // cboPotions
            // 
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(103, 184);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(121, 23);
            this.cboPotions.TabIndex = 10;
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(12, 144);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(75, 23);
            this.btnUseWeapon.TabIndex = 11;
            this.btnUseWeapon.Text = "Attack";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Location = new System.Drawing.Point(12, 183);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(75, 23);
            this.btnUsePotion.TabIndex = 12;
            this.btnUsePotion.Text = "Use";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            // 
            // btnGoNorth
            // 
            this.btnGoNorth.Location = new System.Drawing.Point(34, 234);
            this.btnGoNorth.Name = "btnGoNorth";
            this.btnGoNorth.Size = new System.Drawing.Size(75, 23);
            this.btnGoNorth.TabIndex = 13;
            this.btnGoNorth.Text = "Go North";
            this.btnGoNorth.UseVisualStyleBackColor = true;
            this.btnGoNorth.Click += new System.EventHandler(this.btnGoNorth_Click);
            // 
            // btnGoEast
            // 
            this.btnGoEast.Location = new System.Drawing.Point(83, 263);
            this.btnGoEast.Name = "btnGoEast";
            this.btnGoEast.Size = new System.Drawing.Size(75, 23);
            this.btnGoEast.TabIndex = 14;
            this.btnGoEast.Text = "Go East";
            this.btnGoEast.UseVisualStyleBackColor = true;
            this.btnGoEast.Click += new System.EventHandler(this.btnGoEast_Click);
            // 
            // btnGoSouth
            // 
            this.btnGoSouth.Location = new System.Drawing.Point(34, 292);
            this.btnGoSouth.Name = "btnGoSouth";
            this.btnGoSouth.Size = new System.Drawing.Size(75, 23);
            this.btnGoSouth.TabIndex = 15;
            this.btnGoSouth.Text = "Go South";
            this.btnGoSouth.UseVisualStyleBackColor = true;
            this.btnGoSouth.Click += new System.EventHandler(this.btnGoSouth_Click);
            // 
            // btnGoWest
            // 
            this.btnGoWest.Location = new System.Drawing.Point(2, 263);
            this.btnGoWest.Name = "btnGoWest";
            this.btnGoWest.Size = new System.Drawing.Size(75, 23);
            this.btnGoWest.TabIndex = 16;
            this.btnGoWest.Text = "Go West";
            this.btnGoWest.UseVisualStyleBackColor = true;
            this.btnGoWest.Click += new System.EventHandler(this.btnGoWest_Click);
            // 
            // txtBoxLocation
            // 
            this.txtBoxLocation.Location = new System.Drawing.Point(12, 333);
            this.txtBoxLocation.Name = "txtBoxLocation";
            this.txtBoxLocation.ReadOnly = true;
            this.txtBoxLocation.Size = new System.Drawing.Size(272, 84);
            this.txtBoxLocation.TabIndex = 17;
            this.txtBoxLocation.Text = "";
            // 
            // txtBoxMessages
            // 
            this.txtBoxMessages.Location = new System.Drawing.Point(12, 432);
            this.txtBoxMessages.Name = "txtBoxMessages";
            this.txtBoxMessages.ReadOnly = true;
            this.txtBoxMessages.Size = new System.Drawing.Size(272, 107);
            this.txtBoxMessages.TabIndex = 18;
            this.txtBoxMessages.Text = "";
            // 
            // gridQuests
            // 
            this.gridQuests.AllowUserToAddRows = false;
            this.gridQuests.AllowUserToDeleteRows = false;
            this.gridQuests.AllowUserToResizeColumns = false;
            this.gridQuests.AllowUserToResizeRows = false;
            this.gridQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridQuests.Enabled = false;
            this.gridQuests.Location = new System.Drawing.Point(302, 432);
            this.gridQuests.MultiSelect = false;
            this.gridQuests.Name = "gridQuests";
            this.gridQuests.ReadOnly = true;
            this.gridQuests.RowHeadersVisible = false;
            this.gridQuests.RowTemplate.Height = 25;
            this.gridQuests.Size = new System.Drawing.Size(470, 107);
            this.gridQuests.TabIndex = 19;
            // 
            // gridInventory
            // 
            this.gridInventory.AllowUserToAddRows = false;
            this.gridInventory.AllowUserToDeleteRows = false;
            this.gridInventory.AllowUserToResizeColumns = false;
            this.gridInventory.AllowUserToResizeRows = false;
            this.gridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridInventory.Enabled = false;
            this.gridInventory.Location = new System.Drawing.Point(302, 263);
            this.gridInventory.MultiSelect = false;
            this.gridInventory.Name = "gridInventory";
            this.gridInventory.ReadOnly = true;
            this.gridInventory.RowHeadersVisible = false;
            this.gridInventory.RowTemplate.Height = 25;
            this.gridInventory.Size = new System.Drawing.Size(470, 154);
            this.gridInventory.TabIndex = 20;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.gridInventory);
            this.Controls.Add(this.gridQuests);
            this.Controls.Add(this.txtBoxMessages);
            this.Controls.Add(this.txtBoxLocation);
            this.Controls.Add(this.btnGoWest);
            this.Controls.Add(this.btnGoSouth);
            this.Controls.Add(this.btnGoEast);
            this.Controls.Add(this.btnGoNorth);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.label5);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridQuests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnGoNorth;
        private System.Windows.Forms.Button btnGoEast;
        private System.Windows.Forms.Button btnGoSouth;
        private System.Windows.Forms.Button btnGoWest;
        private System.Windows.Forms.RichTextBox txtBoxLocation;
        private System.Windows.Forms.RichTextBox txtBoxMessages;
        private System.Windows.Forms.DataGridView gridQuests;
        private System.Windows.Forms.DataGridView gridInventory;
    }
}

