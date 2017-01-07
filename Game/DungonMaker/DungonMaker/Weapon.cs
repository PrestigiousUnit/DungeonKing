using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class Weapon : Item
    {
        int dmg;

        public Weapon()
        {

        }
        
        public int Damage
        {
            get { return dmg; }
            set { dmg = value; }
        }

        public string Arsenal(string lop)
        {
            switch (lop)
            {
                case "C Spear":
                    Name = "Copper Spear";
                    Damage = 5;
                    Cost = 14;
                    break;

                case "C Long Sword":
                    Name = "Copper Long Sword";
                    Damage = 10;
                    Cost = 15;
                    break;
                case "I Long Sword":
                    Name = "Iron Long Sword";
                    Damage = 15;
                    Cost = 45;
                    break;
            }
            
            return "";
        }
    }
}
