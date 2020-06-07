using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_project_of_the_game_Battle_City
{
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;
    using Properties;

    public class Maps
    {
        public Walls[] MasBrick;
        public Walls[] MasBeton;
        public Walls[] MasGrass;
        public Walls[] MasWater;
        public Walls Base;

        //private int sizeForm;

        public Maps(int clientSize, int numberMap)
        {
            //sizeForm = clientSize;
            switch (numberMap)
            {
                case 1:
                    Map1(clientSize);
                    break;
                default:
                    break;
            }
        }

        private void Map1(int sizeForm)
        {
            //создание массива с травой
            MasGrass = new Walls[15];
            MasGrass[0] = new Walls(Resources.grass, sizeForm / 13, 10, 0);
            MasGrass[1] = new Walls(Resources.grass, sizeForm / 13, 11, 0);
            MasGrass[2] = new Walls(Resources.grass, sizeForm / 13, 9, 1);
            MasGrass[3] = new Walls(Resources.grass, sizeForm / 13, 10, 1);
            MasGrass[4] = new Walls(Resources.grass, sizeForm / 13, 11, 1);
            MasGrass[5] = new Walls(Resources.grass, sizeForm / 13, 2, 5);
            MasGrass[6] = new Walls(Resources.grass, sizeForm / 13, 3, 5);
            MasGrass[7] = new Walls(Resources.grass, sizeForm / 13, 4, 5);
            MasGrass[8] = new Walls(Resources.grass, sizeForm / 13, 11, 5);
            MasGrass[9] = new Walls(Resources.grass, sizeForm / 13, 12, 5);
            MasGrass[10] = new Walls(Resources.grass, sizeForm / 13, 2, 6);
            MasGrass[11] = new Walls(Resources.grass, sizeForm / 13, 12, 6);
            MasGrass[12] = new Walls(Resources.grass, sizeForm / 13, 2, 7);
            MasGrass[13] = new Walls(Resources.grass, sizeForm / 13, 3, 8);
            MasGrass[14] = new Walls(Resources.grass, sizeForm / 13, 4, 9);

            //создание массива с водой
            MasWater = new Walls[7];
            MasWater[0] = new Walls(Resources.water, sizeForm / 13, 3, 0);
            MasWater[1] = new Walls(Resources.water, sizeForm / 13, 3, 1);
            MasWater[2] = new Walls(Resources.water, sizeForm / 13, 2, 3);
            MasWater[3] = new Walls(Resources.water, sizeForm / 13, 0, 4);
            MasWater[4] = new Walls(Resources.water, sizeForm / 13, 2, 4);
            MasWater[5] = new Walls(Resources.water, sizeForm / 13, 11, 4);
            MasWater[6] = new Walls(Resources.water, sizeForm / 13, 12, 4);

            //создание массива с преградами из кирпича
            MasBrick = new Walls[56];
            MasBrick[0] = new Walls(Resources.brick, sizeForm / 26, 13, 6);
            MasBrick[1] = new Walls(Resources.brick, sizeForm / 26, 14, 6);
            MasBrick[2] = new Walls(Resources.brick, sizeForm / 26, 15, 6);
            MasBrick[3] = new Walls(Resources.brick, sizeForm / 26, 16, 6);
            MasBrick[4] = new Walls(Resources.brick, sizeForm / 26, 12, 7);
            MasBrick[5] = new Walls(Resources.brick, sizeForm / 26, 13, 7);
            MasBrick[6] = new Walls(Resources.brick, sizeForm / 26, 14, 7);
            MasBrick[7] = new Walls(Resources.brick, sizeForm / 26, 15, 7);
            MasBrick[8] = new Walls(Resources.brick, sizeForm / 26, 16, 7);
            MasBrick[9] = new Walls(Resources.brick, sizeForm / 26, 17, 7);
            MasBrick[10] = new Walls(Resources.brick, sizeForm / 26, 10, 8);
            MasBrick[11] = new Walls(Resources.brick, sizeForm / 26, 11, 8);
            MasBrick[12] = new Walls(Resources.brick, sizeForm / 26, 10, 9);
            MasBrick[13] = new Walls(Resources.brick, sizeForm / 26, 11, 9);
            MasBrick[14] = new Walls(Resources.brick, sizeForm / 26, 11, 10);
            MasBrick[15] = new Walls(Resources.brick, sizeForm / 26, 11, 11);
            MasBrick[16] = new Walls(Resources.brick, sizeForm / 26, 10, 12);
            MasBrick[17] = new Walls(Resources.brick, sizeForm / 26, 10, 13);
            MasBrick[18] = new Walls(Resources.brick, sizeForm / 26, 11, 12);
            MasBrick[19] = new Walls(Resources.brick, sizeForm / 26, 11, 13);
            MasBrick[20] = new Walls(Resources.brick, sizeForm / 26, 11, 14);
            MasBrick[21] = new Walls(Resources.brick, sizeForm / 26, 11, 15);
            MasBrick[22] = new Walls(Resources.brick, sizeForm / 26, 13, 19);
            MasBrick[23] = new Walls(Resources.brick, sizeForm / 26, 14, 19);
            MasBrick[24] = new Walls(Resources.brick, sizeForm / 26, 13, 18);
            MasBrick[25] = new Walls(Resources.brick, sizeForm / 26, 14, 18);
            MasBrick[26] = new Walls(Resources.brick, sizeForm / 26, 15, 18);
            MasBrick[27] = new Walls(Resources.brick, sizeForm / 26, 15, 19);
            MasBrick[28] = new Walls(Resources.brick, sizeForm / 26, 11, 18);
            MasBrick[29] = new Walls(Resources.brick, sizeForm / 26, 12, 18);
            MasBrick[30] = new Walls(Resources.brick, sizeForm / 26, 10, 18);
            MasBrick[31] = new Walls(Resources.brick, sizeForm / 26, 10, 19);
            MasBrick[32] = new Walls(Resources.brick, sizeForm / 26, 11, 19);
            MasBrick[33] = new Walls(Resources.brick, sizeForm / 26, 12, 19);
            MasBrick[34] = new Walls(Resources.brick, sizeForm / 26, 18, 11);
            MasBrick[35] = new Walls(Resources.brick, sizeForm / 26, 19, 11);
            MasBrick[36] = new Walls(Resources.brick, sizeForm / 26, 11, 25);
            MasBrick[37] = new Walls(Resources.brick, sizeForm / 26, 11, 24);
            MasBrick[38] = new Walls(Resources.brick, sizeForm / 26, 11, 23);
            MasBrick[39] = new Walls(Resources.brick, sizeForm / 26, 12, 23);
            MasBrick[40] = new Walls(Resources.brick, sizeForm / 26, 13, 23);
            MasBrick[41] = new Walls(Resources.brick, sizeForm / 26, 14, 23);
            MasBrick[42] = new Walls(Resources.brick, sizeForm / 26, 14, 24);
            MasBrick[43] = new Walls(Resources.brick, sizeForm / 26, 14, 25);
            MasBrick[44] = new Walls(Resources.brick, sizeForm / 26, 10, 25);
            MasBrick[45] = new Walls(Resources.brick, sizeForm / 26, 10, 24);
            MasBrick[46] = new Walls(Resources.brick, sizeForm / 26, 10, 23);
            MasBrick[47] = new Walls(Resources.brick, sizeForm / 26, 10, 22);
            MasBrick[48] = new Walls(Resources.brick, sizeForm / 26, 11, 22);
            MasBrick[49] = new Walls(Resources.brick, sizeForm / 26, 12, 22);
            MasBrick[50] = new Walls(Resources.brick, sizeForm / 26, 13, 22);
            MasBrick[51] = new Walls(Resources.brick, sizeForm / 26, 14, 22);
            MasBrick[52] = new Walls(Resources.brick, sizeForm / 26, 15, 22);
            MasBrick[53] = new Walls(Resources.brick, sizeForm / 26, 15, 23);
            MasBrick[54] = new Walls(Resources.brick, sizeForm / 26, 15, 24);
            MasBrick[55] = new Walls(Resources.brick, sizeForm / 26, 15, 25);

            //создание массива с преградами из бетона
            MasBeton = new Walls[17];
            MasBeton[0] = new Walls(Resources.beton, sizeForm / 13, 6, 1);
            MasBeton[1] = new Walls(Resources.beton, sizeForm / 13, 7, 4);
            MasBeton[2] = new Walls(Resources.beton, sizeForm / 13, 0, 5);
            MasBeton[3] = new Walls(Resources.beton, sizeForm / 13, 6, 5);
            MasBeton[4] = new Walls(Resources.beton, sizeForm / 13, 7, 5);
            MasBeton[5] = new Walls(Resources.beton, sizeForm / 13, 8, 5);
            MasBeton[6] = new Walls(Resources.beton, sizeForm / 13, 7, 6);
            MasBeton[7] = new Walls(Resources.beton, sizeForm / 13, 6, 7);
            MasBeton[8] = new Walls(Resources.beton, sizeForm / 13, 8, 7);
            MasBeton[9] = new Walls(Resources.beton, sizeForm / 13, 1, 8);
            MasBeton[10] = new Walls(Resources.beton, sizeForm / 13, 0, 9);
            MasBeton[11] = new Walls(Resources.beton, sizeForm / 13, 10, 10);
            MasBeton[12] = new Walls(Resources.beton, sizeForm / 13, 12, 10);
            MasBeton[13] = new Walls(Resources.beton, sizeForm / 13, 2, 11);
            MasBeton[14] = new Walls(Resources.beton, sizeForm / 13, 12, 11);
            MasBeton[15] = new Walls(Resources.beton, sizeForm / 13, 12, 12);
            MasBeton[16] = new Walls(Resources.beton, sizeForm / 13, 10, 11);

            //создание базы
            Base = new Walls(Resources.bas, sizeForm / 13, 6, 12);
        }

        public void ChangeMap(int sizeForm)
        {
            for (int i = 0; i < MasWater.Length; i++)
            {
                MasWater[i].Change(sizeForm / 13);
            }

            for (int i = 0; i < MasGrass.Length; i++)
            {
                MasGrass[i].Change(sizeForm / 13);
            }

            for (int i = 0; i < MasBeton.Length; i++)
            {
                MasBeton[i].Change(sizeForm / 13);
            }

            for (int i = 0; i < MasBrick.Length; i++)
            {
                MasBrick[i].Change(sizeForm / 26);
            }

            Base.Change(sizeForm / 13);
        }
    }
}
