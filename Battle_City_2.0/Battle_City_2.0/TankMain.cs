using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Battle_City_2._0
{

    class TankMain
    {

        //private Cell[,] mainNetwork;

        private int speed = 50;

        private char directionOfTravel;

        public Image ImgTank { get; set; }

        public int CountX { get; set; }
        public int CountY { get; set; }

        public bool IsLeft { get; set; }
        public bool IsRight { get; set; }
        public bool IsDown { get; set; }
        public bool IsUp { get; set; }

        private bool life;

        //конструктор класса
        public TankMain()
        {
            life = true;
            ImgTank = Properties.Resources.main_tank1_1;
            directionOfTravel = 'U';
            CountX = 17;
            CountY = 6;
            Form1.Network[CountX, CountY].IdOwner = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Form1.Network[CountX+i, CountY+j].IdOwner = 1;
                }
            }
        }

        //реализация движения
        public async void ToDrive()
        {
            while (life)
            { 
                if (IsDown)//движение вниз
                {
                    lock (Form1.Network)
                    {
                        if (directionOfTravel != 'D')
                        {
                            directionOfTravel = 'D';
                            ImgTank = Properties.Resources.main_tank1_1;
                            ImgTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        }
                        else if (CountY < 72 && Form1.Network[CountX, CountY + 6].IdOwner == 0 && Form1.Network[CountX + 1, CountY + 6].IdOwner == 0
                                    && Form1.Network[CountX + 2, CountY + 6].IdOwner == 0 && Form1.Network[CountX + 3, CountY + 6].IdOwner == 0
                                    && Form1.Network[CountX + 4, CountY + 6].IdOwner == 0 && Form1.Network[CountX + 5, CountY + 6].IdOwner == 0)
                        {
                            ++CountY;
                            for (int i = 0; i < 6; i++)
                            {

                                Form1.Network[CountX + i, CountY + 5].IdOwner = 1;
                                Form1.Network[CountX + i, CountY - 1].IdOwner = 0;

                            }
                        }
                    }
                }

                if (IsUp)//движение вверх
                {
                    lock (Form1.Network)
                    {
                        if (directionOfTravel != 'U')
                        {
                            directionOfTravel = 'U';
                            ImgTank = Properties.Resources.main_tank1_1;
                            ImgTank.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        }
                        else if (CountY > 0 && Form1.Network[CountX, CountY - 1].IdOwner == 0 && Form1.Network[CountX + 1, CountY - 1].IdOwner == 0
                                    && Form1.Network[CountX + 2, CountY - 1].IdOwner == 0 && Form1.Network[CountX + 3, CountY - 1].IdOwner == 0
                                    && Form1.Network[CountX + 4, CountY - 1].IdOwner == 0 && Form1.Network[CountX + 5, CountY - 1].IdOwner == 0)
                        {
                            --CountY;
                            for (int i = 0; i < 6; i++)
                            {
                                Form1.Network[CountX + i, CountY].IdOwner = 1;
                                Form1.Network[CountX + i, CountY + 6].IdOwner = 0;
                            }
                        }
                    }               
                }

                if (IsLeft)//движение влево
                {
                    lock (Form1.Network)
                    {
                        if (directionOfTravel != 'L')
                        {
                            directionOfTravel = 'L';
                            ImgTank = Properties.Resources.main_tank1_1;
                            ImgTank.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                        else if (CountX > 0 && Form1.Network[CountX - 1, CountY].IdOwner == 0 && Form1.Network[CountX - 1, CountY + 1].IdOwner == 0
                                    && Form1.Network[CountX - 1, CountY + 2].IdOwner == 0 && Form1.Network[CountX - 1, CountY + 3].IdOwner == 0
                                    && Form1.Network[CountX - 1, CountY + 4].IdOwner == 0 && Form1.Network[CountX - 1, CountY + 5].IdOwner == 0)
                        {
                            --CountX;
                            for (int i = 0; i < 6; i++)
                            {
                                Form1.Network[CountX, i + CountY].IdOwner = 1;
                                Form1.Network[6 + CountX, i + CountY].IdOwner = 0;
                            }
                        }
                    }              
                }

                if (IsRight)//движение вправо
                {
                    lock (Form1.Network)
                    {
                        if (directionOfTravel != 'R')
                        {
                            directionOfTravel = 'R';
                            ImgTank = Properties.Resources.main_tank1_1;
                            ImgTank.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        }
                        else if (CountX < 72 && Form1.Network[CountX + 6, CountY].IdOwner == 0 && Form1.Network[CountX + 6, CountY + 1].IdOwner == 0
                                   && Form1.Network[CountX + 6, CountY + 2].IdOwner == 0 && Form1.Network[CountX + 6, CountY + 3].IdOwner == 0
                                   && Form1.Network[CountX + 6, CountY + 4].IdOwner == 0 && Form1.Network[CountX + 6, CountY + 5].IdOwner == 0)
                        {
                            ++CountX;
                            for (int i = 0; i < 6; i++)
                            {
                                Form1.Network[CountX + 5, CountY + i].IdOwner = 1;
                                Form1.Network[CountX - 1, CountY + i].IdOwner = 0;
                            }
                        }
                    }
                }

                //InvalidateEventHandler?.Invoke();
                await Task.Delay(speed);
            }
            
        }

    }
}
