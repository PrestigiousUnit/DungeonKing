using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class GameMech
    {
        public GameMech()
        {

        }

        public void CombatScreen()
        {
            Console.ReadLine();
            Console.Clear();
        }

        public void Combat()
        {
            Random gen = new Random();
            Player p1 = new Player();
            Mob m1 = new Mob("slime");
            int t = gen.Next(1, 3);

            p1.Status();
            CombatScreen();

            while (Mob.currHp >= 1 &&
                Player.currHp >= 1)
            {
                Console.WriteLine("A monster has Appeared and threw up on you!\n");
                if (t == 1)
                {
                    if (Player.currHp > 0)
                    {
                        //player attacks
                        Console.WriteLine("Player HP:" + Player.currHp);
                        p1.Combat();
                        t++;
                        CombatScreen();
                    }
                    else
                    {
                        Console.WriteLine("Player HP:" + Player.currHp);
                        Console.WriteLine("You Died buddy old pal");
                    }
                    
                }
                if (Mob.currHp < 2)
                {
                    Console.WriteLine("Monster Defeated");
                    Console.ReadLine();
                }
                else
                {
                    // mob attack
                    Console.WriteLine("Monster HP:" + Mob.currHp);
                    m1.Combat();
                    t--;
                    CombatScreen();
                }
                
            }
        }

        public void RandChance()
        {
            RandChanceDigBlock();
            RandChanceMob();
        }
        
        public void RandChanceDigBlock()
        {

        }

        public void RandChanceMob()
        {

        }

       
    }
}
