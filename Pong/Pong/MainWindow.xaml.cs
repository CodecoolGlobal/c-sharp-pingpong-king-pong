using System;
using System.Collections.Generic;
using System.Linq;
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

        Paddle paddle = new Paddle { Height = 30, Width = 200, Pos = new Position { X = 500, Y = 300 } };

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = paddle;
            double leftAlign = (GameArea.Width - paddle.Width) / 2;
            double topAlign = GameArea.Height - paddle.Height;


            Rectangle paddleUI = new Rectangle { Height = paddle.Height, Width = paddle.Width, Fill = Brushes.Black };
            GameArea.Children.Add(paddleUI);
            Canvas.SetLeft(paddleUI, leftAlign);
            Canvas.SetTop(paddleUI, topAlign);



     
            
        }

        

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case Key.Left:
            //        break;
            //}
        }
    }
}
