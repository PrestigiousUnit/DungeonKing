using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class Mob
    {
        static int dmg;
        string name;
        static int currhp;
        int Potion;
        public static int def;

        public Mob(string _name)
        {
            name = _name;
            dmg = 5;
            currHp = 50;
            Potion = 5;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public static int currHp
        {
            get { return currhp; }
            set { currhp = value; }
        }

        public static int MDamage
        {
            get { return dmg; }
            set { dmg = value; }
        }


        public void Combat() 
        {
            Random gen = new Random();
            int n1 = gen.Next(1, 101);
            int choice = gen.Next(1, 4);
            if (n1 <= 15) // probability of 15%
                choice = 4;
            else if (n1 >= 60) // probability of 40%
                choice = 1;
            def = 0;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monster attacks");
                    Attack(MDamage);
                    break;
                case 2:
                    Console.WriteLine("Monster Defend");
                    Defend();
                    break;
                case 4:
                    Console.WriteLine("Monster uses potion");
                    UsePotion();
                    break;
                case 3:
                    Console.WriteLine("Monster farted");
                    break;
            }
        }

        public void Attack(int damage)
        {
            if (Player.def == 1)
            {
                //Player Blocks
                Console.WriteLine("Blocked monster attack");
            }
            else
            {
                Player.ReceiveDamage(damage);
            }
        }

        public void Defend()
        {
            def++;
        }

        public static void ReceiveDamage(int amount)
        {
            Mob.currHp -= amount;
        }

        public void UsePotion()
        {
            if (Potion > 0)
            {
                currHp += 20;
                Potion--;
            }
            else
            {
                Potion = 0;
            }
        }

    }
}
// weaker enemy chance to summon more enemy

/*
 
    Mob moving Ai

 Random rand = new Random();

 int chance = rand.Next(1, 101);
 int eAi = rand.Next(1, 5);

  if (chance <= 25) // probability of 25%
  {
        //mob moves
        Game.movement(eAi);
  }
  else
  {
        //mob stays
  }
    
 */
