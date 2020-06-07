namespace Main_project_of_the_game_Battle_City
{
    using System.Drawing;
    using System.Threading.Tasks;
    using Properties;

    public class Bullet
    {
        public delegate void Dlgt();

        private int speed = 3;
        private const int pause = 1;
        private readonly char direction;
        public Size Dimension = new Size(8, 8);
        private readonly MainWindow Form;
        private readonly char id;
        public Image ImgBullet;
        public Point Position;

        public Bullet(Point coordinate, Size size, char chr, MainWindow form, char ch)
        {
            id = ch;
            Form = form;
            direction = chr;
            life = false;
            ImgBullet = Resources.bullet;
            switch (chr)
            {
                case 'L':
                {
                    Position.X = coordinate.X - Dimension.Width;
                    Position.Y = coordinate.Y + size.Height / 2 - Dimension.Width / 2;
                    ImgBullet.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                    break;
                case 'R':
                {
                    Position.X = coordinate.X + size.Width;
                    Position.Y = coordinate.Y + size.Height / 2 - Dimension.Width / 2;
                    ImgBullet.RotateFlip(RotateFlipType.Rotate180FlipX);
                }
                    break;
                case 'U':
                {
                    Position.Y = coordinate.Y - Dimension.Height;
                    Position.X = coordinate.X + size.Width / 2 - Dimension.Width / 2;
                    ImgBullet.RotateFlip(RotateFlipType.Rotate90FlipY);
                }
                    break;
                case 'D':
                {
                    Position.X = coordinate.X + size.Width / 2 - Dimension.Width / 2;
                    Position.Y = coordinate.Y + size.Height + Dimension.Height;
                    ImgBullet.RotateFlip(RotateFlipType.Rotate90FlipX);
                }
                    break;
            }
        }

        public bool life { get; set; }

        public event Dlgt InvalidateEventHandler;

        //проверка на попадание пули в другую пулю

        private void damage_Bullet(Rectangle Rect)
        {
            if (id == 'm')
            {
                foreach (var allTank in MainWindow.AllTankBots)
                {
                    foreach (var allTankM in MainWindow.AllTankMain)
                    {
                        if (allTankM != null && allTankM.bullet == this && allTank != null && allTank.bullet != null &&
                            allTank.bullet.life && new Rectangle(allTank.bullet.Position.X, allTank.bullet.Position.Y,
                                allTank.bullet.Dimension.Width, allTank.bullet.Dimension.Height).IntersectsWith(Rect))
                        {
                            life = false;
                            allTank.bullet.life = false;
                            return;
                        }
                    }
                }
            }
            else
            {
                foreach (var allTankM in MainWindow.AllTankMain)
                {
                    if (allTankM != null && allTankM.bullet != null && allTankM.bullet != this &&
                        allTankM.bullet.life && new Rectangle(allTankM.bullet.Position.X, allTankM.bullet.Position.Y,
                            allTankM.bullet.Dimension.Width, allTankM.bullet.Dimension.Height).IntersectsWith(Rect))
                    {
                        life = false;
                        allTankM.bullet.life = false;
                        return;
                    }
                }
            }
        }

        //проверка на попадание пули в базу

        public void damage_Base(Rectangle Rect)
        {
            if (new Rectangle(MainWindow.MapAny.Base.PtPoint, MainWindow.MapAny.Base.SzSize).IntersectsWith(Rect) &&
                MainWindow.MapAny.Base.Live)
            {
                life = false;
                MainWindow.MapAny.Base.Live = false;
            }
        }

        //проверка на попадание пули в стену

        private void damage_Border()
        {
            if (!(Position.X >= 0 && Position.X <= Form.ClientSize.Width - Dimension.Width && Position.Y >= 0 &&
                Position.Y <= Form.ClientSize.Height - Dimension.Width))
            {
                life = false;
            }
        }

        //проверка на попадание в кирпичную стену

        private void damage_WallBrick(Rectangle Rect)
        {
            foreach (var allBrick in MainWindow.MapAny.MasBrick)
            {
                if (new Rectangle(allBrick.PtPoint.X, allBrick.PtPoint.Y, allBrick.SzSize.Width, allBrick.SzSize.Height)
                    .IntersectsWith(Rect) && allBrick.Live)

                {
                    life = false;
                    allBrick.Live = false;
                    return;
                }
            }
        }

        //проверка на попадание в бетонную стену

        private void damage_WallBeton(Rectangle Rect)
        {
            foreach (var allBeton in MainWindow.MapAny.MasBeton)
            {
                if (new Rectangle(allBeton.PtPoint.X, allBeton.PtPoint.Y, allBeton.SzSize.Width, allBeton.SzSize.Height)
                    .IntersectsWith(Rect))

                {
                    life = false;
                    return;
                }
            }
        }

        //проверка на попадание пули главного танка в танк-бот

        private void damage_TankMain(Rectangle Rect)
        {
            foreach (var allTank in MainWindow.AllTankBots)
            {
                if (new Rectangle(allTank.Position.X, allTank.Position.Y, allTank.Dimension.Width,
                    allTank.Dimension.Height).IntersectsWith(Rect)&&allTank.Live)
                {
                    life = false;
                    allTank.Live = false;
                    return;
                }
            }
        }

        //проверка на попадание пули танка-бота в главный танк 

        private void damage_TankBot(Rectangle Rect)
        {
            foreach (var allTankM in MainWindow.AllTankMain)
            {
                if (new Rectangle(allTankM.Position.X, allTankM.Position.Y, allTankM.Dimension.Width,
                    allTankM.Dimension.Height).IntersectsWith(Rect) && allTankM.Live)
                {
                    life = false;
                    allTankM.Live = false;
                    return;
                }
            }
        }

        //полет пули

        public async void Flight_bullet()
        {
            //MainTank = myTank;
            life = true;
            switch (direction)
            {
                case 'L':
                {
                    while (life)
                    {
                        if (!MainWindow.stop)
                        {
                            await Task.Delay(pause);
                            if (id == 'b')
                            {
                                damage_TankBot(new Rectangle(Position.X - speed, Position.Y, Dimension.Width,
                                    Dimension.Height));
                            }
                            else
                            {
                                damage_TankMain(new Rectangle(Position.X - speed, Position.Y, Dimension.Width,
                                    Dimension.Height));
                            }

                            damage_Base(
                                new Rectangle(Position.X - speed, Position.Y, Dimension.Width, Dimension.Height));
                            damage_WallBrick(new Rectangle(Position.X - speed, Position.Y, Dimension.Width,
                                Dimension.Height));
                            damage_WallBeton(new Rectangle(Position.X - speed, Position.Y, Dimension.Width,
                                Dimension.Height));
                            damage_Border();
                            damage_Bullet(new Rectangle(Position.X - speed, Position.Y, Dimension.Width,
                                Dimension.Height));

                            Position.X -= speed;

                            if (InvalidateEventHandler != null)
                            {
                                InvalidateEventHandler();
                            }
                        }
                    }

                    if (InvalidateEventHandler != null)
                    {
                        InvalidateEventHandler();
                    }
                }
                    break;
                case 'R':
                {
                    while (life)
                    {
                        if (!MainWindow.stop)
                        {
                            await Task.Delay(pause);
                            if (id == 'b')
                            {
                                damage_TankBot(new Rectangle(Position.X + speed, Position.Y, Dimension.Width,
                                    Dimension.Height));
                            }
                            else
                            {
                                damage_TankMain(new Rectangle(Position.X + speed, Position.Y, Dimension.Width,
                                    Dimension.Height));
                            }

                            damage_Base(
                                new Rectangle(Position.X + speed, Position.Y, Dimension.Width, Dimension.Height));
                            damage_WallBrick(new Rectangle(Position.X + speed, Position.Y, Dimension.Width,
                                Dimension.Height));
                            damage_WallBeton(new Rectangle(Position.X + speed, Position.Y, Dimension.Width,
                                Dimension.Height));
                            damage_Border();
                            damage_Bullet(new Rectangle(Position.X + speed, Position.Y, Dimension.Width,
                                Dimension.Height));
                            Position.X += speed;
                            if (InvalidateEventHandler != null)
                            {
                                InvalidateEventHandler();
                            }
                        }
                    }

                    if (InvalidateEventHandler != null)
                    {
                        InvalidateEventHandler();
                    }
                }
                    break;
                case 'U':
                {
                    while (life)
                    {
                        if (!MainWindow.stop)
                        {
                            while (MainWindow.stop) speed = 0;
                            speed = 3;
                            await Task.Delay(pause);
                            if (id == 'b')
                            {
                                damage_TankBot(new Rectangle(Position.X, Position.Y - speed, Dimension.Width,
                                    Dimension.Height));
                            }
                            else
                            {
                                damage_TankMain(new Rectangle(Position.X, Position.Y - speed, Dimension.Width,
                                    Dimension.Height));
                            }

                            damage_Base(
                                new Rectangle(Position.X, Position.Y - speed, Dimension.Width, Dimension.Height));

                            damage_WallBrick(new Rectangle(Position.X, Position.Y - speed, Dimension.Width,
                                Dimension.Height));
                            damage_WallBeton(new Rectangle(Position.X, Position.Y - speed, Dimension.Width,
                                Dimension.Height));
                            damage_Border();
                            damage_Bullet(new Rectangle(Position.X, Position.Y - speed, Dimension.Width,
                                Dimension.Height));
                            Position.Y -= speed;
                            if (InvalidateEventHandler != null)
                            {
                                InvalidateEventHandler();
                            }
                        }
                    }

                    if (InvalidateEventHandler != null)
                    {
                        InvalidateEventHandler();
                    }
                }
                    break;
                case 'D':
                {
                    while (life)
                    {
                        if (!MainWindow.stop)
                        {
                            await Task.Delay(pause);
                            if (id == 'b')
                            {
                                damage_TankBot(new Rectangle(Position.X, Position.Y - speed, Dimension.Width,
                                    Dimension.Height));
                            }
                            else
                            {
                                damage_TankMain(new Rectangle(Position.X, Position.Y + speed, Dimension.Width,
                                    Dimension.Height));
                            }

                            damage_Base(
                                new Rectangle(Position.X, Position.Y - speed, Dimension.Width, Dimension.Height));

                            damage_WallBrick(new Rectangle(Position.X, Position.Y + speed, Dimension.Width,
                                Dimension.Height));
                            damage_WallBeton(new Rectangle(Position.X, Position.Y - speed, Dimension.Width,
                                Dimension.Height));
                            damage_Border();
                            damage_Bullet(new Rectangle(Position.X, Position.Y - speed, Dimension.Width,
                                Dimension.Height));

                            Position.Y += speed;
                            if (InvalidateEventHandler != null)
                            {
                                InvalidateEventHandler();
                            }
                        }
                    }

                    if (InvalidateEventHandler != null)
                    {
                        InvalidateEventHandler();
                    }
                }
                    break;
            }
        }
    }
}
