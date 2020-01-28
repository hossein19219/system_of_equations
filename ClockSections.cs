using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace final
{
    public class ClockSections
    {
        public ClockSections()
        {
        }
        public void Demo()
        {
            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                {
                    DrawLine(
                    ClockFrame.CenterX + (150 / 3 * Math.Sin(i * Math.PI / 30)),
                    ClockFrame.CenterY - (150 / 3 * Math.Cos(i * Math.PI / 30)),
                    ClockFrame.CenterX + (150 / 3.3 * Math.Sin(i * Math.PI / 30)),
                    ClockFrame.CenterY - (150 / 3.3 * Math.Cos(i * Math.PI / 30)), Colors.Black, 3);
                }
                else
                {
                    DrawLine(
                    ClockFrame.CenterX + (150 / 3 * Math.Sin(i * Math.PI / 30)),
                    ClockFrame.CenterY - (150 / 3 * Math.Cos(i * Math.PI / 30)),
                    ClockFrame.CenterX + (150 / 3.1 * Math.Sin(i * Math.PI / 30)),
                    ClockFrame.CenterY - (150 / 3.1 * Math.Cos(i * Math.PI / 30)), Colors.Black, 3);
                }
            }
        }
        public void DrawLine(double x1, double y1, double x2, double y2, Color color, double Thickness)
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

            MainWindow.AppWindow.Clock.Children.Add(line);
        }
    }
}
