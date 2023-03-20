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

            Location location = new Location(1, "Home", "This is your home.");

            label_experience.Text = _player.ExperiencePoints.ToString();
            label_gold.Text = _player.Gold.ToString();
            label_hit_points.Text = _player.CurrentHitPoints.ToString() + "/" + _player.MaximumHitPoints.ToString();
            label_level.Text = _player.Level.ToString();

            System.Console.WriteLine("Hi");
            Trace.WriteLine(World.PopulateMonsters());
            
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

    }
}
