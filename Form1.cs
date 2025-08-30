using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        int basePipeSpeed = 12; // Base pipe speed
        int baseCloudSpeed = 8; // Base cloud speed
        int gravity = 10; // Default gravity
        int score = 0; // Default score
        int speedIncrement = 1; // Speed increment factor
        int maxPipeSpeed = 20; // Maximum pipe speed
        int maxCloudSpeed = 20; // Maximum cloud speed

        SoundPlayer backgroundPlayer = new SoundPlayer("D:/MarioPhonk.wav");
        SoundPlayer gameOverPlayer = new SoundPlayer("D:/GameOver.wav");

        Label lblGameOver; // Label for Game Over message
        Label lblCountdown; // Label for countdown timer
        Timer delayTimer; // Timer for delay before showing menu
        Timer countdownTimer; // Timer for countdown
        int countdownValue; // Countdown value

        public Form1()
        {
            InitializeComponent();

            InitializeGameOverLabel();
            InitializeCountdownLabel(); // Initialize the countdown label
            InitializeDelayTimer(); // Initialize the delay timer
            InitializeCountdownTimer(); // Initialize the countdown timer
            ShowMenu(); // Show menu on form load
        }

        private void InitializeGameOverLabel()
        {
            // Initialize the Game Over label
            lblGameOver = new Label
            {
                Text = "", // Initially empty
                Font = new Font("Arial", 30, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(300, 200),
                AutoSize = true,
                Visible = false // Hidden initially
            };
            this.Controls.Add(lblGameOver);
        }

        private void InitializeCountdownLabel()
        {
            // Initialize the Countdown label
            lblCountdown = new Label
            {
                Text = "", // Initially empty
                Font = new Font("Arial", 50, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(350, 200),
                AutoSize = true,
                Visible = false // Hidden initially
            };
            this.Controls.Add(lblCountdown);
        }

        private void InitializeDelayTimer()
        {
            // Initialize the delay timer
            delayTimer = new Timer();
            delayTimer.Interval = 3000; // Set delay to 3 seconds
            delayTimer.Tick += DelayTimer_Tick; // Subscribe to the Tick event
        }

        private void InitializeCountdownTimer()
        {
            // Initialize the countdown timer
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // Set interval to 1 second
            countdownTimer.Tick += CountdownTimer_Tick; // Subscribe to the Tick event
        }

        private void ShowMenu()
        {
            // Show the menu panel and hide score
            menuPanel.Visible = true;
            scoreText.Visible = false;
            lblGameOver.Visible = false;
            lblCountdown.Visible = false; // Hide countdown label

            // Show stationary bird and pipes
            flappyBird.Visible = true;
            pipeTop.Visible = true;
            pipeBottom.Visible = true;
            ground.Visible = true;

            // Stop background music and ensure game objects don't move
            backgroundPlayer.Stop();
            gameTimer.Stop();
        }

        private void StartGame()
        {
            // Hide the menu panel and enable game elements
            menuPanel.Visible = false;
            scoreText.Visible = true;

            lblGameOver.Visible = false; // Hide the Game Over label

            // Reset game variables
            score = 0; // Reset score
            scoreText.Text = "Score: " + score; // Reset score display

            // Reset speeds to base values
            basePipeSpeed = 8; // Reset pipe speed to base
            baseCloudSpeed = 8; // Reset cloud speed to base

            // Reset positions of game objects
            flappyBird.Top = 200; // Reset bird position
            pipeTop.Left = 900; // Reset top pipe position
            pipeBottom.Left = 500; // Reset bottom pipe position

            // Start the countdown
            countdownValue = 3; // Set countdown to 3 seconds
            lblCountdown.Text = countdownValue.ToString(); // Display countdown
            lblCountdown.Visible = true; // Show countdown label
            countdownTimer.Start(); // Start the countdown timer
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--; // Decrease countdown value
            lblCountdown.Text = countdownValue.ToString(); // Update countdown display

            if (countdownValue <= 0)
            {
                countdownTimer.Stop(); // Stop the countdown timer
                lblCountdown.Visible = false; // Hide countdown label

                // Start the background music and game timer
                backgroundPlayer.PlayLooping();
                gameTimer.Start();
            }
        }

        private void endGame()
        {
            // Stop the game timer and background music
            gameTimer.Stop();
            backgroundPlayer.Stop();

            // Play the game-over sound
            gameOverPlayer.Play();

            // Display the Game Over label
            lblGameOver.Text = "Game Over! Score: " + score;
            lblGameOver.Visible = true;

            // Start the delay timer
            delayTimer.Start();
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            // Stop the delay timer
            delayTimer.Stop();

            // Show the menu again
            ShowMenu();
        }

        private void QuitGame()
        {
            // Exit the application
            Application.Exit();
        }

        private void ShowCredits()
        {
            // Show credits message box
            MessageBox.Show("Flappy Bird Game\nDeveloped by Malik\n© 2024", "Credits");
        }

        Random random = new Random();
        private void gameTimerEvent(object sender, EventArgs e)
        {
            // Allow game components to move only after the game starts
            flappyBird.Top += gravity; // Apply gravity to the bird
            pipeBottom.Left -= basePipeSpeed; // Move the bottom pipe
            pipeTop.Left -= basePipeSpeed; // Move the top pipe
            cloud.Left -= baseCloudSpeed; // Move the cloud
            clouds3.Left -= baseCloudSpeed; // Move the third cloud
            scoreText.Text = "Score: " + score; // Update the score text

            // Reset pipe positions and increment score
            if (pipeBottom.Left < -100)
            {
                pipeBottom.Left = random.Next(1800, 2200);
                pipeBottom.Top = random.Next(300, 500); // Randomize bottom pipe position
                score++;
            }
            if (pipeTop.Left < -100)
            {
                pipeTop.Left = random.Next(1800, 2200);
                pipeTop.Top = pipeBottom.Top - pipeBottom.Height - 150; // Maintain a gap
                score++;
            }
            if (cloud.Left < -350)
            {
                cloud.Left = random.Next(1200, 1600); // Randomize cloud position
                cloud.Top = random.Next(50, 300);    // Randomize cloud height
            }

            if (clouds3.Left < -350)
            {
                clouds3.Left = random.Next(1200, 1600); // Randomize clouds3 position
                clouds3.Top = random.Next(50, 300);    // Randomize clouds3 height
            }

            // Check for collisions or out-of-bounds
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25)
            {
                endGame();
            }

            // Increase speed based on score but cap it at max speed
            if (score > 0 && score % 10 == 0)
            {
                if (basePipeSpeed < maxPipeSpeed)
                {
                    basePipeSpeed += speedIncrement; // Increase pipe speed
                    baseCloudSpeed += speedIncrement; // Increase cloud speed
                }
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            // If the space key is pressed, set gravity to -10 (jump)
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            // If the space key is released, set gravity back to 10 (fall)
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        // Event handlers for menu labels
        private void lblStartGame_Click(object sender, EventArgs e)
        {
            StartGame(); // Start the game
        }

        private void lblCredits_Click(object sender, EventArgs e)
        {
            ShowCredits(); // Show credits
        }

        private void lblQuit_Click(object sender, EventArgs e)
        {
            QuitGame(); // Quit the application
        }
    }
}