using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace final
{
    public class Clock
    {
        public List<ClockHand> Hands = new List<ClockHand>();
        public List<Line> Lines = new List<Line>();
        ClockFrame MyFrame;
        public ClockSections FrameShape = new ClockSections();

        public Clock()
        {
            TimeSpan t = TimeSpan.FromHours(2);

            MyFrame = new ClockFrame(150);
            Hands.Add(new ClockHand(1, 50, "second", Colors.Red));
            Hands.Add(new ClockHand(2, 45, "minute", Colors.Blue));
            Hands.Add(new ClockHand(3, 40, "hour", Colors.Black));
        }

        public void DrawClock()
        {
            //P1.MainWindow.AppWindow.Clock.Children.Clear();
            foreach (var Hand in Hands)
            {
                Hand.DrawHand(ClockFrame.CenterX, ClockFrame.CenterY, ClockFrame.CenterX, ClockFrame.CenterY, Hand.Color, Hand.Thickness);
            }
        }

        public void UpdateClock()
        {
            foreach (var hand in Hands)
                hand.HandUpdate();
        }
    }
}
