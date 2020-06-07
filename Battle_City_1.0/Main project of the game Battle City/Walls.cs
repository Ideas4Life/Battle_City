using System.Drawing;

namespace Main_project_of_the_game_Battle_City
{
    using System.Windows.Forms;

    public class Walls
    {
        public Image Img;
        public Point PtPoint;
        public Size SzSize;
        public bool Live;

        private Size OldSize;

        public Walls(Image image, int size,int numX, int numY )
        {
            SzSize.Width = SzSize.Height = size;
            Live = true;
            Img = image;
            PtPoint.X = numX * size;
            PtPoint.Y = numY * size;
            OldSize.Height = OldSize.Width = size;
        }

        public void Change(int size)
        {
            if (size!=0)
            {
                SzSize.Width = SzSize.Height = size;
                PtPoint.X = size * PtPoint.X / OldSize.Width;
                PtPoint.Y = size * PtPoint.Y / OldSize.Height;
                OldSize.Height = OldSize.Width = size;
            }
        }
    }
}
