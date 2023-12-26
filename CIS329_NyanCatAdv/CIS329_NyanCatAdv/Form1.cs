using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;

namespace CIS329_NyanCatAdv
{
    public partial class gameScreen : Form
    {
        List<OvalPictureBox> starList = new List<OvalPictureBox>();
        Random rnd = new Random();
        SoundPlayer bgm;
        SoundPlayer soundEffect;
        int catPulseSpeed_Y = 0;
        public int score { set; get; }
        bool gameStart = false;
        bool gamePause = false;
        bool gameOver = false;
        int spawnPeriod = 25;
        int spawnTime = 1;
        int maxStarOnScreen = 4;
        int blackHoleCount = 0;

        public gameScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            debug.Visible = false;
            pauseMsg.Visible = false;
            scoreDisplay.Visible = false;
            bgm = new SoundPlayer(@"NyanCat.wav");
            bgm.PlayLooping();
            soundEffect = new SoundPlayer(@"meow.wav");
        }

        private void timerEvent(object sender, EventArgs e)
        {
            spawnTime -= 1;

            if (starList.Count < maxStarOnScreen && spawnTime < 1)
            {
                spawnStar();
                spawnTime = spawnPeriod;                
            }

            if (score % 100 == 0 && score != 0 && blackHoleCount < 1)
            {
                spawnBlackHole();
                spawnTime = spawnPeriod;
                blackHoleCount += 1;
            }

            foreach (OvalPictureBox star in starList.ToList())
            {
                star.Left -= star.baseSpeed;

                if (star.Right < 0) {
                    starList.Remove(star);
                    this.Controls.Remove(star);
                    if (star.name == "blackhole")
                    {
                        blackHoleCount -= 1;
                        score += 50;
                    } else
                    {
                        score += 10;
                    }
                    scoreDisplay.Text = "Score: " + score;
                }

                double d = distCatStar(nyanCat, star);
                int dir = gravityDirection(nyanCat, star);
                double gravity = dir * Math.Max(1, star.gravityConstant / Math.Pow(d, 2));
                nyanCat.Top += catPulseSpeed_Y + Convert.ToInt32(Math.Round(gravity));
                //debug.Text = "star gravity: " + gravity;
                //debug.Text += "\ndistance: " + d;

                if (d < minDistCatStar(nyanCat, star))
                {
                    endGameFunc();
                }

               //debug.Text += "\nmin distance: " + minDistCatStar(nyanCat, star);
            }

            if (nyanCat.Top < -nyanCat.Height ||
                nyanCat.Bottom > this.Height + nyanCat.Height)
            {
                endGameFunc();
            }
        }

