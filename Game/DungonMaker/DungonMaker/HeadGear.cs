using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class HeadGear : Equipment
    {
        public HeadGear(int level)
        {
            switch (level)
            {
                case 1:
                    Name = "Coppper Helm";
                    Type = "Head Gear";
                    IHP = 2;
                    break;
                case 2:
                    Name = "Silver Helm";
                    Type = "Head Gear";
                    IHP = 4;
                    break;
                case 3:
                    Name = "Gold Helm";
                    Type = "Head Gear";
                    IHP = 6;
                    break;
                case 4:
                    Name = "Lizard Face";
                    Type = "Head Gear";
                    IHP = 8;
                    break;
            }
        }
    }
}
