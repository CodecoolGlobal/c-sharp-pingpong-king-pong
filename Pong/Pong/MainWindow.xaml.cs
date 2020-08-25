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
        private Paddle paddle = new Paddle{Position = new Point(500,300), Height=30, Width = 200};
        private SolidColorBrush paddleColor = Brushes.Gold;
        enum PaddleDirection {Left, Right};
        private PaddleDirection  direction= PaddleDirection.Left;


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext= paddle;
            drawPaddle(paddle);
            
          
        }

       private void drawPaddle(Paddle paddle){
            paddle.UiElement = new Rectangle()
            {
                Width = paddle.Width,
                Height = paddle.Height,
                Fill = paddleColor
            };
            double leftAlign = (GameArea.Width - paddle.Width) / 2;
            double topAlign = GameArea.Height - paddle.Height;
            Canvas.SetTop(paddle.UiElement, topAlign);
            Canvas.SetLeft(paddle.UiElement, leftAlign);
            GameArea.Children.Add(paddle.UiElement);

            GameArea.Focus();
            GameArea.KeyDown += Canvas_KeyDown;
            
       }

        public void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Left:
                    Console.WriteLine("!");
                    break;
                case Key.Right:
                    break;
            }
        }

        private void movePaddle(Rect paddleUI)
        {
            
        }



        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    direction = PaddleDirection.Left;
                    break;
                case Key.Right:
                    direction = PaddleDirection.Right;
                    break;
            }
        }
    }
}
