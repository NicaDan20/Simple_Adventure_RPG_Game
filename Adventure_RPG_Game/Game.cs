using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Adventure_RPG_Game
{
    public partial class Game : Form
    {
        private Player _player;
        public Game()
        {
            InitializeComponent();
            _player = new Player(20, 20, 0, 0, 1);
            _player.MoveTo(ObjectMapper.ReturnLocationByID(1));
            label_experience.Text = _player.ExperiencePoints.ToString();
            label_gold.Text = _player.Gold.ToString();
            label_hit_points.Text = _player.CurrentHitPoints.ToString() + "/" + _player.MaximumHitPoints.ToString();
            label_level.Text = _player.Level.ToString();
            updateLocationTxtBox();
            checkIfThereIsLocation();
            nameGoToBtns();
            checkForQuests();
            refreshQuestDataGrid();
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
            _player.MoveTo(_player.CurrentLocation.AdjacentLocations.LocationToNorth);
            checkIfThereIsLocation();
            updateLocationTxtBox();
            nameGoToBtns();
            checkForQuests();
        }

        private void btnGoWest_Click(object sender, EventArgs e)
        {
            _player.MoveTo(_player.CurrentLocation.AdjacentLocations.LocationToWest);
            checkIfThereIsLocation();
            updateLocationTxtBox();
            nameGoToBtns();
            checkForQuests();

        }

        private void btnGoEast_Click(object sender, EventArgs e)
        {
            _player.MoveTo(_player.CurrentLocation.AdjacentLocations.LocationToEast);
            checkIfThereIsLocation();
            updateLocationTxtBox();
            nameGoToBtns();
            checkForQuests();

        }

        private void btnGoSouth_Click(object sender, EventArgs e)
        {
            _player.MoveTo(_player.CurrentLocation.AdjacentLocations.LocationToSouth);
            checkIfThereIsLocation();
            updateLocationTxtBox();
            nameGoToBtns();
            checkForQuests();

        }
        private void updateLocationTxtBox()
        {
            txtBoxLocation.Text = _player.CurrentLocation.Name + Environment.NewLine + _player.CurrentLocation.Description;
        }
        private void checkIfThereIsLocation()
        {
            btnGoNorth.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToNorth != null);
            btnGoSouth.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToSouth != null);
            btnGoWest.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToWest != null);
            btnGoEast.Visible = (_player.CurrentLocation.AdjacentLocations.LocationToEast != null);
        }
        private void nameGoToBtns()
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
        
        private void checkForQuests()
        {
            if (_player.checkIfThereIsQuest(_player.CurrentLocation.QuestAvailableHere)) {
                if (_player.checkIfThereIsQuestInLog(_player.CurrentLocation.QuestAvailableHere))
                {
                    btnPickUpQuest.Visible = false;
                } else
                {
                    btnPickUpQuest.Visible = true;
                }
            } else
            {
                btnPickUpQuest.Visible = false;
            }
        }

        private void btnPickUpQuest_Click(object sender, EventArgs e)
        {
            _player.pickUpQuest(_player.CurrentLocation.QuestAvailableHere);
            txtBoxMessages.Text += "You have accepted the following quest: " + _player.CurrentLocation.QuestAvailableHere.Name + Environment.NewLine;
            foreach (PlayerQuest pq in _player.Quests)
            {
                txtBoxMessages.Text += Environment.NewLine + "-" + pq.Details.Name;
            }
            checkForQuests();
            refreshQuestDataGrid();
        }

        private void refreshQuestDataGrid()
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
    }
}
