using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class UpperBodyGear : Equipment
    {
        public UpperBodyGear(int level)
        {
            switch (level)
            {
                case 1:
                    Name = "Coppper Armour";
                    Type = "Upper Body Gear";
                    IHP = 5;
                    break;
                case 2:
                    Name = "Silver Armour";
                    Type = "Upper Body Gear";
                    IHP = 10;
                    break;
                case 3:
                    Name = "Gold Armour";
                    Type = "Upper Body Gear";
                    IHP = 15;
                    break;
                case 4:
                    Name = "Tiger hat";
                    Type = "Upper Body Gear";
                    IHP = 20;
                    break;
            }
        }
    }
}
