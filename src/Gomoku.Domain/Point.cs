using System.Drawing;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Xml.Linq;

namespace Gomoku.Domain
{
    public class Point
    {
        public int X { get; set; } // Horizontal point
        public int Y { get; set; } // Vertical point
        internal int Sum => X + Y;
        internal int Difference => X - Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return point1.X != point2.X || point1.Y != point2.Y;
        }
    }
}
