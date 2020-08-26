﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

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
        private bool paused = false;
        private DispatcherTimer globalTimer;
        private const int MAX_TIME_IN_SECONDS = 180;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
            gameTickTimer.Tick += GameTickTimer_Tick;
            timeProgressBar.Maximum = MAX_TIME_IN_SECONDS;
        }

        private void StartGame(){
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
                    if (x >= 0 && !paused)
                    {
                        x -= distance;
                    }
                    break;
                case Key.Right:
                    if (x + paddle.Width <= GameArea.Width && !paused)
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    if (!paused)
                    {
                        StopScreen();
                    }
                    btnMessageBoxWithDefaultChoice_Click(sender, e);
                    StopScreen();
                    pauseMessage.Visibility = TogglePauseMessage();
                    break;

                case Key.Space:
                    StopScreen();
                    pauseMessage.Visibility = TogglePauseMessage();
                    break;
            }
        }

        private void btnMessageBoxWithDefaultChoice_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to quit the game?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Environment.Exit(0);
                    break;

                case MessageBoxResult.No:
                    return;
            }
        }

        private Visibility TogglePauseMessage()
        {
            return pauseMessage.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void StopScreen()
        {
            if (paused)
            {
                paused = false;
                gameTickTimer.Start();
                globalTimer.Start();
            }
            else
            {
                paused = true;
                gameTickTimer.Stop();
                globalTimer.Stop();
            }
        }

        private void ProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            globalTimer = new DispatcherTimer();
            globalTimer.Interval = new TimeSpan(0, 0, 1);
            globalTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            globalTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timeProgressBar.Value += 1;
            if (timeProgressBar.Value >= 180)
            {
                globalTimer.Stop();
            }
        }
    }
}
