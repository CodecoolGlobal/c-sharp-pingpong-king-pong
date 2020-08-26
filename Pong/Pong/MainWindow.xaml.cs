using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Threading.DispatcherTimer gameTickTimer = new System.Windows.Threading.DispatcherTimer();
        private Element paddle = new Element{Position = new Point(400,500), Height=15, Width = 160};
        private Element ball = new Element{Position = new Point(100,300), Height=20, Width = 20};
        private SolidColorBrush paddleColor = Brushes.Gold;
        private SolidColorBrush ballColor = Brushes.Red;
        private double timeInterval = 10;
        private int xSpeed = 3;
        private int ySpeed = 3;
        private int currentScore;  


        public MainWindow()
        {
            InitializeComponent();
            StartGame();
            gameTickTimer.Tick += GameTickTimer_Tick;

        }

        private void StartGame(){
            currentScore = 0;
            drawElement(paddle, paddleColor);
            drawElement(ball, ballColor);
            gameTickTimer.Interval = TimeSpan.FromMilliseconds(timeInterval);
            gameTickTimer.IsEnabled = true;
            GameArea.Focus();
            GameArea.KeyDown += Canvas_KeyDown;
        }

       private void GameTickTimer_Tick(object sender, EventArgs e)
        {
              moveBall(ball);
        }

        private void drawElement(Element element, SolidColorBrush elementColor)
        {
            element.UiElement = new Rectangle()
            {
                Width = element.Width,
                Height = element.Height,
                Fill = elementColor
            };
            Canvas.SetLeft(element.UiElement, element.Position.X);
            Canvas.SetTop(element.UiElement, element.Position.Y);
            
            GameArea.Children.Add(element.UiElement);

       }

        public void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 10;
            double y = paddle.Position.Y; 
            double x = paddle.Position.X;
            switch(e.Key)
            {
                case Key.Left:
                    if (x >= 0)
                    {
                        x -= distance;
                    }
                    break;
                case Key.Right:
                    if (x + paddle.Width <= GameArea.Width)
                    {
                        x += distance;
                    }
                    break;
            }

            GameArea.Children.Remove(paddle.UiElement);
            paddle.Position = new Point(x, y);

            drawElement(paddle, paddleColor);
        }

        private void moveBall(Element ball)
        {
            double x = ball.Position.X + xSpeed;
            double y = ball.Position.Y + ySpeed;

            if(x + ball.Width > GameArea.Width || (x < 0))
            {
                xSpeed *= -1;
            }

            if (y <= 0)
            {
                ySpeed *= -1;
            }

            if (y >= GameArea.Height)
            {
                GameArea.Children.Remove(ball.UiElement);

                Random random = new Random();

                ball.Position = new Point((double)random.Next(0 + 1, (int)GameArea.Width - 1), (double)0);
                drawElement(ball, ballColor);
                return;
            }

            if(x + ball.Width > paddle.Position.X && x <paddle.Position.X + paddle.Width)
            {
                if(y + ball.Height > paddle.Position.Y && y < paddle.Position.Y + paddle.Height)
                {
                    ySpeed = ySpeed * -1;
                    UpdateScore();

                    // Right paddle
                    if(x > paddle.Position.X + (paddle.Width / 2))
                    {
                        if (xSpeed < 0)
                        {
                            xSpeed *= -1;
                        }
                    }
                    // Left paddle
                    if(x < paddle.Position.X + (paddle.Width / 2))
                    {
                        if (xSpeed > 0) 
                        {
                            xSpeed *= -1;
                        }
                    }
                }
            }

            ball.Position = new Point(x,y);
            GameArea.Children.Remove(ball.UiElement);
            drawElement(ball, ballColor);
         }


        private void UpdateScore() 
        {
            currentScore++;
            this.ScoreDisplay.Text = currentScore.ToString();
        }

        private void UpdateLevel()
        {
            this.LevelDisplay.Text = timeInterval.ToString();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ShowScorePopup()
        {
            MessageBox.Show($"Congratulations! You reached {currentScore} points");
        }
    }
}
