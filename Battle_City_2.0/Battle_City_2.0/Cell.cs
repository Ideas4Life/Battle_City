using System.Drawing;

namespace Battle_City_2._0
{

    public class Cell
    {
        public int IdOwner {get;set;}

        private Size size;
        public Point Point;

        private int numberX;
        public int NumberX
        {
            get { return numberX - 1; }
            set { numberX = value + 1; }
        }

        private int numberY;
        public int NumberY
        {
            get { return numberY - 1; }
            set { numberY = value + 1; }
        }

        public Cell(int widthWindiw, int numX, int numY)
        {
            size.Height = size.Width = widthWindiw;
            numberX = numX;
            numberY = numY;
            Point.X = size.Width * (numberX-1);
            Point.Y = size.Height * (numberY-1);
        }
    }
}