        private void controlKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && gameStart && catPulseSpeed_Y > -10)
            {
                catPulseSpeed_Y -= 2;
                soundEffect.Play();
            }

            if (e.KeyCode == Keys.Down && gameStart && catPulseSpeed_Y < 10)
            {
                catPulseSpeed_Y += 2;
                soundEffect.Play();
            }

            if (e.KeyCode == Keys.Space && !gamePause && !gameOver && gameStart)
            {
                gameTimer.Stop();
                gamePause = true;
                pauseMsg.Visible = true;
            } else if (e.KeyCode == Keys.Space && gamePause && !gameOver && gameStart)
            {
                gameTimer.Start();
                gamePause = false;
                pauseMsg.Visible = false;
            }

            if (e.KeyCode == Keys.Enter && !gameStart)
            {
                startGameFunc();
            }

            if (e.KeyCode == Keys.T && !gameStart)
            {
                // Ensure there is only ONE Tutorial Dialog is opened.
                closeAllForms();

                // Display the tutorial window
                TutorialScreen tutorialScreen = new TutorialScreen();
                tutorialScreen.Show();
            }
        }

        private void controlKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                catPulseSpeed_Y = 0;
            }

            if (e.KeyCode == Keys.Down)
            {
                catPulseSpeed_Y = 0;
            }
        }

        private void startGameFunc()
        {
            gameStart = true;
            gamePause = false;
            gameOver = false;
            gameTimer.Start();
            menuTimer.Stop();
            gameTitle.Visible = false;
            startMenu.Visible = false;
            nyanCat.Top = Convert.ToInt32(this.Height * 0.5);
            catPulseSpeed_Y = 0;
            score = 0;
            scoreDisplay.Text = "Score: " + score;
            scoreDisplay.Visible = true;
            foreach (OvalPictureBox star in starList.ToList())
            {
                starList.Remove(star);
                this.Controls.Remove(star);
            }
            closeAllForms();
            bgm.Stop();
        }

        private void endGameFunc()
        {
            gamePause = false;
            gameStart = false;
            gameOver = true;
            gameTimer.Stop();
            startMenu.Visible = true;

            LeaderBoard leaderBoardWindow = new LeaderBoard(this);
            leaderBoardWindow.Show();
            bgm.PlayLooping();
        }

        private void spawnStar()
        {
            OvalPictureBox new_star = new OvalPictureBox();
            Color[] randColor = {Color.Red, Color.Blue, Color.Orange};

            new_star.name = "star";
            new_star.baseSpeed = rnd.Next(7, 10);
            new_star.gravityConstant = 60000;

            new_star.Height = rnd.Next(50, 81);
            new_star.Width = new_star.Height;
            new_star.BackColor = randColor[rnd.Next(0, randColor.Length)];
            new_star.Left = this.Width;
            new_star.Top = rnd.Next(0, this.Height - new_star.Height);

            starList.Add(new_star);

            this.Controls.Add(new_star);
        }

        private void spawnBlackHole()
        {
            OvalPictureBox new_star = new OvalPictureBox();

            new_star.name = "blackhole";
            new_star.baseSpeed = 7;
            new_star.gravityConstant = 150000;

            new_star.Height = rnd.Next(40, 91);
            new_star.Width = new_star.Height;
            new_star.BackColor = Color.FromArgb(25, 25, 25);
            new_star.Left = this.Width;
            new_star.Top = rnd.Next(0, this.Height - new_star.Height);

            starList.Add(new_star);

            this.Controls.Add(new_star);
        }

        private double distCatStar(PictureBox nyanCat, OvalPictureBox star)
        {
            double starCenterX = Convert.ToDouble(star.Width) * 0.5 + Convert.ToDouble(star.Left);
            double starCenterY = Convert.ToDouble(star.Height) * 0.5 + Convert.ToDouble(star.Top);
            double nyanCatCenterX = Convert.ToDouble(nyanCat.Width) * 0.5 + Convert.ToDouble(nyanCat.Left);
            double nyanCatCenterY = Convert.ToDouble(nyanCat.Height) * 0.5 + Convert.ToDouble(nyanCat.Top);
          

            return Math.Sqrt(Math.Pow(nyanCatCenterX - starCenterX, 2) + Math.Pow(nyanCatCenterY - starCenterY, 2));
        }

        private int gravityDirection(PictureBox nyanCat, OvalPictureBox star)
        {
            double starCenterY = Convert.ToDouble(star.Height) * 0.5 + Convert.ToDouble(star.Top);
            double nyanCatCenterY = Convert.ToDouble(nyanCat.Height) * 0.5 + Convert.ToDouble(nyanCat.Top);
            if (starCenterY - nyanCatCenterY >= 0)
            {
                return 1;
            } else
            {
                return -1;
            }
        }

        private double minDistCatStar(PictureBox nyanCat, OvalPictureBox star)
        {
            double starCenterX = Convert.ToDouble(star.Width) * 0.5 + Convert.ToDouble(star.Left);
            double starCenterY = Convert.ToDouble(star.Height) * 0.5 + Convert.ToDouble(star.Top);
            double nyanCatCenterX = Convert.ToDouble(nyanCat.Width) * 0.5 + Convert.ToDouble(nyanCat.Left);
            double nyanCatCenterY = Convert.ToDouble(nyanCat.Height) * 0.5 + Convert.ToDouble(nyanCat.Top);

            // Min distance between the cat and star = radius of star + distance from center of cat to rectangular boundary
            // It is a function of angle, if angle = 0 -> min_dist = star_radius + cat width / 2
            // if angle = 0 -> min_dist = star_radius + cat width / 2
            // if angle = pi/2 -> min_dist = star_radius + cat height / 2

            double tanDiagonalAngle = Convert.ToDouble(nyanCat.Height) / Convert.ToDouble(nyanCat.Width);
            // debug.Text += "\ntanDiagonalAngle: " + tanDiagonalAngle;
            double tanStarCatAngle = Math.Abs(nyanCatCenterY - starCenterY) / Math.Abs(nyanCatCenterX - starCenterX);
            // debug.Text += "\ntanStarCatAngle: " + tanStarCatAngle;

            if (tanStarCatAngle < tanDiagonalAngle)
            {
                return Convert.ToDouble(star.Width) * 0.5 + 
                    Math.Sqrt(Math.Pow(Convert.ToDouble(nyanCat.Width) * 0.5, 2) + 
                    Math.Pow(nyanCat.Width * tanStarCatAngle * 0.5, 2));
            } else if (tanStarCatAngle > tanDiagonalAngle)
            {
                return Convert.ToDouble(star.Width) * 0.5 + 
                    Math.Sqrt(Math.Pow(Convert.ToDouble(nyanCat.Height) * 0.5, 2) + 
                    Math.Pow(Convert.ToDouble(nyanCat.Height) / tanStarCatAngle * 0.5, 2));
            } else
            {
                return Convert.ToDouble(star.Width) * 0.5 + 
                    Math.Sqrt(Math.Pow(Convert.ToDouble(nyanCat.Width) * 0.5, 2) + 
                    Math.Pow(Convert.ToDouble(nyanCat.Height) * 0.5, 2));
            }

        }

        private void menuTimer_Tick(object sender, EventArgs e)
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

            nyanCat.Top += Convert.ToInt32(10 * Math.Sin(2*Math.PI*now.ToUnixTimeMilliseconds()/5000));
            
        }

        private void closeAllForms()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
            {
                openForms.Add(f);
            }
            foreach (Form f in openForms.ToList())
            {
                if (f.Name != "gameScreen")
                {
                    openForms.Remove(f);
                    f.Close();
                }
            }
        }
    }
}
