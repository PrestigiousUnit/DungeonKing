using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class LowerBodyGear : Equipment
    {
        public LowerBodyGear(int level)
        {
            switch (level)
            {
                case 1:
                    Name = "Coppper Pants";
                    Type = "Lower Body Gear";
                    IHP = 2;
                    break;
                case 2:
                    Name = "Silver Pants";
                    Type = "Lower Body Gear";
                    IHP = 4;
                    break;
                case 3:
                    Name = "Gold Pants";
                    Type = "Lower Body Gear";
                    IHP = 6;
                    break;
                case 4:
                    Name = "Goat Legs";
                    Type = "Lower Body Gear";
                    IHP = 8;
                    break;
            }
        }
    }
}
