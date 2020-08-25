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
        private Element paddle = new Element{Position = new Point(525,300), Height=15, Width = 150};
        private Element ball = new Element{Position = new Point(100,300), Height=20, Width = 20};
        private SolidColorBrush paddleColor = Brushes.Gold;
        private SolidColorBrush ballColor = Brushes.Red;
        private double BallStarterSpeed = 10;
        private int xSpeed = 1;
        private int ySpeed = 1;


        public MainWindow()
        {
            InitializeComponent();
            StartGame();
            gameTickTimer.Tick += GameTickTimer_Tick;

        }


        private void StartGame(){
            drawElement(paddle, paddleColor);
            drawElement(ball, ballColor);
            gameTickTimer.Interval = TimeSpan.FromMilliseconds(BallStarterSpeed);
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
            int distance = 40;
            double y = paddle.Position.Y; 
            double x = paddle.Position.X;
            switch(e.Key)
            {
                case Key.Left:
                    x -= distance;
                    break;
                case Key.Right:
                    x += distance;
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
            Console.WriteLine(x);
                  
            if (y == 535){
            Console.WriteLine("ok");
            }


            if(x > GameArea.Width || (x < 0))
            { 
                xSpeed = xSpeed * -1;
            }
            if(y > GameArea.Height || (y < 0))
            { 
                ySpeed = ySpeed * -1;
            }


            ball.Position = new Point(x,y);
            GameArea.Children.Remove(ball.UiElement);
            drawElement(ball, ballColor);       
 
        }
  
    }
}
