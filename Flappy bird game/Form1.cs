using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_bird_game
{
    public partial class Form1 : Form
    {
        int speed = 8;
        int gravity = 5;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeDown.Left -= speed;
            pipeUp.Left -= speed;
            scoreText.Text = "Score: " + score;

            if (score % 20 == 0 && score != 0) speed++;

            restorePipes();

            if (checkBoundaries())
                endGame();
        }

        private void restorePipes()
        {
            if (pipeDown.Right < -30)
            {
                pipeDown.Left = 750;
                score++;
            }

            if (pipeUp.Left < -10)
            {
                pipeUp.Left = 900;
                score++;
            }
        }

        private bool checkBoundaries()
        {
            if (flappyBird.Bounds.IntersectsWith(pipeDown.Bounds)) return true;
            if (flappyBird.Bounds.IntersectsWith(pipeUp.Bounds)) return true;
            if (flappyBird.Bounds.IntersectsWith(ground.Bounds)) return true;
            if (flappyBird.Top < -20) return true;
            return false;
        }

        private void keyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Application.Restart();

            if (e.KeyCode == Keys.Escape)
                Close();

            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void keyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game over !!"; 
        }
    }
}
