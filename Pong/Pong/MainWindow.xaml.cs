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

        private Element paddle = new Element{Position = new Point(380,300), Height=30, Width = 200};
        private Element ball = new Element{Position = new Point(0,300), Height=20, Width = 20};
        private SolidColorBrush paddleColor = Brushes.Gold;
        private SolidColorBrush ballColor = Brushes.Red;


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext= paddle;
            drawElement(paddle, paddleColor);
            drawElement(ball, ballColor);
            GameArea.Focus();
            GameArea.KeyDown += Canvas_KeyDown;


        }




       private void drawElement(Element element, SolidColorBrush elementColor)
        {
            element.UiElement = new Rectangle()
            {
                Width = element.Width,
                Height = element.Height,
                Fill = elementColor
            };
            Canvas.SetTop(element.UiElement, element.Position.X);
            Canvas.SetLeft(element.UiElement, element.Position.Y);
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
                    y -= distance;
                    break;
                case Key.Right:
                    y += distance;
                    break;
            }
            GameArea.Children.Remove(paddle.UiElement);
            paddle.Position = new Point(x, y);

            drawElement(paddle, paddleColor);
        }

       

       


        
    }
}
