namespace Battle_City_2._0
{
    using System.Drawing;

    class OpenCell
    {
        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }

        public char Direction { get; set; }

        public int CountX { get; set; }
        public int CountY { get; set; }

        public OpenCell LinqLast { get; set; }

        public OpenCell LinqNext { get; set; }

        public OpenCell( int x0, int y0, Point pt1, char dir, int g, OpenCell sender)
        {
            G = g + 10;
            CountX = x0;
            CountY = y0;
            if ((pt1.X - x0) < 0)
            {
                H = x0 - pt1.X;
            }
            else
                H = pt1.X - x0;

            if ((pt1.Y - y0) < 0)
            {
                H += y0 - pt1.Y;
            }
            else
                H = H+pt1.Y - y0;
            H *=10;
            F = H + G;
            Direction = dir;
            LinqLast = sender;
        }

        //пересчитывает F и G
        public void Recalculate(int g, char dir, OpenCell sender)
        {
            G = g + 10;
            F = H + G;
            Direction = dir;
            LinqLast = sender;
        }

        public void NewLinqNext(OpenCell linq)
        {
            LinqNext = linq;
        }
    } 
    
}
