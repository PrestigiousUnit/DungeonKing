using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class Player
    {
        static int dmg = 5;
        int maxhp = 10;
        string name;
        public static int def;
        static int currhp;

        Weapon Weap = new Weapon();
        Equipment equip1 = new HeadGear(1), equip2 = new UpperBodyGear(3), equip3 = new LowerBodyGear(2), equip4 = new Accessory(4);

        public Player()
        {
            Weap.Arsenal("C Long Sword");
            MaxHealth += equip1.IHP + equip2.IHP + equip3.IHP + equip4.IHP;
            currHp = MaxHealth;
            PDamage = dmg + Weap.Damage;
        }

        //get sets
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int MaxHealth
        {
            get { return maxhp; }
            set { maxhp = value; }
        }

        public static int currHp
        {
            get { return currhp; }
            set { currhp = value; }
        }

        public static int PDamage
        {
            get { return dmg; }
            set { dmg = value; }
        }
        
        // methods
        public void Combat()
        {
            Console.WriteLine("What move would you like to do?");
            Console.WriteLine("1.Attack \n2.Defend \n3.Use potion");

            int choice = int.Parse(Console.ReadLine());
            def = 0;
            switch (choice)
            {
                case 1:
                    Attack(PDamage);
                    break;
                case 2:
                    Defend();
                    break;
                case 3:
                    UsePotion();
                    break;
            }
        }
        public void Attack(int damage)
        {
            Random rand = new Random();
            int chance = rand.Next(1, 101);

            Console.Clear();
            if (chance <= 25) // probability of 25%
            {
                //attack miss
                Console.WriteLine("Attack missed!");
            }
            else
            {
                if (Mob.def == 1)
                {
                    //attack blocked
                    Console.WriteLine("Attack was blocked!");
                }
                else
                {
                    //attack hits
                    Console.WriteLine("Target hit!");
                    Mob.ReceiveDamage(damage);
                }
                
            }
        }

        public void Defend()
        {
            Console.Clear();
            Console.WriteLine("You prepare to block!");
            def++;
        }

        public void UsePotion(/* List<string[,]> Items */)
        {
            /*
            int tempHp = MaxHealth - currHp
            for (int page = 0; page != Items.Count; page++)
                for (int row = 0; row < Items[page].GetLength(0); row++)
                    for (int col = 0; col < Items[page].GetLength(1); col++)
                        if (Items[page][row, col].Contains("Potion"))
                        {
                            if (tempHp <= 20)
                                currHp += tempHp;
                            else
                                currHp += 20;
                            Items[page][row, col].Substring(Items[page][row, col].Length - 2, Items[page][row, col].Length - 1);
                        }
                        else
                        {
                            Console.WriteLine("You dont have any potions!");
                        }
            */
        }
        public static void ReceiveDamage(int amount)
        {
            Player.currHp -= amount;
        }
        public void Status()
        {
            /*
                Player Name:        Kevin
                Health/Max Health:  10/20
                Damage:             20
                Weapon:             Long Sword[+15 dmg]
                Head Gear:          none[+0]
                Body Gear:          Leather coat [+10 hp]
                
                *Magic*
                    Fireball
             */
            Console.Clear();
            Console.WriteLine("|Name:                    " + name);
            Console.WriteLine("|Health/Max Health:       " + currHp + "/" + MaxHealth);
            Console.WriteLine("|Damage:                  " + PDamage);
            Console.WriteLine("|Weapon:                  " + Weap.Name + " [ + " + Weap.Damage + " dmg]");
            Console.WriteLine("|Head Gear:               " + equip1.Name + " [ + " + equip1.IHP + " hp]");
            Console.WriteLine("|Upper Body Gear:         " + equip2.Name + " [ + " + equip2.IHP + " hp]");
            Console.WriteLine("|Lower Body Gear:         " + equip3.Name + " [ + " + equip3.IHP + " hp]");
            Console.WriteLine("|Accessory:               " + equip4.Name + " [ + " + equip4.IHP + " hp]");
        }
    }
}
