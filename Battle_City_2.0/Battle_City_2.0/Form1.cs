using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Battle_City_2._0
{

    public partial class Form1 : Form
    {

        private static int count = 78;    //количество ячеек в ряду

        private readonly int size;

        static public Cell[,] Network =new Cell[count,count]; //создание ячеек
        
        private TankMain mainTank;
        private TankBot botTank;

        //конструктор формы
        public Form1()
        {
            InitializeComponent();
            //создание сетки на форме
            size = ClientSize.Width / count;
            
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++) 
                {
                    Network[i,j]=new Cell(size,i+1,j+1);
                }
            }
            
            //создание главного танка
            mainTank=new TankMain();
            Task.Run(mainTank.ToDrive);

            //создание танка-бота
            botTank = new TankBot(size, new Point(mainTank.CountX, mainTank.CountY));
            Task.Run(botTank.ToDrive);

        }

        //перерисовка формы
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(
                    ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
                    true);
            lock (Network)
            {
                e.Graphics.DrawImage(mainTank.ImgTank, Network[mainTank.CountX, mainTank.CountY].Point.X,
                    Network[mainTank.CountX, mainTank.CountY].Point.Y, 6 * size, 6 * size);
                try
                {
                    e.Graphics.DrawImage(botTank.ImgTank, Network[botTank.CountX, botTank.CountY].Point.X,
                                Network[botTank.CountX, botTank.CountY].Point.Y, 6 * size, 6 * size);
                }
                catch
                {
                    ;
                }
            }
        }
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            Invalidate();
        }

        //обработка нажатия клавиш 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                {
                    mainTank.IsDown = true;
                    mainTank.IsUp = false;
                    mainTank.IsLeft = false;
                    mainTank.IsRight = false;
                }
                    break;
                case Keys.W:
                {
                    mainTank.IsUp = true;
                    mainTank.IsDown = false;
                    mainTank.IsLeft = false;
                    mainTank.IsRight = false;
                    }
                    break;
                case Keys.A:
                {
                    mainTank.IsLeft = true;
                    mainTank.IsDown = false;
                    mainTank.IsUp = false;
                    mainTank.IsRight = false;
                }
                    break;
                case Keys.D:
                {
                    mainTank.IsRight = true;
                    mainTank.IsDown = false;
                    mainTank.IsUp = false;
                    mainTank.IsLeft = false;
                }
                    break;
                default:
                    break;
            } 
        }

        //обработка отпускания клавиш
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                {
                    mainTank.IsDown = false;
                }
                    break;
                case Keys.W:
                {
                    mainTank.IsUp = false;

                    }
                    break;
                case Keys.A:
                {
                    mainTank.IsLeft = false;

                    }
                    break;
                case Keys.D:
                {
                    mainTank.IsRight = false;

                    }
                    break;
                default:
                    break;
            }
        }

        
    }
}
