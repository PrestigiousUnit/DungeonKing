using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class Item
    {
        int id;
        int _cost;
        string _name;

        public Item()
        {

        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        
        public void KillMe()
        {
            switch (Id)
            {
                //sellable items
                case 11:
                    Name = "Gold Coin";
                    Cost = 1;
                    break;
                case 12:
                    Name = "Iron ore";
                    Cost = 23;
                    break;
                case 13:
                    Name = "Gold ore";
                    Cost = 30;
                    break;
                case 14:
                    Name = "Ruby";
                    Cost = 35;
                    break;
                case 15:
                    Name = "Diamond";
                    Cost = 40;
                    break;
                case 16:
                    Name = "Copper ore";
                    Cost = 7;
                    break;
                case 17:
                    Name = "Gravel";
                    Cost = 4;
                    break;
                case 18:
                    Name = "Wand";
                    Cost = 50;
                    break;
                
                //buy/loot item
                case 19:
                    Name = "Health Potion";
                    Cost = 30;
                    break;
                //buyable items
                
                //win item
                case 20:
                    Name = "Dungeon Core";
                    Cost = 9001;
                    break;
            }
        }


    }
}
