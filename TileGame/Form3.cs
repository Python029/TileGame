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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }
        
        Form2 f2 = new Form2();
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Properties.Settings.Default.Initials = txtInitials.Text;
                Properties.Settings.Default.First_N = Properties.Settings.Default.Initials;
                Properties.Settings.Default.Initials = "";
                Properties.Settings.Default.Save();
                f2.ShowDialog();
                this.Close();                   
            }
        }
    }
}
