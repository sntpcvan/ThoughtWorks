using System;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Please Enter Iterations");
            string value = Console.ReadLine();
            BaseGame game1 = new GameMachine(Int32.Parse(value), new HumanPlayer(), new HumanPlayer());
            BaseGame game2 = new GameMachine(Int32.Parse(value), new HumanPlayer(), new KindBot());
            BaseGame game3 = new GameMachine(Int32.Parse(value), new HumanPlayer(), new EvilBot());

           
            BaseGame game4 = new GameMachine(Int32.Parse(value), new HumanPlayer(), new CopyCatBot());
            game4.RunMachine();
            game4.PrintScore();
        }

    }
}
