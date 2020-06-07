namespace Main_project_of_the_game_Battle_City
{
    using System;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Properties;

    //класс танка-бота

    public class Tank_Bot : Tanks
    {
        private const int pause = 17;


        public Tank_Bot(MainWindow form, int size, Random rnd) : base(form)
        {
            direction = mas[new Random().Next(0, mas.Count)];
            Dimension.Width = Dimension.Height = (int) (size * 0.85);
            Speed = 2;
            int X, Y;
            Rectangle Rect;
            do
            {
                X = rnd.Next(0, size * 13);
                Y = rnd.Next(0, size * 13 / 2);
                Rect = new Rectangle(X, Y, Dimension.Width, Dimension.Height);
            } while (Near_Border(Rect) || Near_Wall(Rect) || Down_Tank(Rect) || Left_Tank(Rect) ||
                Right_Tank(Rect) || Up_Tank(Rect));

            Position.X = X;
            Position.Y = Y;
            OldSize.Width = OldSize.Height = size;
            ImgTank = Resources.bot_tank;
        }

        public void Change(int size)
        {
            if (size != 0)
            {
                Position.X = size * Position.X / OldSize.Width;
                Position.Y = size * Position.Y / OldSize.Height;
                OldSize.Height = OldSize.Width = size;
                Dimension.Width = Dimension.Height = (int) ((float) size * 0.85);
            }
        }


        //алгоритм произвольного движения танка-бота

        private void Check_Down()
        {
            var Rect = new Rectangle(Position.X, Position.Y + Speed, Dimension.Width, Dimension.Height);
            if (Near_Border(Rect) || Near_Wall(Rect) || Down_Tank(Rect) )
            {
                direction = mas[new Random().Next(0, mas.Count)];
            }
            else
            {
                movementTank_Down();
            }
        }

        private void Check_Left()
        {
            var Rect = new Rectangle(Position.X - Speed, Position.Y, Dimension.Width, Dimension.Height);
            if (Near_Border(Rect) || Near_Wall(Rect) || Left_Tank(Rect))
            {
                direction = mas[new Random().Next(0, mas.Count)];
            }
            else
            {
                movementTank_Left();
            }
        }

        private void Check_Right()
        {
            var Rect = new Rectangle(Position.X + Speed, Position.Y, Dimension.Width, Dimension.Height);
            if (Near_Border(Rect) || Near_Wall(Rect) || Right_Tank(Rect) )
            {
                direction = mas[new Random().Next(0, mas.Count)];
            }
            else
            {
                movementTank_Right();
            }
        }

        private void Check_Up()
        {
            var Rect = new Rectangle(Position.X, Position.Y - Speed, Dimension.Width, Dimension.Height);
            if (Near_Border(Rect) || Near_Wall(Rect) || Up_Tank(Rect))
            {
                direction = mas[new Random().Next(0, mas.Count)];
            }
            else
            {
                movementTank_Up();
            }
        }

        //функция выстрела

        public void Fire()
        {
            bullet = new Bullet(Position, Dimension, direction, Form,'b');
            bullet.InvalidateEventHandler += Form.Invalidate;
            Task.Factory.StartNew(() => bullet.Flight_bullet());
        }

        //реализация движения танка-бота

        public async void TBot_Movement()
        {
            int k = 0;
            while (Live)
            {
                if (!MainWindow.stop)
                {
                    switch (direction)
                    {
                        case 'L':
                        {
                            if (new Random().Next(0, 5) == 1) k++;
                            if ((bullet == null || !bullet.life) && k > 10)
                            {
                                k = 0;
                                Fire();
                            }

                            Check_Left();
                        }
                            break;
                        case 'R':
                        {
                            if (new Random().Next(0, 5) == 1) k++;
                            if ((bullet == null || !bullet.life) && k > 10)
                            {
                                k = 0;
                                Fire();
                            }

                            Check_Right();
                        }
                            break;
                        case 'U':
                        {
                            if (new Random().Next(0, 5) == 1) k++;
                            if ((bullet == null || !bullet.life) && k > 10)
                            {
                                k = 0;
                                Fire();
                            }

                            Check_Up();
                        }
                            break;
                        case 'D':
                        {
                            if (new Random().Next(0, 5) == 1) k++;
                            if ((bullet == null || !bullet.life) && k > 10)
                            {
                                k = 0;
                                Fire();
                            }

                            Check_Down();
                        }
                            break;
                    }
                }
                    await Task.Delay(pause);
                
            }

            
            direction = 'f';
            ImgTank = Resources.bang;
            Speed = 0;
            await Task.Delay(500);
            MainWindow.AllTankBots.Remove(this);
        }

        //выбор направления изображения танка-бота

        public void ChoiceOfTank()
        {
            switch (direction)
            {
                case 'U':
                {
                    ImgTank = Resources.bot_tank;
                    ImgTank.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }
                    break;
                case 'R':
                {
                    ImgTank = Resources.bot_tank;
                    ImgTank.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                    break;
                case 'L':
                {
                    ImgTank = Resources.bot_tank;
                    ImgTank.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                    break;
                case 'D':
                {
                    ImgTank = Resources.bot_tank;
                    ImgTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                    break;
                default:
                    break;
            }
        }
    }
}
