using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class Game
    {
        List<string[,]> invs = new List<string[,]>();
        List<string[,]> tempname;
        List<int> wallcount = new List<int>();
        List<int> temp = new List<int>();
        List<bool> Stairs = new List<bool>();
        string Pxy;
        int floori = 0;
        string Pname;
        //Monster cords
        public Game(string pName)
        {
            Pname = pName;
            tempname = GameCreation();
        }
        public List<string[,]> GameCreation()
        {
            Inventory inv = new Inventory();
            string[,] inv1, inv2, inv3;
            inv1 = inv.Gridsetup(); inv2 = inv.Gridsetup(); inv3 = inv.Gridsetup();
            invs.Add(inv1); invs.Add(inv2); invs.Add(inv3);
            invs[0][1, 1] = "A";
            List<string[,]> n3w = new List<string[,]>();
            World bob = new World();
            for (int i = 0; i < 20; i++)
                n3w.Add(bob.WorldGeneration());
            Pxy = bob.RandomLocation(n3w[0]);
            for (int i = 0; i < n3w.Count; i++)
            { wallcount.Add(0); temp.Add(0); Stairs.Add(true); }
            return n3w;
        }
        public List<string[,]> UI()
        {
            Inventory inv = new Inventory();
            World bob = new World();
            for (int floor = floori; floor < tempname.Count;)
            {
                //Monster Moves Here
                if (tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] == "v" || tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] == "^")
                {
                    Console.Clear();
                    Console.WriteLine("Floor " + (floor + 1));
                    bob.UpdateWorld(tempname[floor], int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2)), Pname);
                    string direction = "up";
                    if (tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] == "v")
                        direction = "down";
                    Console.WriteLine("Would you like to go " + direction + " the stairs?\n\"y\" or \"n\"");
                    if (Console.ReadKey().KeyChar == 'y')
                        if (direction == "up")
                            floor--;
                        else
                            floor++;
                }
                floori = floor;
                if (tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] != "v" && tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] != "^")
                        tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] = "R";
                Console.Clear();
                Console.WriteLine("Floor " + (floor + 1));
                temp[floor] = bob.UpdateWorld(tempname[floor], int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2)), Pname);
                string textA = "\t";
                string textB = "l: Leave Game";
                string TempText = "";
                if (wallcount[floor] >= .6 * (temp[floor] + wallcount[floor]) && Stairs[floor] == true && floor + 1 < tempname.Count)
                { textA = "S: Place Stairs"; TempText = textA; textA = textB; textB = TempText; }
                Console.WriteLine("i: Open Inventory\t\t\t  w\nk: Status Menu\t\t\t\ta   d\n" + textB + "\t\t\t\t  s\n" + textA);
                ConsoleKeyInfo choice = Console.ReadKey();
                switch (choice.KeyChar)
                {
                    case 'w':
                        Pxy = movement(1, Pxy);
                        break;
                    case 'a':
                        Pxy = movement(2, Pxy);
                        break;
                    case 's':
                        Pxy = movement(3, Pxy);
                        break;
                    case 'd':
                        Pxy = movement(4, Pxy);
                        break;
                    case 'S':
                        if (wallcount[floor] >= .6 && floor + 1 < tempname.Count && tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] != "^")
                        {
                            Console.Clear();
                            Console.WriteLine("Floor " + (floor + 1));
                            bob.UpdateWorld(tempname[floor], int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2)), Pname);
                            Console.WriteLine("Are you sure you want to place the stairs here?\n\"y\" or \"n\"");
                            if (Console.ReadKey().KeyChar == 'y' && tempname[floor + 1][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] == "I")
                            {
                                tempname[floor][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] = "v";
                                tempname[floor + 1][int.Parse(Pxy.Substring(0, 2)), int.Parse(Pxy.Substring(2, 2))] = "^";
                                Stairs[floor] = false;
                            }
                        }
                        break;
                    case 'i':
                        inv.invUI(invs);
                        break;
                    case 'l':
                        floor = tempname.Count + 1;
                        break;
                }
            }
            return tempname;
        }
        public string movement(int direction, string Exy)
        {
            int floor = floori;
            switch (direction)
            {
                case 1:
                    if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)) - 1, int.Parse(Exy.Substring(2, 2))] == "N")
                    {
                        break;
                    }
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)) - 1, int.Parse(Exy.Substring(2, 2))] != "B")
                    {
                        if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)) - 1, int.Parse(Exy.Substring(2, 2))] == "I")
                        {
                            wallcount[floor]++;
                        }
                        else
                        {

                        }
                        Exy = (int.Parse(Exy.Substring(0, 2)) - 1).ToString() + Exy.Substring(2, 2);
                    }
                    if (Exy.Length == 3)
                        Exy = "0" + Exy.Substring(0, 2) + (Exy.Substring(2, 1));
                    break;
                case 2:
                    if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) - 1] == "N")
                    {
                        break;
                    }
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) - 1] != "B")
                    {
                        if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) - 1] == "I")
                        {
                            wallcount[floor]++;
                        }
                        else
                        {

                        }
                        Exy = Exy.Substring(0, 2) + (int.Parse(Exy.Substring(2, 2)) - 1).ToString();
                    }
                    if (Exy.Length == 3)
                        Exy = Exy.Substring(0, 2) + "0" + (Exy.Substring(2, 1));
                    break;
                case 3:
                    if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)) + 1, int.Parse(Exy.Substring(2, 2))] == "N")
                    {
                        break;
                    }
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)) + 1, int.Parse(Exy.Substring(2, 2))] != "B")
                    {
                        if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)) + 1, int.Parse(Exy.Substring(2, 2))] == "I")
                        {
                            wallcount[floor]++;
                        }
                        else
                        {

                        }
                        Exy = (int.Parse(Exy.Substring(0, 2)) + 1).ToString() + Exy.Substring(2, 2);
                    }
                    if (Exy.Length == 3)
                        Exy = "0" + Exy.Substring(0, 2) + (Exy.Substring(2, 1));
                    break;
                case 4:
                    if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) + 1] == "N")
                    {
                        break;
                    }
                    if (tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) + 1] != "B")
                    {
                        if (Pxy == Exy && tempname[floor][int.Parse(Exy.Substring(0, 2)), int.Parse(Exy.Substring(2, 2)) + 1] == "I")
                        {
                            wallcount[floor]++;
                        }
                        else
                        {

                        }
                        Exy = Exy.Substring(0, 2) + (int.Parse(Exy.Substring(2, 2)) + 1).ToString();
                    }
                    if (Exy.Length == 3)
                        Exy = Exy.Substring(0, 2) + "0" + (Exy.Substring(2, 1));
                    break;
            }
            return Exy;
        }
    }
}
/*
    Mob moving Ai
 Random rand = new Random();
 List<string> Mxy = new List<Mxy>();
 for (int i = 0; i < Mxy.Count; i++)
 {
     int chance = rand.Next(1, 101);
     int eAi = rand.Next(1, 5);
 
      if (chance <= 25) // probability of 25%
      {
            //mob moves
            Mxy[i] = movement(eAi, Mxy[i]);
      }
      else
      {
            //mob stays
      }
  }
 */