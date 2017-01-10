using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class World
    {
        public World()
        {

        }
        public string[,] WorldGeneration()
        {
            /* O: Outside the Border
             * I: Inside the Border
             * B: Border
             * R: Room
             * ^: Stairs Up
             * v: Stairs Down
             * N: NPC
             */
            string[,] world = new string[20, 20]
            {
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","B","B","B","B","B","B","B","B","B","B","B","B","B","B","B","B","O","O"},
                { "O","O","B","I","B","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O"},
                { "O","O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O"},
                { "O","O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O"},
                { "O","O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O"},
                { "O","O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O"},
                { "O","O","B","I","I","I","I","I","I","I","I","I","I","I","I","I","I","B","O","O"},
                { "O","O","B","B","B","B","B","B","B","B","B","B","B","B","B","B","B","B","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"},
                { "O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O","O"}
            };
            return world;
        }
        public int UpdateWorld(string[,] world, int Py, int Px, string Name)
        {
            int NumOfI = 0;
            for (int row = 0; row < world.GetLength(0); row++)
            {
                for (int col = 0; col < world.GetLength(1); col++)
                {
                    string temp = world[row, col];
                    if (temp == "I")
                        NumOfI++;
                    if ((temp == "I" || temp == "B") && (world[row + 1, col] == "R" || world[row - 1, col] == "R" || world[row, col + 1] == "R" || world[row, col - 1] == "R" ||
                                                         world[row + 1, col] == "^" || world[row - 1, col] == "^" || world[row, col + 1] == "^" || world[row, col - 1] == "^" ||
                                                         world[row + 1, col] == "v" || world[row - 1, col] == "v" || world[row, col + 1] == "v" || world[row, col - 1] == "v"))
                    {
                        if (temp == "I")
                            temp = "+";
                        else
                            temp = "X";
                    }
                    else if (temp == "O" || temp == "R" || temp == "I" || temp == "B")
                        temp = " ";
                    if (row == Py && col == Px)
                        temp = Name.Substring(0, 1);
                    Console.Write(String.Format("{0} ", temp));
                }
                Console.WriteLine();
            }
            return NumOfI;
        }
        public string RandomLocation(string[,] world)
        {
            Random thing = new Random();
            string Pxy = "";
            int Px, Py;
            Px = 0; Py = 0;
            while (Pxy.Length < 4)
            {
                int temp = thing.Next(1, 19);
                if (temp < 10)
                    Pxy += "0" + temp;
                else
                    Pxy += temp;
                if (Pxy.Length > 3)
                {
                    Px = int.Parse(Pxy.Substring(0, 2));
                    Py = int.Parse(Pxy.Substring(2, 2));
                }
                int check = 2;
                if ((Pxy.Length == 4 && (world[(Px + 1), Py] == "B" ^ world[(Px - 1), Py] == "B" ^ world[Px, (Py + 1)] == "B" ^ world[Px, (Py - 1)] == "B" == false)) ||
                   ((Pxy.Length == 4 && (world[(Px + 1), Py] == "O" || world[(Px - 1), Py] == "O" || world[Px, (Py + 1)] == "O" || world[Px, (Py - 1)] == "O"))))
                { Pxy = ""; check--; }
                if (check == 2 && Pxy.Length == 4)
                {
                    if (world[(Px + 1), Py] == "B")
                        world[(Px + 1), Py] = "N";
                    if (world[(Px - 1), Py] == "B")
                        world[(Px - 1), Py] = "N";
                    if (world[Px, (Py + 1)] == "B")
                        world[Px, (Py + 1)] = "N";
                    if (world[Px, (Py - 1)] == "B")
                        world[Px, (Py - 1)] = "N";
                }
            }
            return Pxy;
        }
    }
}