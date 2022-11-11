using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            S1.Text = Properties.Settings.Default.First_S.ToString();
            A1.Text = Properties.Settings.Default.First_A.ToString();
            S2.Text = Properties.Settings.Default.Second_S.ToString();
            A2.Text = Properties.Settings.Default.Second_A.ToString();
            S3.Text = Properties.Settings.Default.Third_S.ToString();
            A3.Text = Properties.Settings.Default.Third_A.ToString();
            Properties.Settings.Default.Save();
            LabelLocations();
        }
        private void LabelLocations()
        {
            if (S1.Text.Length == 3)
            {
                S1.Location = new Point(332, 105);
            }
            if (S2.Text.Length == 3)
            {
                S2.Location = new Point(332, 168);
            }
            if (S3.Text.Length == 3)
            {    
                S3.Location = new Point(332, 228);
            }
            if (A1.Text.Length == 6)
            {
                A1.Location = new Point(496, 105);
            }
            if (A2.Text.Length == 6)
            {
                A2.Location = new Point(496, 168);
            }
            if (A3.Text.Length == 6)
            {
                A3.Location = new Point(496, 228);
            }
        }
    }
}
