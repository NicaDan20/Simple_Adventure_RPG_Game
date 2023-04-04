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
using System.IO;

namespace Adventure_RPG_Game
{
    public partial class Game : Form
    {
        private Player _player;
        private Monster _currentMonster;
        private const string PLAYER_DATA_FILE_NAME = "SaveGame.xml";
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
            _player = Player.CreateDefaultPlayer();
            InitializeUI();
        }

        // UI Initialization function; upon starting or loading a new game, we will apropriately show and name all the relevant UI
        // elements (buttons, panels, inventory, quest log etc)
        private void InitializeUI()
        {
            UpdatePlayerStats();
            LoadQuestDataGrid();
            LoadInventory();
            UpdateLocationTxtBox();
            CheckIfThereIsLocation();
            NameGoToBtns();
            CheckForQuests();
            ShowWeaponsDropDown();
            ShowPotionsDropDown();
            _player.PropertyChanged += PlayerOnPropertyChanged;
            LoadMonsterPanel();
            LoadCombatButtons();
            ShowPotionDetails();
            UpdateGameOverUI();
        }

        // toggles the display of the Game Over Panel, when the player dies
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

        // Whenever the player presses the Go To buttons the DoMove function is triggered
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
        //Upon changing to a new location, the Location Text Box will display a short text describing the entered Location.
        private void UpdateLocationTxtBox()
        {
            txtBoxLocation.Text = _player.CurrentLocation.Name + Environment.NewLine + _player.CurrentLocation.Description;
        }
        // A player can go North, South, East or West. There may or may not be a location available at these cardinal points. We want
        // to make sure that the move buttons are only available to locations that exist. E.g the player starts in his house, and the only
        // available location is East (to the Town Square). So we will hide the North, South and West buttons while keeping the East one
        // visible
        private void CheckIfThereIsLocation()
        {
            btnGoNorth.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToNorth != null);
            btnGoSouth.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToSouth != null);
            btnGoWest.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToWest != null);
            btnGoEast.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToEast != null);
        }
        // For better readability and to give a sense of geography, we will name the Go To buttons to show the name of the area they lead to. 
        // So instead of Go To East, a button will be named Go To Town Square
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
        
        // Areas can have quests attached to them. The Pick Up quest button is only displayed in areas which have quests.
        // The Turn in Quest button is visible only when the quest associated with the area has been picked up, and the quest
        // is not completed.
        private void CheckForQuests()
        {
            // We check if area has quest
            if (_player.CheckIfThereIsQuest(_player.CurrentLocation.QuestAvailableHere)) {
                // If true, we check if the quest is already in the player's quest log
                if (_player.CheckIfThereIsQuestInLog(_player.CurrentLocation.QuestAvailableHere))
                {
                    // if true, we hide the Pick Up Quest button, and make the Turn In Quest button visible
                    btnPickUpQuest.Visible = false;
                    btnTurnInQuest.Visible = true;
                    // If the quest is completed, the turn in quest becomes invisible as well
                    if (_player.CheckIfQuestIsCompleted(_player.CurrentLocation.QuestAvailableHere))
                    {
                        btnTurnInQuest.Visible = false;
                    }
                }
                else
                {
                    // If area has quest, but the quest is not in the player's log, the pick up quest button becomes visible
                    btnPickUpQuest.Visible = true;
                    btnTurnInQuest.Visible = false;
                }
            } else
            {
                // If the area has no quests, both Pick Up and Turn in Quest buttons will not be visible to the player
                btnPickUpQuest.Visible = false;
                btnTurnInQuest.Visible = false;
            }
        }
    
        private void btnPickUpQuest_Click(object sender, EventArgs e)
        {
            // We know that the pick up quest is interactible only when there is a quest in the area, so the player
            // will pick up the quest at the current location and send the appropriate messsage
            _player.PickUpQuest(_player.CurrentLocation.QuestAvailableHere);
            txtBoxMessages.Text += "You have accepted the following quest: " + _player.CurrentLocation.QuestAvailableHere.Name + "." + Environment.NewLine;
            txtBoxMessages.Text += Environment.NewLine;

            // We update the UI to hide the Pick Up button and show the Turn In button. We also refresh the Quest Log (represented by)
            // a data grid to show the recently accepted quest
            CheckForQuests();
        }

        // We create the data grid which contains information about the quests that the player accepted.
        private void LoadQuestDataGrid()
        {
            gridQuests.RowHeadersVisible = false;
            gridQuests.AutoGenerateColumns = false;
            gridQuests.DataSource = _player.Quests;
            gridQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 195,
                DataPropertyName = "Name"
            });
            gridQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                Width = 375,
                DataPropertyName = "Description"
            });
            gridQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Done?",
                Width = 50,
                DataPropertyName = "IsCompleted"
            });
            
        }

        // Load inventory function
        private void LoadInventory()
        {
            gridInventory.RowHeadersVisible = false;
            gridInventory.AutoGenerateColumns = false;
            gridInventory.DataSource = _player.Inventory;
            gridInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 525,
                DataPropertyName = "Description"
            });
            gridInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            });

        }

        // enable / disable the drop down if the player is / is not in combat
        private void ShowWeaponsDropDown()
        {
            cboWeapons.DataSource = _player.Weapons;
            cboWeapons.DisplayMember = "Name";
            cboWeapons.ValueMember = "Id";
            if (_player.EquippedWeapon != null)
            {
                cboWeapons.SelectedItem = _player.EquippedWeapon;
            }
            cboWeapons.SelectedIndexChanged += cboWeapons_SelectedIndexChanged;
        }

        // print out the damage done by the currently equipped weapon
        private void ShowWeaponDamage(Weapon selectedWeapon)
        {
            labelWeaponDamage.Text = "Damage: " + selectedWeapon.MinimumDamage + "-" + selectedWeapon.MaximumDamage;
        }

        // when the player changes his weapon, display the damage done
        private void cboWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            _player.EquippedWeapon = (Weapon)cboWeapons.SelectedItem;
            ShowWeaponDamage(GetActiveWeapon());
        }

        // same thing, but for potions
        private void ShowPotionsDropDown()
        {
            cboPotions.DataSource = _player.Potions;
            cboPotions.DisplayMember = "Name";
            cboPotions.ValueMember = "Id";
            if (_player.EquippedPotion != null)
            {
                cboPotions.SelectedItem = _player.EquippedPotion;
            }
            cboPotions.SelectedIndexChanged += cboPotions_SelectedIndexChanged;
        }
        
        private void PlayerOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Weapons")
            {
                Weapon equippedWeapon = _player.EquippedWeapon;
                cboWeapons.DataSource = _player.Weapons;
                if (equippedWeapon != null && _player.Weapons.Exists(w => w.ID == equippedWeapon.ID))
                {
                    cboWeapons.SelectedItem = equippedWeapon;
                }
                if (!_player.Weapons.Any())
                {
                    cboWeapons.Visible = false;
                    btnUseWeapon.Visible = false;
                }
            }
            if (args.PropertyName == "Potions")
            {
                HealingPotion equippedPotion = _player.EquippedPotion;
                cboPotions.DataSource = _player.Potions;
                if (equippedPotion != null && _player.Potions.Exists(p => p.ID == equippedPotion.ID))
                {
                    cboPotions.SelectedItem = equippedPotion;
                }
                if (!_player.Potions.Any())
                {
                    cboPotions.Visible = false;
                    btnUsePotion.Visible = false;
                }
            }
        }

        // display the amount healed by a potion
        private void ShowHPHealed()
        {
            labelHealFor.DataBindings.Add("Text", cboPotions.SelectedItem, "AmountHealed");
        }

        // display how many potions of that type the player currently has
        private void ShowPotionQuantity ()
        {
            //labelQuantity.DataBindings.Add("Text", _player.Potions, "Quantity");
        }

        private void ShowPotionDetails()
        {
            ShowHPHealed();
            ShowPotionQuantity();
        }
        // when the player changes his active potion, display the relevant information (quantity, amount healed)
        private void cboPotions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _player.EquippedPotion = (HealingPotion)cboPotions.SelectedItem;
        }

        // returns the selected potion
        private HealingPotion GetActivePotion()
        {
            return _player.EquippedPotion;
        }
        // returns the selected weapon
        private Weapon GetActiveWeapon()
        {
            return _player.EquippedWeapon;
        }

        private void CompleteQuest(Quest q)
        {
            // the function _player.CompleteQuest(q) returns a boolean based on whether the quest can be completed or not; 
            if (_player.CompleteQuest(q))
            {
                // if yes, display a message to notify the player of the quest completion
                txtBoxMessages.Text += Environment.NewLine + "You have completed the following quest: " + q.Name + "." + Environment.NewLine + "You receive " + q.RewardExperience + " Experience " + q.RewardGold + " Gold " + " and the following item: " + q.RewardItem.Name + "."  + Environment.NewLine;
                // refresh the relevant parts of the UI
                CheckForQuests();
                ScrollToBottomOfMessages();
            }
            else
            {
                // if not, send a message notifying the player that he cannot complete the quest yet
                txtBoxMessages.Text += "You cannot turn in this quest yet. You do not have the required items." + Environment.NewLine;
                ScrollToBottomOfMessages();
            }
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            PlayerHeal(GetActivePotion());
        }

        // Adds databinding for the various stats of the player character (Level, Experience Points, Gold and HP values)
        private void UpdatePlayerStats()
        {
            label_experience.DataBindings.Add("Text", _player, "ExperiencePoints");
            label_gold.DataBindings.Add("Text", _player, "Gold");
            label_player_hit_points.DataBindings.Add("Text", _player, "HitPoints");
            label_level.DataBindings.Add("Text", _player, "Level");
        }

        // The function responsible with the core movement of the game
        private void DoMove(Location _newLocation)
        {
            // Some areas may have a requirement to enter the new location, such as an item
            // We first check whether the player can enter the new area
            if (_player.CheckIfYouCanEnterLocation(_newLocation) == true)
            {
                // If true, we move the player to the new location (we simply change _player.CurrentLocation)
                _player.MoveTo(_newLocation);

                //We check if there are new locations, and update the UI accordingly
                CheckIfThereIsLocation();
                UpdateLocationTxtBox();
                NameGoToBtns();

                // We check if the new location has a quest associated;
                CheckForQuests();
                //RefreshWeaponComboBox();

                // We check if there is a monster in this area. If so, we will spawn it by changing the value of _currentMonster
                SpawnMonster();
                if (_currentMonster != null)
                {
                    // If the _currentMonster is not null, we enable the relevant parts of the UI (the monster panel
                    // the weapon and potion combo boxes
                    LoadCombatButtons();
                    LoadMonsterPanel();
                    LoadMonsterDetails();

                    // we set the player state to Combat, by default the player has the first turn
                    _player._curState = CombatState.PlayerTurn;

                    // the player should not be able to run away from a fight
                    DisableMoveToButtons();

                    // we start the combat function
                    DoCombatSequence();
                }
            }
            else
            {
                // If the player cannot enter the new area, we just display a message notifying
                txtBoxMessages.Text +=  "You cannot enter " + _newLocation.Name + " just yet. You need the " + _newLocation.ItemRequiredToEnter.Name + " to enter." + Environment.NewLine;
            }
        }

        // Spawn monster function
        private void SpawnMonster()
        {
            // Each area may or may not have a monster associated with it. We check whether the new location (in this case, the currentLocation)
            // because we already changed the new location to be current in the DoMove function
            if (_player.CurrentLocation.MonsterLivingHere != null)
            {
                // if there is a monster living here, we send out a message that notifies the player that they are encountering a monster
                txtBoxMessages.Text += "You see a " + _player.CurrentLocation.MonsterLivingHere.Name + Environment.NewLine;

                // we spawn a new monster
                Monster _monsterLivingHere = ObjectMapper.ReturnMonsterByID(_player.CurrentLocation.MonsterLivingHere.ID);
                _currentMonster = new(_monsterLivingHere.ID, _monsterLivingHere.CurrentHitPoints, _monsterLivingHere.MaximumHitPoints, _monsterLivingHere.Name,
                   _monsterLivingHere.RewardExperience, _monsterLivingHere.RewardGold, _monsterLivingHere.MaximumDamage, _monsterLivingHere.MinimumDamage);
                ScrollToBottomOfMessages();
                
                // add its appropriate loot table
                foreach (LootItem item in _monsterLivingHere.LootTable)
                {
                    _currentMonster.LootTable.Add(item);
                }

            } else
            {
                // otherwise we set the _currentMonster to be null
                _currentMonster = null;
            }
        }

        // Loads the relevant part of the UI responsible with showing Monster information.
        // In the monster panel, we display the name, the damage dealt, the maximum and current HP values
        private void LoadMonsterPanel()
        {
            if (_currentMonster != null)
            {
               panel_Monster.Visible = true;
            } else
            {
               panel_Monster.Visible = false;
            }
        }

        private void LoadMonsterDetails()
        {
            label_Monster_Name.DataBindings.Add("Text", _currentMonster, "Name");
            label_Monster_Damage_Values.DataBindings.Add("Text", _currentMonster, "Damage");
            label_Monster_HitPoints_Value.DataBindings.Add("Text", _currentMonster, "HitPoints");
        }

        private void UnLoadMonsterDetails()
        {
            label_Monster_Name.DataBindings.Clear();
            label_Monster_Damage_Values.DataBindings.Clear();
            label_Monster_HitPoints_Value.DataBindings.Clear();
        }

        // Wait function for the BackgroundWorker
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

        // The combat of this game is turn based, meaning that the player and the monster each trade turns. The monster will always attack
        // during its turn, while the player can either attack or use a healing potion
        private void DoCombatSequence()
        {
            //_player._curState is an Enum that represents the various states the player can find itself in.
            switch (_player._curState)
            {
                // enemy turn
                case CombatState.EnemyTurn:
                    {
                        // We disbale the potion and weapon buttons, because we do not want the player to use these buttons during the Monster's turn
                        btnUsePotion.Enabled = false;
                        btnUseWeapon.Enabled = false;
                        wait(800);

                        // We display the amount of damage the monster did to the player and update the relevant parts of the UI
                        int _damageDealt = _currentMonster.Attack(_player);
                        ShowDamageText(_currentMonster, _player, _damageDealt);

                        //After the player has done its attack, we either have two possibilities
                        if (_player.IsAlive())
                        {
                            // Either the player is alive, which means the CombatState changes to PlayerTurn, and that allows him to retaliate
                            _player._curState = CombatState.PlayerTurn;
                            
                        }
                        else
                        {
                            // Or the player is dead, which means the End Game screen is displayed
                            _player._curState = CombatState.PlayerIsDead;
                        }
                        // We call the CombatSequence function again
                        DoCombatSequence();
                        break;
                    }
                case CombatState.PlayerTurn:
                    {
                        //When it's the player's turn, we allow the usage of Weapon and Potion buttons
                        btnUsePotion.Enabled = true;
                        btnUseWeapon.Enabled = true;
                        break;
                    }
                case CombatState.PlayerIsDead:
                    {
                        // When the player is dead, we call the GameOver function, which hides all UI elements and enables the Game Over screen
                        GameOver(this);
                        break;
                    }
                case CombatState.EnemyIsDead:
                    {
                        // If the enemy is looted, we re-enable the MoveTo buttons, we receive the relevant gold and experience
                        // we loot items, we hide the Monster Panel and the Weapon/Potion buttons
                        EnableMoveToButtons();
                        ReceiveGoldAndExperience();
                        LootItems();
                        _currentMonster = null;
                        LoadMonsterPanel();
                        LoadCombatButtons();
                        UnLoadMonsterDetails();
                        _player._curState = CombatState.NotInCombat;
                        // We check whether or not the player has enough experience to level up
                        LevelUp();
                        break;
                    }
                case CombatState.EnemyIsLooted:
                    {
                        break;
                    }
                default:
                    {
                        // We shouldn't really get out of the predefinded CombatStates, but if we do then we do nothing
                        break;
                    }
            }
        }

        private void LevelUp()
        {
            // We call the _player.LevelUp() function, which returns a true (if leveled up) or false (if not leveled up)
            if (_player.LevelUp())
            {
                // If we do, we send a message and update the relevant parts of the UI
                txtBoxMessages.Text += "You have levelled up! You gain 8 HP!" + Environment.NewLine;
                ScrollToBottomOfMessages();
            }
        }

        // During combat we should not be able to move out to another area
        private void DisableMoveToButtons()
        {
            btnGoEast.Enabled = false;
            btnGoWest.Enabled = false;
            btnGoSouth.Enabled = false;
            btnGoNorth.Enabled = false;
        }

        // Once combat is over and the monster is dead, we can move to other areas once again
        private void EnableMoveToButtons()
        {
            btnGoEast.Enabled = true;
            btnGoWest.Enabled = true;
            btnGoSouth.Enabled = true;
            btnGoNorth.Enabled = true;
        }

        // During combat, we want to have the weapon/potion combobox and buttons enabled. In areas where we do not need to fight, we do not
        // actually want to have this part of the UI enabled
        private void LoadCombatButtons()
        {
           cboWeapons.Visible = _currentMonster != null;
           cboPotions.Visible = _currentMonster != null;
           btnUseWeapon.Visible = _currentMonster != null;
           btnUsePotion.Visible = _currentMonster != null;
        }

        // The player attack function, called whenever we click btnUseWeapon;
        private void PlayerAttack(Weapon _activeWeapon)
        {
            // We generate random damage based on the equipped weapon's damage values and display a message on how much damage we did
            // on the txtBoxMessages
            int _damageDealt = _player.Attack(_currentMonster, _activeWeapon);
            ShowDamageText(_player, _currentMonster, _damageDealt);
            
            // we update monster UI

            // Depending on the monster state, we have two options
            if (_currentMonster.IsAlive())
            {
                // If the monster is alive, it will be his turn to retaliate
                _player._curState = CombatState.EnemyTurn;
            } else
            {
                // If not, the player will get to loot the items
                _player._curState = CombatState.EnemyIsDead;
            }
            // Call the combat function
            DoCombatSequence();
        }

        // The player heal function, called whenever we click btnUsePotion
        private void PlayerHeal(HealingPotion _activePotion)
        {
            
            int _amountHealed = _activePotion.AmountToHeal;
            _player.UsePotion(_activePotion);
            ShowAmountHealedMessage(_amountHealed);
            if (_currentMonster.IsAlive())
            {
                _player._curState = CombatState.EnemyTurn;
            } else
            {
                _player._curState = CombatState.EnemyIsDead;
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

        // When the player dies, we hide all UI elements
        private void GameOver(Control parent)
        {
            
            foreach (Control c in parent.Controls)
            {
                c.Visible = false;
            }
            // And show the game over screen
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

        // Once combat is over, we show the relevant messages
        private void ReceiveGoldAndExperience()
        {
            txtBoxMessages.Text += Environment.NewLine;
            txtBoxMessages.Text += "You defeated the " + _currentMonster.Name + "." + Environment.NewLine;
            txtBoxMessages.Text += "You receive " + _currentMonster.RewardGold.ToString() + " Gold, " + _currentMonster.RewardExperience.ToString() + " Experience" + Environment.NewLine;
            _player.Gold += _currentMonster.RewardGold;
            _player.ExperiencePoints += _currentMonster.RewardExperience;
            ScrollToBottomOfMessages();
        }

        // The loot item function
        private void LootItems()
        {
            // We create a list of looted items
                List<InventoryItem> lootedItems = new();
            // We iterate through the monster's loot table
                foreach(LootItem item in _currentMonster.LootTable)
                {
                // We generate a random number and compare it with the drop chance
                    if (RandomNumberGenerator.GenerateNumber(1, 100) <= item.DropChance)
                    {
                    // If the roll chance is favorable, we add the item to the looted items list
                        lootedItems.Add(new InventoryItem(item.Details, 1));
                    }
                }
                if (lootedItems.Count == 0)
                {
                // If the dice roll has been unfavourable, we add the default item to the lootedItems list
                    foreach (LootItem item in _currentMonster.LootTable)
                    {
                        if (item.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(item.Details, 1));
                        }
                    }

                }
                // We then add the items to the player's inventory
                foreach(InventoryItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInventory(inventoryItem.Details, 1);
                    if (inventoryItem.Quantity == 1)
                   {
                    // And display message
                        txtBoxMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name;
                    } else
                    {
                        txtBoxMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural;
                    }
                    txtBoxMessages.Text += Environment.NewLine;
                    ScrollToBottomOfMessages();
            }
        }
        
        // If the player wants to try again, we will call a BackgroundWorker to asynchronously re-open the game;
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
            Game Game2 = new ();
            Game2.Show();
            this.Dispose(false);
        }

        // If the player does not want to try again, the game closes
        private void button_No_Try_Again_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void btnTurnInQuest_Click(object sender, EventArgs e)
        {
            CompleteQuest(_player.CurrentLocation.QuestAvailableHere);
        }
        
        // Whenever a new message is sent in the txtBoxMessages, we update the scroll to always be updated
        private void ScrollToBottomOfMessages()
        {
            txtBoxMessages.SelectionStart = txtBoxMessages.Text.Length;
            txtBoxMessages.ScrollToCaret();
        }

        private void btn_SaveGame_Click(object sender, EventArgs e)
        {
            // Serlializes the player
            File.WriteAllText(PLAYER_DATA_FILE_NAME, SaveGame.ToXMLString(_player, _currentMonster));
        }

        // Load game function
        private void btn_LoadGame_Click(object sender, EventArgs e)
        {
            // We load the player from the XML file
            _player = Player.CreatePlayerFromXMLString(File.ReadAllText(PLAYER_DATA_FILE_NAME));
            if (_player._curState != CombatState.NotInCombat)
            {
                // if the player's loaded state indicates that the player might be in combat
                // we load the monster he was fighting with, and initialize the ui
                _currentMonster = Monster.GetMonsterFromXML(File.ReadAllText(PLAYER_DATA_FILE_NAME));
                //InitializeUI();
                // and resume the combat sequence function
                DoCombatSequence();
            }
            else
            {
                // if the player's current state is Not in Combat, it means the player is not in combat... and we Initialize the UI as
                // normal
                //InitializeUI();
            }
        }
    }
}
