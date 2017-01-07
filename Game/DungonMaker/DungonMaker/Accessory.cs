using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class Accessory : Equipment
    {
        public Accessory(int level)
        {
            switch (level)
            {
                case 1:
                    Name = "Coppper Amulet";
                    Type = "Accessory";
                    IHP = 1;
                    break;
                case 2:
                    Name = "Silver Amulet";
                    Type = "Accessory";
                    IHP = 2;
                    break;
                case 3:
                    Name = "Gold Amulet";
                    Type = "Accessory";
                    IHP = 3;
                    break;
                case 4:
                    Name = "Skull Ring";
                    Type = "Accessory";
                    IHP = 4;
                    break;
            }
        }
    }
}
