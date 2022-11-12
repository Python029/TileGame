using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace TileGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int spawn =0;
        int x1 = 0; int y1 = 0;
        int x2 = 0; int y2 = 0;
        int x3 = 0; int y3 = 0;
        int x4 = 0; int y4 = 0;
        int x5 = 0; int y5 = 0;
        int time = 30;
        bool b1=false;
        bool b2=false;
        bool b3=false;
        bool b4=false;
        bool b5=false;
        bool start = false;
        int correct = 0;
        int incorrect = 0;
        bool hs = false;
        Form2 f2 = new Form2();
        Form3 f3 = new Form3();
        Label box1 = new Label();
        Label box2 = new Label();
        Label box3 = new Label();
        Label box4 = new Label();
        Label box5 = new Label();
        double total = 0;
        double accuracy = 0;
        double score = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Font)
            {
                #region Add Boxes
                #region Box 1
                box1.Size = new Size(150, 150);
                box1.Location = new Point(160, -160);
                x1 = box1.Location.X;
                y1 = box1.Location.Y;
                box1.BackColor = Color.Red;
                this.Controls.Add(box1);
                #endregion
                #region Box 2
                box2.Size = new Size(150, 150);
                box2.Location = new Point(0, 0);
                x2 = box2.Location.X;
                y2 = box2.Location.Y;
                box2.BackColor = Color.Red;
                this.Controls.Add(box2);
                #endregion
                #region Box 3
                box3.Size = new Size(150, 150);
                box3.Location = new Point(320, 160);
                x3 = box3.Location.X;
                y3 = box3.Location.Y;
                box3.BackColor = Color.Red;
                this.Controls.Add(box3);
                #endregion
                #region Box 4
                box4.Size = new Size(150, 150);
                box4.Location = new Point(480, 320);
                x4 = box4.Location.X;
                y4 = box4.Location.Y;
                box4.BackColor = Color.Red;
                this.Controls.Add(box4);
                #endregion
                #region Box 5 
                box5.Size = new Size(150, 150);
                box5.Location = new Point(160, 480);
                x5 = box5.Location.X;
                y5 = box5.Location.Y;
                box5.BackColor = Color.Red;
                this.Controls.Add(box5);
                #endregion
                #endregion
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show($"Please make sure to install this font before continuing: Hurme Geometric Sans 1 Bold\nIf the font is installed, click Yes. If not, click No.\nIf you would like to continue without the designated font, Click Cancel.", "Font Required", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    Properties.Settings.Default.Font = true;
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    #region Add Boxes
                    #region Box 1
                    box1.Size = new Size(150, 150);
                    box1.Location = new Point(160, -160);
                    x1 = box1.Location.X;
                    y1 = box1.Location.Y;
                    box1.BackColor = Color.Red;
                    this.Controls.Add(box1);
                    #endregion
                    #region Box 2
                    box2.Size = new Size(150, 150);
                    box2.Location = new Point(0, 0);
                    x2 = box2.Location.X;
                    y2 = box2.Location.Y;
                    box2.BackColor = Color.Red;
                    this.Controls.Add(box2);
                    #endregion
                    #region Box 3
                    box3.Size = new Size(150, 150);
                    box3.Location = new Point(320, 160);
                    x3 = box3.Location.X;
                    y3 = box3.Location.Y;
                    box3.BackColor = Color.Red;
                    this.Controls.Add(box3);
                    #endregion
                    #region Box 4
                    box4.Size = new Size(150, 150);
                    box4.Location = new Point(480, 320);
                    x4 = box4.Location.X;
                    y4 = box4.Location.Y;
                    box4.BackColor = Color.Red;
                    this.Controls.Add(box4);
                    #endregion
                    #region Box 5 
                    box5.Size = new Size(150, 150);
                    box5.Location = new Point(160, 480);
                    x5 = box5.Location.X;
                    y5 = box5.Location.Y;
                    box5.BackColor = Color.Red;
                    this.Controls.Add(box5);
                    #endregion
                    #endregion
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Escape)
            {
                Application.Exit();
            }
            if (start && timer1.Enabled==true)
            {
                if (e.KeyCode == Keys.Q)
                {
                    ValidateQ();
                }
                else if (e.KeyCode == Keys.W)
                {
                    ValidateW();
                }
                else if (e.KeyCode == Keys.E)
                {
                    ValidateE();
                }
                else if (e.KeyCode == Keys.R)
                {
                    ValidateR();
                }
            }
            else if(start==false)
            {
                if(e.KeyCode==Keys.Space)
                {
                    start=true;
                    panel4.Location = new Point(-500,-500);
                    MoveBoxes();
                    timer1.Enabled = true;
                }
                else if(e.KeyCode==Keys.A)
                {
                    f2.ShowDialog();
                }
            }
        }        
        private void Endgame()
        {
            total = correct + incorrect;
            accuracy = Math.Round(100 * (correct / total), 2);
            score = Math.Round(correct * ((correct / total)),2);
            Highscore();
            if (hs == false)
            {
                DialogResult dialogResult = MessageBox.Show($"You correctly got {correct} boxes.\nYou had an accuracy of {accuracy}%", "Game Over", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else if(hs)
            {
                DialogResult dialogResult = MessageBox.Show($"Do you want to play again?", "Game Over", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
        private void SpawnNewBoxes()
        {
            if(b1)
            {
                spawn = rnd.Next(0, 4);
                y1 = -160;
                if(spawn == 0)
                {
                    x1 = 0;
                }
                else if(spawn==1)
                {
                    x1 = 160;
                }
                else if (spawn == 2)
                {
                    x1 = 320;
                }
                else if (spawn == 3)
                {
                    x1 = 480;
                }
                box1.Size = new Size(150, 150);
                box1.Location = new Point(x1, y1);
                box1.BackColor = Color.Red;
                this.Controls.Add(box1);
                b1 = false;
            }
            else if(b2)
            {
                spawn = rnd.Next(0, 4);
                y2 = -160;
                if (spawn == 0)
                {
                    x2 = 0;
                }
                else if (spawn == 1)
                {
                    x2 = 160;
                }
                else if (spawn == 2)
                {
                    x2 = 320;
                }
                else if (spawn == 3)
                {
                    x2 = 480;
                }
                box2.Size = new Size(150, 150);
                box2.Location = new Point(x2, y2);
                box2.BackColor = Color.Red;
                this.Controls.Add(box2);
                b2 = false;
            }
            else if(b3)
            {
                spawn = rnd.Next(0, 4);
                y3 = -160;
                if (spawn == 0)
                {
                    x3 = 0;
                }
                else if (spawn == 1)
                {
                    x3 = 160;
                }
                else if (spawn == 2)
                {
                    x3 = 320;
                }
                else if (spawn == 3)
                {
                    x3 = 480;
                }
                box3.Size = new Size(150, 150);
                box3.Location = new Point(x3, y3);
                box3.BackColor = Color.Red;
                this.Controls.Add(box3);
                b3 = false;
            }
            else if(b4)
            {
                spawn = rnd.Next(0, 4);
                y4 = -160;
                if (spawn == 0)
                {
                    x4 = 0;
                }
                else if (spawn == 1)
                {
                    x4 = 160;
                }
                else if (spawn == 2)
                {
                    x4 = 320;
                }
                else if (spawn == 3)
                {
                    x4 = 480;
                }
                box4.Size = new Size(150, 150);
                box4.Location = new Point(x4, y4);
                box4.BackColor = Color.Red;
                this.Controls.Add(box4);
                b4 = false;
            }
            else if(b5)
            {
                spawn = rnd.Next(0, 4);
                y5 = -160;
                if (spawn == 0)
                {
                    x5 = 0;
                }
                else if (spawn == 1)
                {
                    x5 = 160;
                }
                else if (spawn == 2)
                {
                    x5 = 320;
                }
                else if (spawn == 3)
                {
                    x5 = 480;
                }
                box5.Size = new Size(150, 150);
                box5.Location = new Point(x5, y5);
                box5.BackColor = Color.Red;
                this.Controls.Add(box5);
                b5 = false;
            }
        }
        private void ValidateQ()
        {
            if(box1.Location.X==0&&box1.Location.Y==640)
            {
                this.Controls.Remove(box1);
                b1 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box2.Location.X == 0 && box2.Location.Y == 640)
            {
                this.Controls.Remove(box2);
                b2 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box3.Location.X == 0 && box3.Location.Y == 640)
            {
                this.Controls.Remove(box3);
                b3 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box4.Location.X == 0 && box4.Location.Y == 640)
            {
                this.Controls.Remove(box4);                    
                b4 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box5.Location.X == 0 && box5.Location.Y == 640)
            {
                this.Controls.Remove(box5);
                b5 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else
            {
                incorrect++;
            }
        }
        private void ValidateW()
        {
            if (box1.Location.X == 160 && box1.Location.Y == 640)
            {
                this.Controls.Remove(box1);
                b1 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box2.Location.X == 160 && box2.Location.Y == 640)
            {
                this.Controls.Remove(box2);
                b2 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box3.Location.X == 160 && box3.Location.Y == 640)
            {
                this.Controls.Remove(box3);
                b3 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box4.Location.X == 160 && box4.Location.Y == 640)
            {
                this.Controls.Remove(box4);
                b4 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box5.Location.X == 160 && box5.Location.Y == 640)
            {
                this.Controls.Remove(box5);
                b5 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else
            {
                incorrect++;
            }
        }
        private void ValidateE()
        {
            if (box1.Location.X == 320 && box1.Location.Y == 640)
            {
                this.Controls.Remove(box1);
                b1 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box2.Location.X == 320 && box2.Location.Y == 640)
            {
                this.Controls.Remove(box2);
                b2 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box3.Location.X == 320 && box3.Location.Y == 640)
            {
                this.Controls.Remove(box3);
                b3 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box4.Location.X == 320 && box4.Location.Y == 640)
            {
                this.Controls.Remove(box4);
                b4 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box5.Location.X == 320 && box5.Location.Y == 640)
            {
                this.Controls.Remove(box5);
                b5 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else
            {
                incorrect++;
            }
        }
        private void ValidateR()
        {
            if (box1.Location.X == 480 && box1.Location.Y == 640)
            {
                this.Controls.Remove(box1);
                b1 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box2.Location.X == 480 && box2.Location.Y == 640)
            {
                this.Controls.Remove(box2);
                b2 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box3.Location.X == 480 && box3.Location.Y == 640)
            {
                this.Controls.Remove(box3);
                b3 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box4.Location.X == 480 && box4.Location.Y == 640)
            {
                this.Controls.Remove(box4);
                b4 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else if (box5.Location.X == 480 && box5.Location.Y == 640)
            {
                this.Controls.Remove(box5);
                b5 = true;
                SpawnNewBoxes();
                MoveBoxes();
                correct++;
            }
            else
            {
                incorrect++;
            }
        }
        private void MoveBoxes()
        {
            y1 += 160; box1.Location = new Point(x1, y1);
            y2 += 160; box2.Location = new Point(x2, y2);
            y3 += 160; box3.Location = new Point(x3, y3);
            y4 += 160; box4.Location = new Point(x4, y4);
            y5 += 160; box5.Location = new Point(x5, y5);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                lblTime.Text = $"{time}";
            }
            else 
            { 
                timer1.Enabled = false;
                Endgame();
            }
        }
        private void Highscore()
        {
            if(score > Properties.Settings.Default.First_S)
            {
                Properties.Settings.Default.Third_T = Properties.Settings.Default.Second_T;
                Properties.Settings.Default.Third_A = Properties.Settings.Default.Second_A;
                Properties.Settings.Default.Third_N = Properties.Settings.Default.Second_N;
                Properties.Settings.Default.Third_S = Properties.Settings.Default.Second_S;
                Properties.Settings.Default.Second_T = Properties.Settings.Default.First_T;
                Properties.Settings.Default.Second_A = Properties.Settings.Default.First_A;
                Properties.Settings.Default.Second_N = Properties.Settings.Default.First_N;
                Properties.Settings.Default.Second_S = Properties.Settings.Default.First_S;
                Properties.Settings.Default.First_T = correct;
                Properties.Settings.Default.First_A = accuracy;
                Properties.Settings.Default.First_S = score;
                Properties.Settings.Default.Save();
                DialogResult dialogResult = MessageBox.Show($"You acheived a new highscore.\nYou correctly got {correct} boxes.\nYou had an accuracy of {accuracy}%\nDo you want to see the leaderboard?", "Game Over", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    f3.ShowDialog();
                    hs = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
                
            }
            else if (score > Properties.Settings.Default.Second_S && score < Properties.Settings.Default.First_S)
            {
                Properties.Settings.Default.Third_T = Properties.Settings.Default.Second_T;
                Properties.Settings.Default.Third_A = Properties.Settings.Default.Second_A;
                Properties.Settings.Default.Third_N = Properties.Settings.Default.Second_N;
                Properties.Settings.Default.Third_S = Properties.Settings.Default.Second_S;
                Properties.Settings.Default.Second_T = correct;
                Properties.Settings.Default.Second_A = accuracy;
                Properties.Settings.Default.Second_S = score;
                Properties.Settings.Default.Save();
                DialogResult dialogResult = MessageBox.Show($"You got the second highest score.\nYou correctly got {correct} boxes.\nYou had an accuracy of {accuracy}%\nDo you want to see the leaderboard?", "Game Over", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    f3.ShowDialog();
                    hs = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else if (score > Properties.Settings.Default.Third_S && score < Properties.Settings.Default.Second_S)
            {
                Properties.Settings.Default.Third_T = correct;
                Properties.Settings.Default.Third_A = accuracy;
                Properties.Settings.Default.Third_S = score;
                Properties.Settings.Default.Save();
                DialogResult dialogResult = MessageBox.Show($"You got the third highest score.\nYou correctly got {correct} boxes.\nYou had an accuracy of {accuracy}%\nDo you want to see the leaderboard?", "Game Over", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    f3.ShowDialog();
                    hs = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
    }
}