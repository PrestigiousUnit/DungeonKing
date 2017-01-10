using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int world = 0;
            List<Game> files = new List<Game>();
            List<string> UName = new List<string>();
            for (int i = 0; i < 1;)
            {
                Console.Clear();
                Console.WriteLine("Menu!\n1: New Game\n2: Load Game\n3: Close Program");
                ConsoleKeyInfo choice = Console.ReadKey();
                switch (choice.KeyChar)
                {
                    case '1':
                        for (int o = 0; o < 1;)
                        {
                            Console.Clear();
                            Console.WriteLine("What would you like your name to be?");
                            UName.Add(Console.ReadLine());
                            o++;
                            if (UName[world] == "")
                            {
                                o--;
                                UName.Remove("");
                            }
                        }
                        files.Add(new Game(UName[world]));
                        files[world].UI();
                        world++;
                        break;
                    case '2':
                        if (!files.Any())
                        {
                            Console.Clear();
                            Console.WriteLine("You dont have any games started");
                            Delay();
                            break;
                        }
                        while (i < 1)
                        {
                            if (files.Count < 2)
                            {
                                files[0].UI();
                                i++;
                            }
                            else
                            {
                                Console.Clear();
                                for (int o = 0; o < world; o++)
                                    Console.WriteLine((o + 1) + ": " + UName[o]);
                                ConsoleKeyInfo temp = Console.ReadKey();
                                if (IsDigitsOnly(temp.KeyChar.ToString()) == true && int.Parse(temp.KeyChar.ToString()) <= files.Count)
                                {
                                    files[int.Parse(temp.KeyChar.ToString()) - 1].UI();
                                    i++;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("That is an invalid option");
                                    Delay();
                                }
                            }
                        }
                        i = 0;
                        break;
                    case '3':
                        i = 1;
                        break;
                } 
            }
        }
        static void Delay()
        {
            //5 second delay
            for(int c = 1 ; c <= 32767; c++ )
                for (int d = 1; d <= 32767; d++)
                { }
        }
        static bool IsDigitsOnly(string couldit)
        {
            foreach (char c in couldit)
            {
                if (c < '1' || c > '9')
                    return false;
            }
            return true;
        }
    }
}