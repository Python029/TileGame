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
            T1.Text = Properties.Settings.Default.First_T.ToString();
            A1.Text = Properties.Settings.Default.First_A.ToString() + "%";
            N1.Text = Properties.Settings.Default.First_N.ToUpper();
            S1.Text = Properties.Settings.Default.First_S.ToString();
            T2.Text = Properties.Settings.Default.Second_T.ToString();
            A2.Text = Properties.Settings.Default.Second_A.ToString() + "%";
            N2.Text = Properties.Settings.Default.Second_N.ToUpper();
            S2.Text = Properties.Settings.Default.Second_S.ToString();
            T3.Text = Properties.Settings.Default.Third_T.ToString();
            A3.Text = Properties.Settings.Default.Third_A.ToString() + "%";
            N3.Text = Properties.Settings.Default.Third_N.ToUpper();
            S3.Text = Properties.Settings.Default.Third_S.ToString();
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.First_T == 0 && Properties.Settings.Default.First_A == 0)
            {
                T1.Location = new Point(328, 105); A1.Location = new Point(495, 105); S1.Location = new Point(672, 105);
            }
            if (Properties.Settings.Default.Second_T==0 && Properties.Settings.Default.Second_A==0)
            {
                T2.Location = new Point(328, 166); A2.Location = new Point(495, 166); S2.Location = new Point(672, 166);
            }
            if (Properties.Settings.Default.Third_T == 0 && Properties.Settings.Default.Third_A == 0)
            {
                T3.Location = new Point(328, 228); A3.Location = new Point(495, 228); S3.Location = new Point(672, 228);
            }
        }      
        private void ResetLabels()
        {
            T1.Location = new Point(328, 105); A1.Location = new Point(495, 105); S1.Location = new Point(672, 105);
            T2.Location = new Point(328, 166); A2.Location = new Point(495, 166); S2.Location = new Point(672, 166);
            T3.Location = new Point(328, 228); A3.Location = new Point(495, 228); S3.Location = new Point(672, 228);
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if(e.KeyCode == Keys.Oemtilde)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Font = true;
                Properties.Settings.Default.Save();
                MessageBox.Show("Scores Reset");
                ResetLabels();
                this.Close();
            }
        }
    }
}
