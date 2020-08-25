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

        //Paddle paddle = new Paddle { Height = 30, Width = 200, Pos = new Position { X = 500, Y = 300 } };
        private System.Windows.Threading.DispatcherTimer gameTickTimer = new System.Windows.Threading.DispatcherTimer();
        private Paddle paddle = new Paddle{Position = new Point(380,300), Height=30, Width = 200};
        private SolidColorBrush paddleColor = Brushes.Gold;
        enum PaddleDirection {Left, Right};
        private PaddleDirection  direction= PaddleDirection.Left;


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext= paddle;
            drawPaddle(paddle);
            GameArea.Focus();
            GameArea.KeyDown += Canvas_KeyDown;
            
            
        }




       private void drawPaddle(Paddle paddle){
            paddle.UiElement = new Rectangle()
            {
                Width = paddle.Width,
                Height = paddle.Height,
                Fill = paddleColor
            };
            Canvas.SetTop(paddle.UiElement, paddle.Position.X);
            Canvas.SetLeft(paddle.UiElement, paddle.Position.Y);
            GameArea.Children.Add(paddle.UiElement);


       }

        public void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 40;
            double y = paddle.Position.Y; 
            double x = paddle.Position.X;
            switch(e.Key)
            {
                case Key.Left:
                    y -= distance;
                    break;
                case Key.Right:
                    y += distance;
                    break;
            }
            GameArea.Children.Remove(paddle.UiElement);
            paddle.Position = new Point(x, y);

            drawPaddle(paddle);
        }

       

       


        
    }
}
