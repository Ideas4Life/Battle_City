namespace Main_project_of_the_game_Battle_City
{
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Properties;

    //класс управляемого игроком танка

    public class TankForGame : Tanks
    {
        private const int pause = 17;
        public bool IsDown;
        public bool isUp;
        public bool isLeft;
        public bool isRight;
        public bool isfire;
        public bool id;

        public TankForGame(MainWindow form, int size, int k) : base(form)
        {
            Speed = 3;
            if (k == 1)
            {
                id = true;
                Position.X = 4 * size;
                Position.Y = 12 * size;
                ImgTank = Resources.main_tank1_1;
            }
            else
            {
                id = false;
                Position.X = 8 * size;
                Position.Y = 12 * size;
                ImgTank = Resources.main_tank2_1;
            }

            direction = 'U';
            Dimension.Width = Dimension.Height = (int) ((float) size * 0.85);
            OldSize.Width = OldSize.Height = size;
        }

        //изменение позиции и размеров при изменении размера формы
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

        //функция выстрела
        public void Fire()
        {
            bullet = new Bullet(Position, Dimension, direction, Form, 'm');
            bullet.InvalidateEventHandler += Form.Invalidate;
            Task.Factory.StartNew(() => bullet.Flight_bullet());
        }

        public void Check_Down()
        {
            var Rect = new Rectangle(Position.X, Position.Y + Speed, Dimension.Width, Dimension.Height);
            if (Near_Border(Rect) || Near_Wall(Rect) || Down_Tank(Rect))
            {
            }
            else
            {
                direction = 'D';
                movementTank_Down();
            }
        }

        public void Check_Left()
        {
            var Rect = new Rectangle(Position.X - Speed, Position.Y, Dimension.Width, Dimension.Height);
            if (Near_Border(Rect) || Near_Wall(Rect) || Left_Tank(Rect))
            {
            }
            else
            {
                direction = 'L';
                movementTank_Left();
            }
        }

        public void Check_Right()
        {
            var Rect = new Rectangle(Position.X + Speed, Position.Y, Dimension.Width, Dimension.Height);
            if (Near_Border(Rect) || Near_Wall(Rect) || Right_Tank(Rect))
            {
            }
            else
            {
                direction = 'R';
                movementTank_Right();
            }
        }

        public void Check_Up()
        {
            var Rect = new Rectangle(Position.X, Position.Y - Speed, Dimension.Width, Dimension.Height);
            if (Near_Border(Rect) || Near_Wall(Rect) || Up_Tank(Rect))
            {
            }
            else
            {
                direction = 'U';
                movementTank_Up();
            }
        }

        public async void TMain_Movement()
        {
            while (Live)
            {
                if (!MainWindow.stop)
                {
                    if (IsDown)
                    {
                        if (direction != 'D')
                        {
                            direction = 'D';
                            ChoiceOfTank();
                            //Invalidate();
                        }
                        else
                        {
                            ChoiceOfTank();
                            Check_Down();
                        }
                    }

                    if (isLeft)
                    {
                        if (direction != 'L')
                        {
                            direction = 'L';
                            ChoiceOfTank();
                            //Invalidate();
                        }
                        else
                        {
                            ChoiceOfTank();
                            Check_Left();
                        }
                    }

                    if (isRight)
                    {
                        if (direction != 'R')
                        {
                            direction = 'R';
                            ChoiceOfTank();
                            //Invalidate();
                        }
                        else
                        {
                            ChoiceOfTank();
                            Check_Right();
                        }
                    }

                    if (isUp)
                    {
                        if (direction != 'U')
                        {
                            direction = 'U';
                            ChoiceOfTank();
                            //Invalidate();
                        }
                        else
                        {
                            ChoiceOfTank();
                            Check_Up();
                        }
                    }

                    if (isfire)
                    {
                        if (bullet == null || !bullet.life)
                        {
                            Fire();
                        }
                    }
                }

                await Task.Delay(pause);
            }
            direction = 'f';
            ImgTank = Resources.bang;
            Speed = 0;
            await Task.Delay(500);
            MainWindow.AllTankMain.Remove(this);
        }

        //выбор направления изображения танка

        public void ChoiceOfTank()
        {
            switch (direction)
            {
                case 'U':
                {
                    if (id)
                    {
                        if (kindOfTank % 2 == 0)
                        {
                            ImgTank = Resources.main_tank1_1;
                            kindOfTank++;
                        }
                        else
                        {
                            ImgTank = Resources.main_tank1_2;
                            kindOfTank++;
                        }
                    }
                    else
                    {
                        if (kindOfTank % 2 == 0)
                        {
                            ImgTank = Resources.main_tank2_1;
                            kindOfTank++;
                        }
                        else
                        {
                            ImgTank = Resources.main_tank2_2;
                            kindOfTank++;
                        }
                    }

                        ImgTank.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }
                    break;
                case 'R':
                {
                    if (id)
                    {
                        if (kindOfTank % 2 == 0)
                        {
                            ImgTank = Resources.main_tank1_1;
                            kindOfTank++;
                        }
                        else
                        {
                            ImgTank = Resources.main_tank1_2;
                            kindOfTank++;
                        }
                    }
                    else
                    {
                        if (kindOfTank % 2 == 0)
                        {
                            ImgTank = Resources.main_tank2_1;
                            kindOfTank++;
                        }
                        else
                        {
                            ImgTank = Resources.main_tank2_2;
                            kindOfTank++;
                        }
                    }

                        ImgTank.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                    break;
                case 'L':
                {
                    if (id)
                    {
                        if (kindOfTank % 2 == 0)
                        {
                            ImgTank = Resources.main_tank1_1;
                            kindOfTank++;
                        }
                        else
                        {
                            ImgTank = Resources.main_tank1_2;
                            kindOfTank++;
                        }
                    }
                    else
                    {
                        if (kindOfTank % 2 == 0)
                        {
                            ImgTank = Resources.main_tank2_1;
                            kindOfTank++;
                        }
                        else
                        {
                            ImgTank = Resources.main_tank2_2;
                            kindOfTank++;
                        }
                    }

                        ImgTank.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                    break;
                case 'D':
                {
                    if (id)
                    {
                        if (kindOfTank % 2 == 0)
                        {
                            ImgTank = Resources.main_tank1_1;
                            kindOfTank++;
                        }
                        else
                        {
                            ImgTank = Resources.main_tank1_2;
                            kindOfTank++;
                        }
                    }
                    else
                    {
                        if (kindOfTank % 2 == 0)
                        {
                            ImgTank = Resources.main_tank2_1;
                            kindOfTank++;
                        }
                        else
                        {
                            ImgTank = Resources.main_tank2_2;
                            kindOfTank++;
                        }
                    }

                        ImgTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                    break;
            }
        }
    }
}
