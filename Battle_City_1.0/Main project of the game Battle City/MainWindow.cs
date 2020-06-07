namespace Main_project_of_the_game_Battle_City
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Media;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Properties;

    public partial class MainWindow : Form
    {
        public static List<Tank_Bot> AllTankBots;

        public static List<TankForGame> AllTankMain;

        public static Maps MapAny;

        private SoundPlayer Audio;
        private bool playAudio = true;


        private int count;
        private int number;

        public static bool stop { get; set; }
        private Random rnd;


        public MainWindow()
        {
            InitializeComponent();
            Audio = new SoundPlayer();
            Audio.Stream = Resources.music;
            playAudio = true;
            this.Focus();
        }

        private void Func()
        {
            panel.Visible = false;
            panel.Enabled = false;
            this.Focus();
            rnd = new Random();
            count = rnd.Next(0, 7);
            MapAny = new Maps(ClientSize.Width, 1);

            //создание листа со всеми танками-ботами
            AllTankBots = new List<Tank_Bot>();

            //создание листа с главными танками;
            AllTankMain = new List<TankForGame>();

            if (number == 1)
            {
                AllTankMain.Add(new TankForGame(this, ClientSize.Width / 13, 1));
                AllTankMain[0].InvalidateEventHandler += Invalidate;
                Task.Factory.StartNew(AllTankMain[0].TMain_Movement);
            }
            else
            {
                AllTankMain.Add(new TankForGame(this, ClientSize.Width / 13, 1));
                AllTankMain[0].InvalidateEventHandler += Invalidate;
                Task.Factory.StartNew(AllTankMain[0].TMain_Movement);
                AllTankMain.Add(new TankForGame(this, ClientSize.Width / 13, 2));
                AllTankMain[1].InvalidateEventHandler += Invalidate;
                Task.Factory.StartNew(AllTankMain[1].TMain_Movement);
            }

            //включение музыки
            if (playAudio) Audio.Play();

            //создание танков-ботов
            GenerationOfTanks();
        }


        //генерация танков-ботов
        private void GenerationOfTanks()
        {
            Tank_Bot tbot;
            while (AllTankBots.Count <= count)
            {
                count = rnd.Next(1, 7);
                tbot = new Tank_Bot(this, ClientSize.Width / 13, rnd);
                AllTankBots.Add(tbot);
                tbot.InvalidateEventHandler += Invalidate;
                try
                {
                    Task.Factory.StartNew(AllTankBots[AllTankBots.IndexOf(tbot)].TBot_Movement);
                }
                catch (NullReferenceException)
                {
                    ;
                }
            }
        }

        //изменение размеров окна
        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            var k = Width;
            while ((k - 16) % 26 != 0 && k <= MaximumSize.Width)
            {
                k++;
            }

            Width = k;
            Height = Width + 23;
            MapAny.ChangeMap(ClientSize.Width);

            foreach (var allTank in AllTankMain)
            {
                allTank.Change(ClientSize.Width / 13);
            }

            foreach (var allTank in AllTankBots)
            {
                allTank.Change(ClientSize.Width / 13);
            }
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
                true);
            if (!panel.Enabled)
            {
                //создание танков ботов
                GenerationOfTanks();

                //прорисовка преград
                for (var i = 0; i < MapAny.MasBrick.Length; i++)
                {
                    if (MapAny.MasBrick[i].Live)
                    {
                        e.Graphics.DrawImage(MapAny.MasBrick[i].Img, MapAny.MasBrick[i].PtPoint.X,
                            MapAny.MasBrick[i].PtPoint.Y, MapAny.MasBrick[i].SzSize.Width,
                            MapAny.MasBrick[i].SzSize.Height);
                    }
                }

                if (MapAny.Base.Live)
                {
                    e.Graphics.DrawImage(MapAny.Base.Img, MapAny.Base.PtPoint.X, MapAny.Base.PtPoint.Y,
                        MapAny.Base.SzSize.Width, MapAny.Base.SzSize.Height);
                }

                for (var i = 0; i < MapAny.MasBeton.Length; i++)
                {
                    e.Graphics.DrawImage(MapAny.MasBeton[i].Img, MapAny.MasBeton[i].PtPoint.X,
                        MapAny.MasBeton[i].PtPoint.Y, MapAny.MasBeton[i].SzSize.Width,
                        MapAny.MasBeton[i].SzSize.Height);
                }

                for (var i = 0; i < MapAny.MasWater.Length; i++)
                {
                    e.Graphics.DrawImage(MapAny.MasWater[i].Img, MapAny.MasWater[i].PtPoint.X,
                        MapAny.MasWater[i].PtPoint.Y, MapAny.MasWater[i].SzSize.Width,
                        MapAny.MasWater[i].SzSize.Height);
                }

                //прорисовка танков-ботов и их пуль
                try
                {
                    foreach (var allTankBot in AllTankBots)
                    {
                        //if (allTankBot.Live)
                        {
                            allTankBot.ChoiceOfTank();
                            e.Graphics.DrawImage(allTankBot.ImgTank, allTankBot.Position.X, allTankBot.Position.Y,
                                allTankBot.Dimension.Width, allTankBot.Dimension.Height);
                        }

                        if (allTankBot.bullet != null && allTankBot.bullet.life)
                        {
                            e.Graphics.DrawImage(allTankBot.bullet.ImgBullet, allTankBot.bullet.Position.X,
                                allTankBot.bullet.Position.Y, allTankBot.bullet.Dimension.Width,
                                allTankBot.bullet.Dimension.Height);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                }

                //перерисовка главного танка
                try
                {
                    foreach (var allTankM in AllTankMain)
                    {
                        //if (allTankM.Live)
                        {
                            e.Graphics.DrawImage(allTankM.ImgTank, allTankM.Position.X, allTankM.Position.Y,
                                allTankM.Dimension.Width, allTankM.Dimension.Height);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                }

                //прорисовка пули главного танка
                foreach (var allTankM in AllTankMain)
                {
                    if (allTankM.bullet != null && allTankM.bullet.life)
                    {
                        e.Graphics.DrawImage(allTankM.bullet.ImgBullet, allTankM.bullet.Position.X,
                            allTankM.bullet.Position.Y, allTankM.bullet.Dimension.Width,
                            allTankM.bullet.Dimension.Height);
                    }
                }

                //перерисовка зелени
                for (var i = 0; i < MapAny.MasGrass.Length; i++)
                {
                    e.Graphics.DrawImage(MapAny.MasGrass[i].Img, MapAny.MasGrass[i].PtPoint.X,
                        MapAny.MasGrass[i].PtPoint.Y, MapAny.MasGrass[i].SzSize.Width,
                        MapAny.MasGrass[i].SzSize.Height);
                }
            }
        }

        int j;

        //обработка нажатия клавиш
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (AllTankMain.Count == 2)
            {
                j = 1;
            }
            else if (AllTankMain.Count == 1)
            {
                j = 0;
            }

            else return;

                switch (e.KeyCode)
                {
                    case Keys.R:
                    {
                        playAudio = !playAudio;
                        if (playAudio)
                            Audio.Play();
                        else
                            Audio.Stop();
                    }
                        break;
                    case Keys.P:
                    {
                        stop = !stop;
                    }
                        break;
                    case Keys.A:
                    {
                        if (AllTankMain[0].id)
                        {
                            AllTankMain[0].isLeft = true;
                            AllTankMain[0].isUp = false;
                            AllTankMain[0].isRight = false;
                            AllTankMain[0].IsDown = false;
                        }
                    }
                        break;
                    case Keys.W:
                    {
                        if (AllTankMain[0].id)
                        {
                            AllTankMain[0].isUp = true;
                            AllTankMain[0].isLeft = false;
                            AllTankMain[0].isRight = false;
                            AllTankMain[0].IsDown = false;
                        }
                    }
                        break;
                    case Keys.D:
                    {
                        if (AllTankMain[0].id)
                        {
                            AllTankMain[0].isRight = true;
                            AllTankMain[0].isLeft = false;
                            AllTankMain[0].isUp = false;
                            AllTankMain[0].IsDown = false;
                        }
                    }
                        break;
                    case Keys.S:
                    {
                        if (AllTankMain[0].id)
                        {
                            AllTankMain[0].IsDown = true;
                            AllTankMain[0].isLeft = false;
                            AllTankMain[0].isUp = false;
                            AllTankMain[0].isRight = false;
                        }
                    }
                        break;
                    case Keys.Space:
                    {
                        if (AllTankMain[0].id) AllTankMain[0].isfire = true;
                    }
                        break;
                    case Keys.Left:
                    {
                        if (number == 2)
                        {
                            AllTankMain[j].isLeft = true;
                            AllTankMain[j].isUp = false;
                            AllTankMain[j].isRight = false;
                            AllTankMain[j].IsDown = false;
                        }
                    }
                        break;
                    case Keys.Up:
                    {
                        if (number == 2)
                        {
                            AllTankMain[j].isUp = true;
                            AllTankMain[j].isLeft = false;
                            AllTankMain[j].isRight = false;
                            AllTankMain[j].IsDown = false;
                        }
                    }
                        break;
                    case Keys.Right:
                    {
                        if (number == 2)
                        {
                            AllTankMain[j].isRight = true;
                            AllTankMain[j].isLeft = false;
                            AllTankMain[j].isUp = false;
                            AllTankMain[j].IsDown = false;
                        }
                    }
                        break;
                    case Keys.Down:
                    {
                        if (number == 2)
                        {
                            AllTankMain[j].IsDown = true;
                            AllTankMain[j].isLeft = false;
                            AllTankMain[j].isUp = false;
                            AllTankMain[j].isRight = false;
                        }
                    }
                        break;
                    case Keys.NumPad0:
                    case Keys.M:
                    {
                        if (number == 2)
                        {
                            AllTankMain[j].isfire = true;
                        }
                    }
                        break;
                }
        }

        //обработка отпускания клавиш
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (AllTankMain.Count == 2)
            {
                j = 1;
            }
            else if (AllTankMain.Count == 1)
            {
                j = 0;
            }
            else
                return;
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (AllTankMain[0].id) AllTankMain[0].isLeft = false;
                    break;
                case Keys.W:
                    if (AllTankMain[0].id) AllTankMain[0].isUp = false;
                    break;
                case Keys.D:
                    if (AllTankMain[0].id) AllTankMain[0].isRight = false;
                    break;
                case Keys.S:
                    if (AllTankMain[0].id) AllTankMain[0].IsDown = false;
                    break;
                case Keys.Space:
                    if (AllTankMain[0].id) AllTankMain[0].isfire = false;
                    break;
                case Keys.Left:
                    if (number == 2) AllTankMain[j].isLeft = false;
                    break;
                case Keys.Up:
                    if (number == 2) AllTankMain[j].isUp = false;
                    break;
                case Keys.Right:
                    if (number == 2) AllTankMain[j].isRight = false;
                    break;
                case Keys.Down:
                    if (number == 2) AllTankMain[j].IsDown = false;
                    break;
                case Keys.NumPad0:
                case Keys.M:
                    if (number == 2) AllTankMain[j].isfire = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            number = 1;
            Func();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number = 2;
            Func();
        }
    }
}
