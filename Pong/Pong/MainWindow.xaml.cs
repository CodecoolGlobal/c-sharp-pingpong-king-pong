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
        Paddle paddle = new Paddle{Position = new Point(500,300), Height=30, Width = 200};
        private SolidColorBrush paddleColor = Brushes.Gold;
        

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = paddle;
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
            


            //this.DataContext = paddle;
            //Rect paddleUI = new Rect
            //{ 
            //    Height = paddle.Height,
            //    Width = paddle.Width,
           //     X = paddle.Pos.X,
           //     Y = paddle.Pos.Y
           //};
            //drawPaddle(paddleUI);
            //movePaddle(paddleUI);
        }

 //       private void drawPaddle(Rect paddleUI){
 //           double leftAlign = (GameArea.Width - paddle.Width) / 2;
//            double topAlign = GameArea.Height - paddle.Height;
 //           GameArea.Children.Add(paddleUI);
 //           Canvas.SetLeft(paddleUI, leftAlign);
 //           Canvas.SetTop(paddleUI, topAlign);
            
 //       }

        private void movePaddle(Rect paddleUI)
        {


        }



        //private void Canvas_KeyDown(object sender, KeyEventArgs e)
        //{
            //switch (e.key)
            //{
            //    //case key.left:
            //    //    //paddleUI.
            //    //    break;
            //    //case key.Right:
            //    //    break;
            //}
        //}
    }
}
