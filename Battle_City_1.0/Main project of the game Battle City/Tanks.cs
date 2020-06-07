namespace Main_project_of_the_game_Battle_City
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    //класс для любого танка 

    public class Tanks
    {
        public delegate void Paint();

        protected int kindOfTank;
        public Bullet bullet;
        public Size Dimension; //размеры танка
        protected MainWindow Form;
        public Image ImgTank;
        protected TankForGame MainTank;
        protected List<char> mas;
        public Point Position; //координаты танка
        public bool Live;
        protected Size OldSize;

        public Tanks(MainWindow form)
        {
            kindOfTank = 0;
            Live = true;
            mas = new List<char> {'D', 'L', 'U', 'R'};
            Form = form;
        }

        public int Speed { get; set; } //скорость танка
        public char direction { get; set; }

        public event Paint InvalidateEventHandler;

        //проверка на пересечение с границами формы
        protected bool Near_Border(Rectangle Rct)
        {
            if (Rct.Location.Y + Rct.Height >= Form.ClientSize.Height || Rct.Location.Y <= 0 || Rct.Location.X <= 0 ||
                Rct.Location.X + Rct.Width >= Form.ClientSize.Width)
            {
                return true;
            }

            return false;
        }

        //проверка на пересечение с другими танками

        protected bool Down_Tank(Rectangle Rec)
        {
            foreach (var allTank in MainWindow.AllTankBots)
            {
                if (allTank.Position.X != Rec.Location.X || allTank.Position.Y != Rec.Location.Y - Speed)
                {
                    if (new Rectangle(allTank.Position.X, allTank.Position.Y, allTank.Dimension.Width,
                        allTank.Dimension.Height).IntersectsWith(Rec)&&allTank.Live)
                    {
                        return true;
                    }
                }
            }

            foreach (var allTankM in MainWindow.AllTankMain)
            {
                if (allTankM.Position.X != Rec.Location.X || allTankM.Position.Y != Rec.Location.Y - Speed)
                {
                    if (new Rectangle(allTankM.Position.X, allTankM.Position.Y, allTankM.Dimension.Width,
                        allTankM.Dimension.Height).IntersectsWith(Rec) && allTankM.Live)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected bool Up_Tank(Rectangle Rec)
        {
            foreach (var allTank in MainWindow.AllTankBots)
            {
                if (allTank.Position.X != Rec.Location.X || allTank.Position.Y != Rec.Location.Y + Speed)
                {
                    if (new Rectangle(allTank.Position.X, allTank.Position.Y, allTank.Dimension.Width,
                        allTank.Dimension.Height).IntersectsWith(Rec) && allTank.Live)
                    {
                        return true;
                    }
                }
            }

            foreach (var allTankM in MainWindow.AllTankMain)
            {
                if (allTankM.Position.X != Rec.Location.X || allTankM.Position.Y != Rec.Location.Y + Speed)
                {
                    if (new Rectangle(allTankM.Position.X, allTankM.Position.Y, allTankM.Dimension.Width,
                        allTankM.Dimension.Height).IntersectsWith(Rec) && allTankM.Live)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected bool Left_Tank(Rectangle Rec)
        {
            foreach (var allTank in MainWindow.AllTankBots)
            {
                if (allTank.Position.X != Rec.Location.X + Speed || allTank.Position.Y != Rec.Location.Y)
                {
                    if (new Rectangle(allTank.Position.X, allTank.Position.Y, allTank.Dimension.Width,
                        allTank.Dimension.Height).IntersectsWith(Rec) && allTank.Live)
                    {
                        return true;
                    }
                }
            }

            foreach (var allTankM in MainWindow.AllTankMain)
            {
                if (allTankM.Position.X != Rec.Location.X + Speed || allTankM.Position.Y != Rec.Location.Y)
                {
                    if (new Rectangle(allTankM.Position.X, allTankM.Position.Y, allTankM.Dimension.Width,
                        allTankM.Dimension.Height).IntersectsWith(Rec) && allTankM.Live)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected bool Right_Tank(Rectangle Rec)
        {
            foreach (var allTank in MainWindow.AllTankBots)
            {
                if (allTank.Position.X != Rec.Location.X - Speed || allTank.Position.Y != Rec.Location.Y)
                {
                    if (new Rectangle(allTank.Position.X, allTank.Position.Y + Speed, allTank.Dimension.Width,
                        allTank.Dimension.Height).IntersectsWith(Rec) && allTank.Live)
                    {
                        return true;
                    }
                }
            }

            foreach (var allTankM in MainWindow.AllTankMain)
            {
                if (allTankM.Position.X != Rec.Location.X - Speed || allTankM.Position.Y != Rec.Location.Y)
                {
                    if (new Rectangle(allTankM.Position.X, allTankM.Position.Y, allTankM.Dimension.Width,
                        allTankM.Dimension.Height).IntersectsWith(Rec) && allTankM.Live)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //проверка на пересечение с преградами 

        protected bool Near_Wall(Rectangle Rect)
        {
            //пересечение с базой
            if (new Rectangle(MainWindow.MapAny.Base.PtPoint, MainWindow.MapAny.Base.SzSize).IntersectsWith(Rect)&& MainWindow.MapAny.Base.Live)
            {
                return true;
            }

            //пересечение с кирпичной преградой
            foreach (var lt in MainWindow.MapAny.MasBrick)
            {
                if (new Rectangle(lt.PtPoint, lt.SzSize).IntersectsWith(Rect) && lt.Live)
                {
                    return true;
                }
            }

            //пересечение с бетонной преградой
            foreach (var lt in MainWindow.MapAny.MasBeton)
            {
                if (new Rectangle(lt.PtPoint, lt.SzSize).IntersectsWith(Rect) && lt.Live)
                {
                    return true;
                }
            }

            //пересечение с водой
            foreach (var lt in MainWindow.MapAny.MasWater)
            {
                if (new Rectangle(lt.PtPoint, lt.SzSize).IntersectsWith(Rect) && lt.Live)
                {
                    return true;
                }
            }

            return false;
        }

        //функции движения

        public void movementTank_Left() //влево
        {
            Position.X -= Speed;
            if (InvalidateEventHandler != null)
            {
                InvalidateEventHandler();
            }
        }

        public void movementTank_Right() //вправо
        {
            Position.X += Speed;
            if (InvalidateEventHandler != null)
            {
                InvalidateEventHandler();
            }
        }

        public void movementTank_Up() //вверх
        {
            Position.Y -= Speed;
            if (InvalidateEventHandler != null)
            {
                InvalidateEventHandler();
            }
        }

        public void movementTank_Down() //вниз
        {
            Position.Y += Speed;
            if (InvalidateEventHandler != null)
            {
                InvalidateEventHandler();
            }
        }
    }
}
