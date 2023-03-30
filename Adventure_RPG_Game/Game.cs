using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;


namespace Adventure_RPG_Game
{
    public enum CombatState { PlayerTurn, EnemyTurn, PlayerIsDead, EnemyIsDead, EnemyIsLooted, NotInCombat };
    public partial class Game : Form
    {
        private Player _player;
        private Monster _currentMonster;
        private CombatState curState;

        private BackgroundWorker _backgroundWorker1;

        public Game()
        {
            InitializeGame();
            _backgroundWorker1 = new();
            _backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            _backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
        }

        private void InitializeGame()
        {
            InitializeComponent();
            _player = new Player(20, 20, 0, 0, 1);
            _player.MoveTo(ObjectMapper.ReturnLocationByID(1));

            curState = CombatState.NotInCombat;

            UpdatePlayerStats();
            UpdateLocationTxtBox();
            CheckIfThereIsLocation();
            NameGoToBtns();
            CheckForQuests();
            RefreshQuestDataGrid();
            ShowWeaponsDropDown(RefreshWeaponComboBox());
            ShowPotionsDropDown(RefreshPotionComboBox());
            LoadInventory();
            SpawnMonster();
            LoadMonsterPanel();
            LoadCombatButtons();
            UpdateGameOverUI();

        }

        private void UpdateGameOverUI()
        {
            if (_player.IsAlive())
            {
               panel_Game_Over.Enabled = false;
               panel_Game_Over.Visible = false;
            } else
            {
                panel_Game_Over.Enabled = true;
                panel_Game_Over.Visible = true;
            }

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnGoNorth_Click(object sender, EventArgs e)
        {
            DoMove(_player.CurrentLocation.AdjacentLocations.LocationToNorth);
        }

        private void btnGoWest_Click(object sender, EventArgs e)
        {
            DoMove(_player.CurrentLocation.AdjacentLocations.LocationToWest);
        }

        private void btnGoEast_Click(object sender, EventArgs e)
        {
            DoMove(_player.CurrentLocation.AdjacentLocations.LocationToEast);
        }

        private void btnGoSouth_Click(object sender, EventArgs e)
        {
            DoMove(_player.CurrentLocation.AdjacentLocations.LocationToSouth);
        }
        private void UpdateLocationTxtBox()
        {
            txtBoxLocation.Text = _player.CurrentLocation.Name + Environment.NewLine + _player.CurrentLocation.Description;
        }
        private void CheckIfThereIsLocation()
        {
            btnGoNorth.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToNorth != null);
            btnGoSouth.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToSouth != null);
            btnGoWest.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToWest != null);
            btnGoEast.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToEast != null);
        }
        private void NameGoToBtns()
        {
            if (_player.CurrentLocation.AdjacentLocations.LocationToEast != null)
            {
                btnGoEast.Text = "Go to " + _player.CurrentLocation.AdjacentLocations.LocationToEast.Name;
            }
            if (_player.CurrentLocation.AdjacentLocations.LocationToWest != null)
            {
                btnGoWest.Text = "Go to " + _player.CurrentLocation.AdjacentLocations.LocationToWest.Name;
            }
            if (_player.CurrentLocation.AdjacentLocations.LocationToNorth != null)
            {
                btnGoNorth.Text = "Go to " + _player.CurrentLocation.AdjacentLocations.LocationToNorth.Name;
            }
            if (_player.CurrentLocation.AdjacentLocations.LocationToSouth != null)
            {
                btnGoSouth.Text = "Go to " + _player.CurrentLocation.AdjacentLocations.LocationToSouth.Name;
            }
        }
        
        private void CheckForQuests()
        {
            if (_player.CheckIfThereIsQuest(_player.CurrentLocation.QuestAvailableHere)) {
                if (_player.CheckIfThereIsQuestInLog(_player.CurrentLocation.QuestAvailableHere))
                {
                    btnPickUpQuest.Visible = false;
                    btnTurnInQuest.Visible = true;
                    if (_player.CheckIfQuestIsCompleted(_player.CurrentLocation.QuestAvailableHere))
                    {
                        btnTurnInQuest.Visible = false;
                    }
                }
                else
                {
                    btnPickUpQuest.Visible = true;
                    btnTurnInQuest.Visible = false;
                }
            } else
            {
                btnPickUpQuest.Visible = false;
                btnTurnInQuest.Visible = false;
            }
        }

        private void btnPickUpQuest_Click(object sender, EventArgs e)
        {
            _player.PickUpQuest(_player.CurrentLocation.QuestAvailableHere);
            txtBoxMessages.Text += "You have accepted the following quest: " + _player.CurrentLocation.QuestAvailableHere.Name + "." + Environment.NewLine;
            foreach (PlayerQuest pq in _player.Quests)
            {
                txtBoxMessages.Text += Environment.NewLine + "-" + pq.Details.Name;
            }
            txtBoxMessages.Text += Environment.NewLine;
            CheckForQuests();
            RefreshQuestDataGrid();
        }

        private void RefreshQuestDataGrid()
        {
            gridQuests.RowHeadersVisible = false;
            gridQuests.ColumnCount = 3;
            gridQuests.Columns[0].Name = "Quest";
            gridQuests.Columns[0].Width = 210;
            gridQuests.Columns[1].Name = "Description";
            gridQuests.Columns[1].Width = 327;
            gridQuests.Columns[2].Name = "Completed?";
            gridQuests.Rows.Clear();

            foreach (PlayerQuest pq in _player.Quests)
            {
                gridQuests.Rows.Add(new[] { pq.Details.Name, pq.Details.Description, pq.IsCompleted.ToString() });
            }
        }

        private List<Weapon> RefreshWeaponComboBox()
        {
            List<Weapon> weapons = new();
            foreach (InventoryItem item in _player.Inventory)
            {
                if (item.Details is Weapon weapon)
                {
                    if (item.Quantity > 0)
                    {
                        weapons.Add(weapon);
                    }
                }
            }
            return weapons;
        }

        private void ShowWeaponsDropDown(List<Weapon> weapons)
        {
            if (weapons.Count == 0)
            {
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";
                cboWeapons.SelectedIndex = 0;
                ShowWeaponDamage(weapons[0]);
            }
        }

        private void ShowWeaponDamage(Weapon selectedWeapon)
        {
            labelWeaponDamage.Text = "Damage: " + selectedWeapon.MinimumDamage + "-" + selectedWeapon.MaximumDamage;
        }

        private void cboWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Weapon> weapons = RefreshWeaponComboBox();
            ShowWeaponDamage(weapons[cboWeapons.SelectedIndex]);
        }

        private List<HealingPotion> RefreshPotionComboBox()
        {
            List<HealingPotion> healingPotions = new();
            foreach (InventoryItem item in _player.Inventory)
            {
                if (item.Details is HealingPotion potion)
                {
                    if (item.Quantity > 0)
                    {
                        healingPotions.Add(potion);
                    }
                }
            }
            return healingPotions;
        }

        private void ShowPotionsDropDown(List<HealingPotion> potions)
        {
            if (potions.Count == 0)
            {
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
                labelHealFor.Visible = false;
                labelQuantity.Visible = false;
            } else
            {
                cboPotions.Visible = true;
                btnUsePotion.Visible = true;
                labelHealFor.Visible = true;
                labelQuantity.Visible = true;
                cboPotions.DataSource = potions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";
                cboPotions.SelectedIndex = 0;
                ShowPotionDetails(potions[0]);
            }
        }

        private void ShowHPHealed(HealingPotion selectedPotion)
        {
            labelHealFor.Text = "Heal Amount: " + selectedPotion.AmountToHeal;
        }

        private void ShowPotionQuantity (HealingPotion selectedPotion)
        {  
            labelQuantity.Text = "Potions left: " + _player.ReturnQuantity(selectedPotion).ToString();
        }
        private void CompleteQuest(Quest q)
        {
            if (_player.CompleteQuest(q))
            {
                txtBoxMessages.Text += Environment.NewLine + "You have completed the following quest: " + q.Name + "." + Environment.NewLine + "You receive " + q.RewardExperience + " Experience " + q.RewardGold + " Gold " + " and the following item: " + q.RewardItem.Name + "."  + Environment.NewLine;
                LoadInventory();
                UpdatePlayerStats();
                RefreshQuestDataGrid();
                CheckForQuests();
                ScrollToBottomOfMessages();
            }
            else
            {
                txtBoxMessages.Text += "You cannot turn in this quest yet. You do not have the required items." + Environment.NewLine;
                ScrollToBottomOfMessages();
            }
        }

        private void ShowPotionDetails(HealingPotion selectedPotion)
        {
            ShowHPHealed(selectedPotion);
            ShowPotionQuantity(selectedPotion);
        }

        private void cboPotions_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<HealingPotion> potions = RefreshPotionComboBox();
            ShowPotionDetails(potions[cboPotions.SelectedIndex]);
        }

        private HealingPotion GetActivePotion()
        {
            return (HealingPotion)cboPotions.SelectedItem;
        }

        private Weapon GetActiveWeapon()
        {
            return (Weapon)cboWeapons.SelectedItem;
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            PlayerHeal(GetActivePotion());
        }

        private void UpdatePlayerStats()
        {
            label_experience.Text = _player.ExperiencePoints.ToString();
            label_gold.Text = _player.Gold.ToString();
            label_hit_points.Text = _player.CurrentHitPoints.ToString() + "/" + _player.MaximumHitPoints.ToString();
            label_level.Text = _player.Level.ToString();
        }

        private void DoMove(Location _newLocation)
        {
            if (_player.CheckIfYouCanEnterLocation(_newLocation) == true)
            {
                _player.MoveTo(_newLocation);
                CheckIfThereIsLocation();
                UpdateLocationTxtBox();
                NameGoToBtns();
                CheckForQuests();
                RefreshWeaponComboBox();
                SpawnMonster();
                if (_currentMonster != null)
                {
                    LoadCombatButtons();
                    LoadMonsterPanel();
                    curState = CombatState.PlayerTurn;
                    DisableMoveToButtons();
                    DoCombatSequence();
                }
            }
            else
            {
                txtBoxMessages.Text +=  "You cannot enter " + _newLocation.Name + " just yet. You need the " + _newLocation.ItemRequiredToEnter.Name + " to enter." + Environment.NewLine;
            }
        }

        private void LoadInventory()
        {
            gridInventory.RowHeadersVisible = false;
            gridInventory.ColumnCount = 2;
            gridInventory.Columns[0].Name = "Item";
            gridInventory.Columns[0].Width = 450;
            gridInventory.Columns[1].Name = "Quantity";
            gridInventory.Columns[1].Width = 200;
            gridInventory.Rows.Clear();

            foreach (InventoryItem item in _player.Inventory)
            {
                if (item.Details is MiscItem)
                {
                    gridInventory.Rows.Add(new[] { item.Details.Name, item.Quantity.ToString() });
                }
            }

        }

        private void SpawnMonster()
        {
            if (_player.CurrentLocation.MonsterLivingHere != null)
            {
                txtBoxMessages.Text += "You see a " + _player.CurrentLocation.MonsterLivingHere.Name + Environment.NewLine;
                Monster _monsterLivingHere = ObjectMapper.ReturnMonsterByID(_player.CurrentLocation.MonsterLivingHere.ID);
                _currentMonster = new(_monsterLivingHere.ID, _monsterLivingHere.CurrentHitPoints, _monsterLivingHere.MaximumHitPoints, _monsterLivingHere.Name,
                   _monsterLivingHere.RewardExperience, _monsterLivingHere.RewardGold, _monsterLivingHere.MaximumDamage, _monsterLivingHere.MinimumDamage);
                ScrollToBottomOfMessages();

                foreach (LootItem item in _monsterLivingHere.LootTable)
                {
                    _currentMonster.LootTable.Add(item);
                }

                //enter combat


            } else
            {
                _currentMonster = null;
            }
        }

        private void LoadMonsterPanel()
        {
            if (_currentMonster != null)
            {
                panel_Monster.Visible = true;
                UpdateMonsterDetails();   
            } else
            {
                panel_Monster.Visible = false;
            }
        }

        private void UpdateMonsterDetails()
        {
            label_Monster_Name.Text = _currentMonster.Name.ToString();
            label_Monster_HitPoints_Value.Text = _currentMonster.CurrentHitPoints + "/" + _currentMonster.MaximumHitPoints;
            label_Monster_Damage_Values.Text = _currentMonster.MinimumDamage + "-" + _currentMonster.MaximumDamage;
        }
        private void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        private void DoCombatSequence()
        {
            switch (curState)
            {
                case CombatState.EnemyTurn:
                    {
                        btnUsePotion.Enabled = false;
                        btnUseWeapon.Enabled = false;
                        wait(1000);
                        int _damageDealt = _currentMonster.Attack(_player);
                        ShowDamageText(_currentMonster, _player, _damageDealt);
                        UpdatePlayerStats();
                        if (_player.IsAlive())
                        {
                            curState = CombatState.PlayerTurn;
                            
                        }
                        else
                        {
                            curState = CombatState.PlayerIsDead;
                        }
                        DoCombatSequence();
                        break;
                    }
                case CombatState.PlayerTurn:
                    {
                        btnUsePotion.Enabled = true;
                        btnUseWeapon.Enabled = true;
                        
                        break;
                    }
                case CombatState.PlayerIsDead:
                    {
                        GameOver(this);
                        break;
                    }
                case CombatState.EnemyIsDead:
                    {
                        EnableMoveToButtons();
                        ReceiveGoldAndExperience();
                        LootItems();
                        _currentMonster = null;
                        LoadMonsterPanel();
                        LoadCombatButtons();
                        LevelUp();
                        break;
                    }
                case CombatState.EnemyIsLooted:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void LevelUp()
        {
            if (_player.LevelUp())
            {
                txtBoxMessages.Text += "You have levelled up! You gain 8 HP!" + Environment.NewLine;
                ScrollToBottomOfMessages();
                UpdatePlayerStats();
            }
        }

        private void DisableMoveToButtons()
        {
            btnGoEast.Enabled = false;
            btnGoWest.Enabled = false;
            btnGoSouth.Enabled = false;
            btnGoNorth.Enabled = false;
        }

        private void EnableMoveToButtons()
        {
            btnGoEast.Enabled = true;
            btnGoWest.Enabled = true;
            btnGoSouth.Enabled = true;
            btnGoNorth.Enabled = true;
        }

        private void LoadCombatButtons()
        {
                cboWeapons.Visible = _currentMonster != null;
                cboPotions.Visible = _currentMonster != null;
                btnUseWeapon.Visible = _currentMonster != null;
                btnUsePotion.Visible = _currentMonster != null;
        }

        private void PlayerAttack(Weapon _activeWeapon)
        {
            int _damageDealt = _player.Attack(_currentMonster, _activeWeapon);
            ShowDamageText(_player, _currentMonster, _damageDealt);
            UpdateMonsterDetails();
            if (_currentMonster.IsAlive())
            {
                curState = CombatState.EnemyTurn;
            } else
            {
                curState = CombatState.EnemyIsDead;
            }
            DoCombatSequence();
        }

        private void PlayerHeal(HealingPotion _activePotion)
        {
            int _amountHealed = _activePotion.AmountToHeal;
            _player.UsePotion(_activePotion);
            UpdatePlayerStats();
            ShowAmountHealedMessage(_amountHealed);
            ShowPotionsDropDown(RefreshPotionComboBox());
            if (_currentMonster.IsAlive())
            {
                curState = CombatState.EnemyTurn;
            } else
            {
                curState = CombatState.EnemyIsDead;
            }
            DoCombatSequence();
        }

        private void ShowAmountHealedMessage(int _amountHealed)
        {
            txtBoxMessages.Text += "You drank a healing potion, restoring " + _amountHealed + " Hit Points." + Environment.NewLine;
            ScrollToBottomOfMessages();
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            PlayerAttack(GetActiveWeapon());
        }

        private void GameOver(Control parent)
        {
            
            foreach (Control c in parent.Controls)
            {
                c.Visible = false;
            }
            UpdateGameOverUI();
        }

        private void ShowDamageText(LivingCreature attacker, LivingCreature defender, int damageDealt)
        {
            if (attacker is Monster mA)
            {
                txtBoxMessages.Text += mA.Name + " deals " + damageDealt.ToString() + " damage to you!" + Environment.NewLine;
            }
            if (defender is Monster mD)
            {
                txtBoxMessages.Text += "You deal " + damageDealt.ToString() + " damage to " + mD.Name + Environment.NewLine;
            }
            ScrollToBottomOfMessages();
        }

        private void ReceiveGoldAndExperience()
        {
            txtBoxMessages.Text += Environment.NewLine;
            txtBoxMessages.Text += "You defeated the " + _currentMonster.Name + "." + Environment.NewLine;
            txtBoxMessages.Text += "You receive " + _currentMonster.RewardGold.ToString() + " Gold, " + _currentMonster.RewardExperience.ToString() + " Experience" + Environment.NewLine;
            _player.Gold += _currentMonster.RewardGold;
            _player.ExperiencePoints += _currentMonster.RewardExperience;
            UpdatePlayerStats();
            ScrollToBottomOfMessages();
        }

        private void LootItems()
        {
                List<InventoryItem> lootedItems = new();
                foreach(LootItem item in _currentMonster.LootTable)
                {
                    if (RandomNumberGenerator.GenerateNumber(1, 100) <= item.DropChance)
                    {
                        lootedItems.Add(new InventoryItem(item.Details, 1));
                    }
                }
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem item in _currentMonster.LootTable)
                    {
                        if (item.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(item.Details, 1));
                        }
                    }

                }
                foreach(InventoryItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInventory(inventoryItem.Details, 1);
                    if (inventoryItem.Quantity == 1)
                   {
                        txtBoxMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name;
                    } else
                    {
                        txtBoxMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural;
                    }
                    txtBoxMessages.Text += Environment.NewLine;
                    ScrollToBottomOfMessages();
            }
            LoadInventory();
        }

        private void button_Try_Again_Click(object sender, EventArgs e)
        {
            _backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Game Game2 = new Game();
            Game2.Show();
            this.Dispose(false);
        }

        private void button_No_Try_Again_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void btnTurnInQuest_Click(object sender, EventArgs e)
        {
            CompleteQuest(_player.CurrentLocation.QuestAvailableHere);
        }

        private void ScrollToBottomOfMessages()
        {
            txtBoxMessages.SelectionStart = txtBoxMessages.Text.Length;
            txtBoxMessages.ScrollToCaret();
        }

    }
}
