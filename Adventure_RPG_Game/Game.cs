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
        }

        private void btnGoWest_Click(object sender, EventArgs e)
        {
            _player.MoveTo(_player.CurrentLocation.AdjacentLocations.LocationToWest);
            checkIfThereIsLocation();
            updateLocationTxtBox();
        }

        private void btnGoEast_Click(object sender, EventArgs e)
        {
            _player.MoveTo(_player.CurrentLocation.AdjacentLocations.LocationToEast);
            checkIfThereIsLocation();
            updateLocationTxtBox();
        }

        private void btnGoSouth_Click(object sender, EventArgs e)
        {
            _player.MoveTo(_player.CurrentLocation.AdjacentLocations.LocationToSouth);
            checkIfThereIsLocation();
            updateLocationTxtBox();
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
    }
}
