
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnPickUpQuest = new System.Windows.Forms.Button();
            this.btnTurnInQuest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelWeaponDamage = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelHealFor = new System.Windows.Forms.Label();
            this.panel_Monster = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label_Monster_Damage_Values = new System.Windows.Forms.Label();
            this.label_Monster_Damage = new System.Windows.Forms.Label();
            this.label_Monster_HitPoints_Value = new System.Windows.Forms.Label();
            this.label_Monster_HitPoints = new System.Windows.Forms.Label();
            this.label_Monster_Name = new System.Windows.Forms.Label();
            this.label_Game_Over = new System.Windows.Forms.Label();
            this.label_Try_Again = new System.Windows.Forms.Label();
            this.button_Try_Again = new System.Windows.Forms.Button();
            this.button_No_Try_Again = new System.Windows.Forms.Button();
            this.panel_Game_Over = new System.Windows.Forms.Panel();
            this.btn_SaveGame = new System.Windows.Forms.Button();
            this.btn_LoadGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
            this.panel_Monster.SuspendLayout();
            this.panel_Game_Over.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.LawnGreen;
            this.label1.Location = new System.Drawing.Point(19, 15);
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
            this.label2.Location = new System.Drawing.Point(354, 15);
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
            this.label3.Location = new System.Drawing.Point(552, 15);
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
            this.label4.Location = new System.Drawing.Point(208, 15);
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
            this.label_hit_points.Location = new System.Drawing.Point(112, 15);
            this.label_hit_points.Name = "label_hit_points";
            this.label_hit_points.Size = new System.Drawing.Size(0, 18);
            this.label_hit_points.TabIndex = 4;
            // 
            // label_gold
            // 
            this.label_gold.AutoSize = true;
            this.label_gold.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_gold.ForeColor = System.Drawing.Color.Gold;
            this.label_gold.Location = new System.Drawing.Point(264, 15);
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
            this.label_experience.Location = new System.Drawing.Point(453, 15);
            this.label_experience.Name = "label_experience";
            this.label_experience.Size = new System.Drawing.Size(0, 18);
            this.label_experience.TabIndex = 6;
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_level.ForeColor = System.Drawing.Color.DeepPink;
            this.label_level.Location = new System.Drawing.Point(615, 15);
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
            this.label5.Location = new System.Drawing.Point(12, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select Action";
            // 
            // cboWeapons
            // 
            this.cboWeapons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(104, 75);
            this.cboWeapons.MaxDropDownItems = 10;
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(121, 23);
            this.cboWeapons.TabIndex = 9;
            this.cboWeapons.SelectedIndexChanged += new System.EventHandler(this.cboWeapons_SelectedIndexChanged);
            // 
            // cboPotions
            // 
            this.cboPotions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(103, 114);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(121, 23);
            this.cboPotions.TabIndex = 10;
            this.cboPotions.SelectedIndexChanged += new System.EventHandler(this.cboPotions_SelectedIndexChanged);
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(12, 74);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(75, 23);
            this.btnUseWeapon.TabIndex = 11;
            this.btnUseWeapon.Text = "Attack";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Location = new System.Drawing.Point(12, 113);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(75, 23);
            this.btnUsePotion.TabIndex = 12;
            this.btnUsePotion.Text = "Use";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // btnGoNorth
            // 
            this.btnGoNorth.BackColor = System.Drawing.SystemColors.Menu;
            this.btnGoNorth.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGoNorth.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoNorth.Location = new System.Drawing.Point(73, 204);
            this.btnGoNorth.Name = "btnGoNorth";
            this.btnGoNorth.Size = new System.Drawing.Size(133, 23);
            this.btnGoNorth.TabIndex = 13;
            this.btnGoNorth.UseVisualStyleBackColor = false;
            this.btnGoNorth.Click += new System.EventHandler(this.btnGoNorth_Click);
            // 
            // btnGoEast
            // 
            this.btnGoEast.BackColor = System.Drawing.SystemColors.Menu;
            this.btnGoEast.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGoEast.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoEast.Location = new System.Drawing.Point(151, 233);
            this.btnGoEast.Name = "btnGoEast";
            this.btnGoEast.Size = new System.Drawing.Size(133, 23);
            this.btnGoEast.TabIndex = 14;
            this.btnGoEast.UseVisualStyleBackColor = false;
            this.btnGoEast.Click += new System.EventHandler(this.btnGoEast_Click);
            // 
            // btnGoSouth
            // 
            this.btnGoSouth.BackColor = System.Drawing.SystemColors.Menu;
            this.btnGoSouth.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGoSouth.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoSouth.Location = new System.Drawing.Point(73, 262);
            this.btnGoSouth.Name = "btnGoSouth";
            this.btnGoSouth.Size = new System.Drawing.Size(133, 23);
            this.btnGoSouth.TabIndex = 15;
            this.btnGoSouth.UseVisualStyleBackColor = false;
            this.btnGoSouth.Click += new System.EventHandler(this.btnGoSouth_Click);
            // 
            // btnGoWest
            // 
            this.btnGoWest.BackColor = System.Drawing.SystemColors.Menu;
            this.btnGoWest.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGoWest.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoWest.Location = new System.Drawing.Point(10, 233);
            this.btnGoWest.Name = "btnGoWest";
            this.btnGoWest.Size = new System.Drawing.Size(133, 23);
            this.btnGoWest.TabIndex = 16;
            this.btnGoWest.UseVisualStyleBackColor = false;
            this.btnGoWest.Click += new System.EventHandler(this.btnGoWest_Click);
            // 
            // txtBoxLocation
            // 
            this.txtBoxLocation.Location = new System.Drawing.Point(12, 333);
            this.txtBoxLocation.Name = "txtBoxLocation";
            this.txtBoxLocation.ReadOnly = true;
            this.txtBoxLocation.Size = new System.Drawing.Size(272, 154);
            this.txtBoxLocation.TabIndex = 17;
            this.txtBoxLocation.Text = "";
            // 
            // txtBoxMessages
            // 
            this.txtBoxMessages.Location = new System.Drawing.Point(12, 494);
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
            this.gridQuests.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridQuests.Enabled = false;
            this.gridQuests.Location = new System.Drawing.Point(302, 475);
            this.gridQuests.MultiSelect = false;
            this.gridQuests.Name = "gridQuests";
            this.gridQuests.ReadOnly = true;
            this.gridQuests.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.gridQuests.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridQuests.RowTemplate.Height = 25;
            this.gridQuests.RowTemplate.ReadOnly = true;
            this.gridQuests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridQuests.Size = new System.Drawing.Size(620, 126);
            this.gridQuests.TabIndex = 19;
            // 
            // gridInventory
            // 
            this.gridInventory.AllowUserToAddRows = false;
            this.gridInventory.AllowUserToDeleteRows = false;
            this.gridInventory.AllowUserToResizeColumns = false;
            this.gridInventory.AllowUserToResizeRows = false;
            this.gridInventory.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridInventory.Enabled = false;
            this.gridInventory.Location = new System.Drawing.Point(302, 314);
            this.gridInventory.MultiSelect = false;
            this.gridInventory.Name = "gridInventory";
            this.gridInventory.ReadOnly = true;
            this.gridInventory.RowHeadersVisible = false;
            this.gridInventory.RowTemplate.Height = 25;
            this.gridInventory.Size = new System.Drawing.Size(620, 154);
            this.gridInventory.TabIndex = 20;
            // 
            // btnPickUpQuest
            // 
            this.btnPickUpQuest.Location = new System.Drawing.Point(10, 154);
            this.btnPickUpQuest.Name = "btnPickUpQuest";
            this.btnPickUpQuest.Size = new System.Drawing.Size(102, 23);
            this.btnPickUpQuest.TabIndex = 21;
            this.btnPickUpQuest.Text = "Pick up Quest";
            this.btnPickUpQuest.UseVisualStyleBackColor = true;
            this.btnPickUpQuest.Click += new System.EventHandler(this.btnPickUpQuest_Click);
            // 
            // btnTurnInQuest
            // 
            this.btnTurnInQuest.Location = new System.Drawing.Point(119, 154);
            this.btnTurnInQuest.Name = "btnTurnInQuest";
            this.btnTurnInQuest.Size = new System.Drawing.Size(105, 23);
            this.btnTurnInQuest.TabIndex = 22;
            this.btnTurnInQuest.Text = "Turn In Quest";
            this.btnTurnInQuest.UseVisualStyleBackColor = true;
            this.btnTurnInQuest.Click += new System.EventHandler(this.btnTurnInQuest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "label6";
            // 
            // labelWeaponDamage
            // 
            this.labelWeaponDamage.AutoSize = true;
            this.labelWeaponDamage.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWeaponDamage.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelWeaponDamage.Location = new System.Drawing.Point(231, 74);
            this.labelWeaponDamage.Name = "labelWeaponDamage";
            this.labelWeaponDamage.Size = new System.Drawing.Size(0, 18);
            this.labelWeaponDamage.TabIndex = 24;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelQuantity.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelQuantity.Location = new System.Drawing.Point(231, 120);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(0, 18);
            this.labelQuantity.TabIndex = 25;
            // 
            // labelHealFor
            // 
            this.labelHealFor.AutoSize = true;
            this.labelHealFor.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHealFor.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelHealFor.Location = new System.Drawing.Point(354, 120);
            this.labelHealFor.Name = "labelHealFor";
            this.labelHealFor.Size = new System.Drawing.Size(0, 18);
            this.labelHealFor.TabIndex = 26;
            // 
            // panel_Monster
            // 
            this.panel_Monster.Controls.Add(this.label7);
            this.panel_Monster.Controls.Add(this.label_Monster_Damage_Values);
            this.panel_Monster.Controls.Add(this.label_Monster_Damage);
            this.panel_Monster.Controls.Add(this.label_Monster_HitPoints_Value);
            this.panel_Monster.Controls.Add(this.label_Monster_HitPoints);
            this.panel_Monster.Controls.Add(this.label_Monster_Name);
            this.panel_Monster.Location = new System.Drawing.Point(626, 61);
            this.panel_Monster.Name = "panel_Monster";
            this.panel_Monster.Size = new System.Drawing.Size(230, 116);
            this.panel_Monster.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(103, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 18);
            this.label7.TabIndex = 28;
            this.label7.Text = "Enemy";
            // 
            // label_Monster_Damage_Values
            // 
            this.label_Monster_Damage_Values.AutoSize = true;
            this.label_Monster_Damage_Values.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Monster_Damage_Values.ForeColor = System.Drawing.Color.Crimson;
            this.label_Monster_Damage_Values.Location = new System.Drawing.Point(91, 79);
            this.label_Monster_Damage_Values.Name = "label_Monster_Damage_Values";
            this.label_Monster_Damage_Values.Size = new System.Drawing.Size(31, 18);
            this.label_Monster_Damage_Values.TabIndex = 4;
            this.label_Monster_Damage_Values.Text = "1-4";
            // 
            // label_Monster_Damage
            // 
            this.label_Monster_Damage.AutoSize = true;
            this.label_Monster_Damage.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Monster_Damage.ForeColor = System.Drawing.Color.Crimson;
            this.label_Monster_Damage.Location = new System.Drawing.Point(3, 79);
            this.label_Monster_Damage.Name = "label_Monster_Damage";
            this.label_Monster_Damage.Size = new System.Drawing.Size(73, 18);
            this.label_Monster_Damage.TabIndex = 3;
            this.label_Monster_Damage.Text = "Damage:";
            // 
            // label_Monster_HitPoints_Value
            // 
            this.label_Monster_HitPoints_Value.AutoSize = true;
            this.label_Monster_HitPoints_Value.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Monster_HitPoints_Value.ForeColor = System.Drawing.Color.Crimson;
            this.label_Monster_HitPoints_Value.Location = new System.Drawing.Point(91, 54);
            this.label_Monster_HitPoints_Value.Name = "label_Monster_HitPoints_Value";
            this.label_Monster_HitPoints_Value.Size = new System.Drawing.Size(55, 18);
            this.label_Monster_HitPoints_Value.TabIndex = 2;
            this.label_Monster_HitPoints_Value.Text = "20/20";
            // 
            // label_Monster_HitPoints
            // 
            this.label_Monster_HitPoints.AutoSize = true;
            this.label_Monster_HitPoints.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Monster_HitPoints.ForeColor = System.Drawing.Color.Crimson;
            this.label_Monster_HitPoints.Location = new System.Drawing.Point(3, 54);
            this.label_Monster_HitPoints.Name = "label_Monster_HitPoints";
            this.label_Monster_HitPoints.Size = new System.Drawing.Size(82, 18);
            this.label_Monster_HitPoints.TabIndex = 1;
            this.label_Monster_HitPoints.Text = "Hit Points";
            // 
            // label_Monster_Name
            // 
            this.label_Monster_Name.AutoSize = true;
            this.label_Monster_Name.Font = new System.Drawing.Font("Maiandra GD", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Monster_Name.ForeColor = System.Drawing.Color.Coral;
            this.label_Monster_Name.Location = new System.Drawing.Point(77, 26);
            this.label_Monster_Name.Name = "label_Monster_Name";
            this.label_Monster_Name.Size = new System.Drawing.Size(112, 18);
            this.label_Monster_Name.TabIndex = 0;
            this.label_Monster_Name.Text = "label_Monster";
            // 
            // label_Game_Over
            // 
            this.label_Game_Over.AutoSize = true;
            this.label_Game_Over.Font = new System.Drawing.Font("Maiandra GD", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Game_Over.ForeColor = System.Drawing.Color.Red;
            this.label_Game_Over.Location = new System.Drawing.Point(26, 21);
            this.label_Game_Over.Name = "label_Game_Over";
            this.label_Game_Over.Size = new System.Drawing.Size(344, 72);
            this.label_Game_Over.TabIndex = 28;
            this.label_Game_Over.Text = "Game Over";
            this.label_Game_Over.UseMnemonic = false;
            // 
            // label_Try_Again
            // 
            this.label_Try_Again.AutoSize = true;
            this.label_Try_Again.Font = new System.Drawing.Font("Maiandra GD", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Try_Again.ForeColor = System.Drawing.Color.Red;
            this.label_Try_Again.Location = new System.Drawing.Point(92, 93);
            this.label_Try_Again.Name = "label_Try_Again";
            this.label_Try_Again.Size = new System.Drawing.Size(196, 43);
            this.label_Try_Again.TabIndex = 29;
            this.label_Try_Again.Text = "Try Again?";
            // 
            // button_Try_Again
            // 
            this.button_Try_Again.Location = new System.Drawing.Point(100, 151);
            this.button_Try_Again.Name = "button_Try_Again";
            this.button_Try_Again.Size = new System.Drawing.Size(75, 23);
            this.button_Try_Again.TabIndex = 30;
            this.button_Try_Again.Text = "Yes";
            this.button_Try_Again.UseVisualStyleBackColor = true;
            this.button_Try_Again.Click += new System.EventHandler(this.button_Try_Again_Click);
            // 
            // button_No_Try_Again
            // 
            this.button_No_Try_Again.Location = new System.Drawing.Point(221, 151);
            this.button_No_Try_Again.Name = "button_No_Try_Again";
            this.button_No_Try_Again.Size = new System.Drawing.Size(75, 23);
            this.button_No_Try_Again.TabIndex = 31;
            this.button_No_Try_Again.Text = "No";
            this.button_No_Try_Again.UseVisualStyleBackColor = true;
            this.button_No_Try_Again.Click += new System.EventHandler(this.button_No_Try_Again_Click);
            // 
            // panel_Game_Over
            // 
            this.panel_Game_Over.Controls.Add(this.label_Game_Over);
            this.panel_Game_Over.Controls.Add(this.button_No_Try_Again);
            this.panel_Game_Over.Controls.Add(this.label_Try_Again);
            this.panel_Game_Over.Controls.Add(this.button_Try_Again);
            this.panel_Game_Over.Location = new System.Drawing.Point(290, 183);
            this.panel_Game_Over.Name = "panel_Game_Over";
            this.panel_Game_Over.Size = new System.Drawing.Size(406, 185);
            this.panel_Game_Over.TabIndex = 32;
            // 
            // btn_SaveGame
            // 
            this.btn_SaveGame.Location = new System.Drawing.Point(750, 10);
            this.btn_SaveGame.Name = "btn_SaveGame";
            this.btn_SaveGame.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveGame.TabIndex = 33;
            this.btn_SaveGame.Text = "Save Game";
            this.btn_SaveGame.UseVisualStyleBackColor = true;
            this.btn_SaveGame.Click += new System.EventHandler(this.btn_SaveGame_Click);
            // 
            // btn_LoadGame
            // 
            this.btn_LoadGame.Location = new System.Drawing.Point(831, 10);
            this.btn_LoadGame.Name = "btn_LoadGame";
            this.btn_LoadGame.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadGame.TabIndex = 34;
            this.btn_LoadGame.Text = "Load Game";
            this.btn_LoadGame.UseVisualStyleBackColor = true;
            this.btn_LoadGame.Click += new System.EventHandler(this.btn_LoadGame_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.btn_LoadGame);
            this.Controls.Add(this.btn_SaveGame);
            this.Controls.Add(this.panel_Game_Over);
            this.Controls.Add(this.panel_Monster);
            this.Controls.Add(this.labelHealFor);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelWeaponDamage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTurnInQuest);
            this.Controls.Add(this.btnPickUpQuest);
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
            this.panel_Monster.ResumeLayout(false);
            this.panel_Monster.PerformLayout();
            this.panel_Game_Over.ResumeLayout(false);
            this.panel_Game_Over.PerformLayout();
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
        private System.Windows.Forms.Button btnPickUpQuest;
        private System.Windows.Forms.Button btnTurnInQuest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelWeaponDamage;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelHealFor;
        private System.Windows.Forms.Panel panel_Monster;
        private System.Windows.Forms.Label label_Monster_HitPoints_Value;
        private System.Windows.Forms.Label label_Monster_HitPoints;
        private System.Windows.Forms.Label label_Monster_Name;
        private System.Windows.Forms.Label label_Monster_Damage_Values;
        private System.Windows.Forms.Label label_Monster_Damage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_Game_Over;
        private System.Windows.Forms.Label label_Try_Again;
        private System.Windows.Forms.Button button_Try_Again;
        private System.Windows.Forms.Button button_No_Try_Again;
        private System.Windows.Forms.Panel panel_Game_Over;
        private System.Windows.Forms.Button btn_SaveGame;
        private System.Windows.Forms.Button btn_LoadGame;
    }
}

