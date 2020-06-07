using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Battle_City_2._0
{
    internal class TankBot
    {
        private readonly int size;

        private List<OpenCell> closedList;

        private Point pt;

        private char directionOfTravel;

        public Image ImgTank { get; set; }
        //private int countX, countY;

        public int CountX
        {
            get;
            set;
        }
        public int CountY
        {
            get;
            set;
        }

        private bool life;

        public TankBot(int sz, Point p)
        {
            pt = p;
            closedList = new List<OpenCell>();

            ImgTank = Properties.Resources.bot_tank1_1;
            directionOfTravel = 'U';
            CountX = 35;
            CountY = 35;
            life = true;
            size = sz;
            lock (Form1.Network)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        lock (Form1.Network)
                        {
                            Form1.Network[CountX + i, CountY + j].IdOwner = 2;
                        }
                    }
                }
            }
        }

        //реализация движения
        public async void ToDrive()
        {
            while (life)
            {
                pt = FindTank(); //нахождение ближайшего танка

                if (pt.X != -1 || pt.Y != -1)
                {
                    FindWayToTank(pt); //построение кратчайшего пути по алгоритму А*

                    for (OpenCell ocCell = closedList[0].LinqNext; ocCell.CountX != pt.X || ocCell.CountY != pt.Y;)
                    {
                        MovementByWay(ocCell); //движение по построенному пути
                        ocCell = ocCell.LinqNext;
                        await Task.Delay(100);
                    }
                    closedList.Clear();
                }
                else
                {
                    MovementWithoutTarget();
                    await Task.Delay(1000);
                }
            }
        }

        //движение танка без цели
        private async void MovementWithoutTarget()
        {
            
        }

        //движение танка по найденному пути
        private void MovementByWay(OpenCell ocCell)
        {
            //прохождение танка по построенному кратчайшему пути
            if (ocCell.Direction == 'D')//дивжение вверх
            {
                lock (Form1.Network)
                {
                    if (directionOfTravel != 'U')
                    {
                        directionOfTravel = 'U';
                        ImgTank = Properties.Resources.bot_tank1_1;
                        ImgTank.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    }
                    else if (CountY > 0 && Form1.Network[CountX, CountY - 1].IdOwner == 0 && Form1.Network[CountX + 1, CountY - 1].IdOwner == 0
                            && Form1.Network[CountX + 2, CountY - 1].IdOwner == 0 && Form1.Network[CountX + 3, CountY - 1].IdOwner == 0
                            && Form1.Network[CountX + 4, CountY - 1].IdOwner == 0 && Form1.Network[CountX + 5, CountY - 1].IdOwner == 0)
                    {
                        --CountY;
                        for (int i = 0; i < 6; i++)
                        {
                            Form1.Network[CountX + i, CountY].IdOwner = 2;
                            Form1.Network[CountX + i, CountY + 6].IdOwner = 0;
                        }
                    }
                }
            }

            if (ocCell.Direction == 'U')//движение вниз
            {
                lock (Form1.Network)
                {
                    if (directionOfTravel != 'D')
                    {
                        directionOfTravel = 'D';
                        ImgTank = Properties.Resources.bot_tank1_1;
                        ImgTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    }
                    else if (CountY < 72 && Form1.Network[CountX, CountY + 7].IdOwner == 0 && Form1.Network[CountX + 1, CountY + 6].IdOwner == 0
                            && Form1.Network[CountX + 2, CountY + 6].IdOwner == 0 && Form1.Network[CountX + 3, CountY + 6].IdOwner == 0
                            && Form1.Network[CountX + 4, CountY + 6].IdOwner == 0 && Form1.Network[CountX + 5, CountY + 6].IdOwner == 0)
                    {
                        ++CountY;
                        for (int i = 0; i < 6; i++)
                        {

                            Form1.Network[CountX + i, CountY + 5].IdOwner = 2;
                            Form1.Network[CountX + i, CountY - 1].IdOwner = 0;

                        }
                    }
                }
            }

            if (ocCell.Direction == 'L')//движение вправо
            {
                lock (Form1.Network)
                {
                    if (directionOfTravel != 'R')
                    {
                        directionOfTravel = 'R';
                        ImgTank = Properties.Resources.bot_tank1_1;
                        ImgTank.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    else if (CountX < 72 && Form1.Network[CountX + 6, CountY].IdOwner == 0 && Form1.Network[CountX + 6, CountY + 1].IdOwner == 0
                             && Form1.Network[CountX + 6, CountY + 2].IdOwner == 0 && Form1.Network[CountX + 6, CountY + 3].IdOwner == 0
                             && Form1.Network[CountX + 6, CountY + 4].IdOwner == 0 && Form1.Network[CountX + 6, CountY + 5].IdOwner == 0)
                    {
                        ++CountX;
                        for (int i = 0; i < 6; i++)
                        {

                            Form1.Network[CountX + 5, CountY + i].IdOwner = 2;
                            Form1.Network[CountX - 1, CountY + i].IdOwner = 0;


                        }
                    }
                }
            }

            if (ocCell.Direction == 'R')//движение влево
            {
                lock (Form1.Network)
                {
                    if (directionOfTravel != 'L')
                    {
                        directionOfTravel = 'L';
                        ImgTank = Properties.Resources.bot_tank1_1;
                        ImgTank.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    else if (CountX > 0 && Form1.Network[CountX - 1, CountY].IdOwner == 0 && Form1.Network[CountX - 1, CountY + 1].IdOwner == 0
                                && Form1.Network[CountX - 1, CountY + 2].IdOwner == 0 && Form1.Network[CountX - 1, CountY + 3].IdOwner == 0
                                && Form1.Network[CountX - 1, CountY + 4].IdOwner == 0 && Form1.Network[CountX - 1, CountY + 5].IdOwner == 0)
                    {
                        --CountX;
                        for (int i = 0; i < 6; i++)
                        {

                            Form1.Network[CountX, i + CountY].IdOwner = 2;
                            Form1.Network[6 + CountX, i + CountY].IdOwner = 0;

                        }
                    }
                }
            }
        }

        //нахождение ближайшего врага в окрестности видимости (5*9)
        private Point FindTank()
        {
            int k = 12;
            int c = 30;
            int t = 48;
            switch (directionOfTravel)
            {

                case 'D':
                    {
                        if (k > CountX)
                        {
                            c = c - k + CountX;
                            k = CountX;
                        }
                        if (CountX - k + c >= 78)
                        {
                            c = 78 - CountX + k; ;
                        }
                        if (CountY + t > 78)
                        {
                            t = 78 - CountY;
                        }
                        for (int i = 0; i < t; i++)
                        {
                            lock (Form1.Network)
                            {
                                for (int j = 0; j < c; j++)
                                {
                                    if (Form1.Network[CountX - k + j - 1, CountY + i - 1].IdOwner == 1)
                                    {
                                        return new Point(CountX - k + j, CountY + i);
                                    }
                                }
                            }
                        }
                        return new Point(-1, -1);
                    }
                case 'U':
                    {
                        if (k > CountX)
                        {
                            c = c - k + CountX;
                            k = CountX - 1;
                        }
                        if (CountX - k + c >= 78)
                        {
                            c = 78 - CountX + k;
                        }
                        if (CountY + 6 - t < 0)
                        {
                            t = CountY + 6;
                        }
                        for (int i = 0; i < t; i++)
                        {
                            lock (Form1.Network)
                            {
                                for (int j = 0; j < c; j++)
                                {
                                    if (Form1.Network[CountX - k + j - 1, CountY + 5 - i].IdOwner == 1)
                                    {
                                        return new Point(CountX - k + j, CountY + 5);
                                    }
                                }
                            }
                        }
                        return new Point(-1, -1);
                    }
                case 'L':
                    {
                        if (k < CountY)
                        {
                            c = c - k + CountY;
                            k = CountY - 1;
                        }
                        if (CountX + 6 - t < 0)
                        {
                            t = CountX - 1;
                        }
                        if (CountY - k + c >= 78)
                        {
                            c--;
                        }
                        for (int i = 0; i < t; i++)
                        {
                            lock (Form1.Network)
                            {
                                for (int j = 0; j < c; j++)
                                {
                                    if (Form1.Network[CountX + 5 + i, CountY - k + j - 1].IdOwner == 1)
                                    {
                                        return new Point(CountX + 6 + i, CountY - k + j);
                                    }
                                }
                            }
                        }
                        return new Point(-1, -1);
                    }
                case 'R':
                    {
                        if (k < CountY)
                        {
                            c = c - k + CountY;
                            k = CountY;
                        }
                        if (CountY - k + c > 78)
                        {
                            c = 78 - CountY + k;
                        }
                        if (CountX + t >= 78)
                        {
                            t = CountX - 1;
                        }
                        for (int i = 0; i < t; i++)
                        {
                            lock (Form1.Network)
                            {
                                for (int j = 0; j < c; j++)
                                {
                                    if (Form1.Network[CountX + i - 1, CountY - k + j - 1].IdOwner == 1)
                                    {
                                        return new Point(CountX + i, CountY - k + j);
                                    }
                                }
                            }
                        }
                        return new Point(-1, -1);
                    }
                default:
                    {
                        return new Point(-1, -1);
                    }
            }

        }

        //нахождение кратчайшего пути (алгоритм А*)
        private void FindWayToTank(Point pt)
        {
            closedList.Clear();

            List<OpenCell> openList = new List<OpenCell>();

            OpenCell ocCell = new OpenCell(CountX, CountY, pt, '!', -10, null);

            closedList.Add(ocCell);

            int q;
            int i;
            while (ocCell.CountX != pt.X || ocCell.CountY != pt.Y)
            {
                //проверяем клетку справа
                if (ocCell.CountX + 1 < 53 && ocCell.CountY < 53 && ocCell.CountX + 1 > 0 && ocCell.CountY > 0 && ocCell.Direction != 'R' &&
                    Form1.Network[1 + ocCell.CountX, ocCell.CountY].IdOwner == 0)
                {
                    q = 0;
                    for (i = 0; i < openList.Count; i++)
                    {
                        if (openList[i].CountX == 1 + ocCell.CountX && openList[i].CountY == ocCell.CountY)
                        {
                            if (openList[i].G > ocCell.G + 10)
                            {
                                openList[i].Recalculate(ocCell.G, 'L', ocCell);
                            }

                            ++q;
                        }
                    }

                    if (q == 0)
                    {
                        openList.Add(new OpenCell(ocCell.CountX + 1, ocCell.CountY, pt, 'L', ocCell.G, ocCell));
                    }
                }
                else if (ocCell.CountX + 1 == pt.X && ocCell.CountY == pt.Y)
                {
                    ocCell = new OpenCell(ocCell.CountX + 1, ocCell.CountY, pt, 'L', ocCell.G, ocCell);
                    closedList.Add(ocCell);
                    break;
                }

                //проверяем клетку снизу
                if (ocCell.CountX < 53 && ocCell.CountY + 1 < 53 && ocCell.CountX > 0 && ocCell.CountY + 1 > 0 && ocCell.Direction != 'D' &&
                   Form1.Network[ocCell.CountX, 1 + ocCell.CountY].IdOwner == 0)
                {

                    q = 0;
                    for (i = 0; i < openList.Count; i++)
                    {
                        if (openList[i].CountX == ocCell.CountX && openList[i].CountY == 1 + ocCell.CountY)
                        {
                            if (openList[i].G > ocCell.G + 10)
                            {
                                openList[i].Recalculate(ocCell.G, 'U', ocCell);
                            }

                            ++q;
                        }
                    }

                    if (q == 0)
                    {
                        openList.Add(new OpenCell(ocCell.CountX, ocCell.CountY + 1, pt, 'U', ocCell.G, ocCell));
                    }
                }
                else if (ocCell.CountX == pt.X && ocCell.CountY + 1 == pt.Y)
                {
                    ocCell = new OpenCell(ocCell.CountX, ocCell.CountY + 1, pt, 'U', ocCell.G, ocCell);
                    closedList.Add(ocCell);
                    break;
                }


                //проверяем клетку слева
                if (ocCell.CountX - 1 < 53 && ocCell.CountY < 53 && ocCell.CountX - 1 > 0 && ocCell.CountY > 0 && ocCell.Direction != 'L' &&
                    Form1.Network[ocCell.CountX - 1, ocCell.CountY].IdOwner == 0)
                {

                    q = 0;
                    for (i = 0; i < openList.Count; i++)
                    {
                        if (openList[i].CountX == ocCell.CountX - 1 && openList[i].CountY == ocCell.CountY)
                        {
                            if (openList[i].G > ocCell.G + 10)
                            {
                                openList[i].Recalculate(ocCell.G, 'R', ocCell);
                            }


                            q++;
                        }
                    }

                    if (q == 0)
                    {
                        openList.Add(new OpenCell(ocCell.CountX - 1, ocCell.CountY, pt, 'R', ocCell.G, ocCell));
                    }
                }
                else if (ocCell.CountX - 1 == pt.X && ocCell.CountY == pt.Y)
                {
                    ocCell = new OpenCell(ocCell.CountX - 1, ocCell.CountY, pt, 'R', ocCell.G, ocCell);
                    closedList.Add(ocCell);
                    break;
                }

                //проверяем клетку сверху
                if (ocCell.CountX < 53 && ocCell.CountY - 1 < 53 && ocCell.CountX > 0 && ocCell.CountY - 1 > 0 && ocCell.Direction != 'U' &&
                    Form1.Network[ocCell.CountX, ocCell.CountY - 1].IdOwner == 0)
                {
                    q = 0;
                    for (i = 0; i < openList.Count; i++)
                    {
                        if (openList[i].CountX == ocCell.CountX && openList[i].CountY == ocCell.CountY - 1)
                        {
                            if (openList[i].G > ocCell.G + 10)
                            {
                                openList[i].Recalculate(ocCell.G, 'D', ocCell);
                            }

                            q++;
                        }
                    }

                    if (q == 0)
                    {
                        openList.Add(new OpenCell(ocCell.CountX, ocCell.CountY - 1, pt, 'D', ocCell.G, ocCell));
                    }
                }
                else if (ocCell.CountX == pt.X && ocCell.CountY - 1 == pt.Y)
                {
                    ocCell = new OpenCell(ocCell.CountX, ocCell.CountY - 1, pt, 'D', ocCell.G, ocCell);
                    closedList.Add(ocCell);
                    break;
                }

                //ищем клетку с наименьшим F в открытом списке
                if (openList.Count != 0)
                {
                    ocCell = openList[0];
                    for (i = 1; i < openList.Count; i++)
                    {
                        if (ocCell.F > openList[i].F)
                        {
                            ocCell = openList[i];
                        }
                    }

                }

                //добавляем текущую клетку в закрытый список
                closedList.Add(ocCell);

                //удаляем текушую клетку из открытого списка
                openList.Remove(ocCell);
            }

            //нормализация последующих ссылок
            while (ocCell.LinqLast != null)
            {
                ocCell.LinqLast.LinqNext = ocCell;
                ocCell = ocCell.LinqLast;
            }
        }
    }
}
