using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace final
{
    public class ClockHand
    {
        public double Thickness { get; set; }
        public double Length { get; set; }
        private string Type { get; set; }
        public Color Color { get; set; }
        public Line HandLine { get; set; }


        public ClockHand(double thickness, double length, string type, Color color)
        {
            Thickness = thickness;
            Length = length;
            Type = type;
            Color = color;
        }

        public void DrawHand(double x1, double y1, double x2, double y2, Color color, double Thickness)
        {
            Line line = new Line()
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                StrokeThickness = Thickness,
                Stroke = new SolidColorBrush(color)
            };
            HandLine = line;
            MainWindow.AppWindow.Clock.Children.Add(line);
        }

        public void HandUpdate()
        {
            double Radian = 0;

            if (Type == "hour")
            {
                Radian = (double)(((DateTime.Now.Hour % 12 + (double)DateTime.Now.Minute / 60) * Math.PI / 6) - (Math.PI / 2));
            }
            else if (Type == "minute")
            {
                Radian = (double)(((DateTime.Now.Minute + (double)DateTime.Now.Second / 60) * 360 / 60 * Math.PI / 180) - (Math.PI / 2));
            }
            else if (Type == "second")
            {
                Radian = (double)((DateTime.Now.Second * 2 * Math.PI / 60) + (Math.PI / 2));
            }

            HandLine.X1 = ClockFrame.CenterX + Length * Math.Cos(Radian);
            HandLine.Y1 = ClockFrame.CenterY + Length * Math.Sin(Radian);
        }
    }
}
