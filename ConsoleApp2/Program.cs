using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please Enter Iterations");
            string value = Console.ReadLine();
            BaseGame game1 = new GameMachine(Int32.Parse(value), new HumanPlayer("Human"), new HumanPlayer("Human"));
            BaseGame game2 = new GameMachine(Int32.Parse(value), new HumanPlayer("Human"), new KindBot("KindBot"));
            BaseGame game3 = new GameMachine(Int32.Parse(value), new HumanPlayer("Human"), new EvilBot("EvilBot"));

           
            BaseGame game4 = new GameMachine(Int32.Parse(value), new KindBot("KindBot"), new GruderBot("GruderBot"));
            PressStartForFriendly(game4);  // friendly
            PressStart(); // tournament
           
        }

        private static void PressStart()
        {
         

            List<Player> listOfPlayers = new List<Player>();
            listOfPlayers.Add(new  KindBot("KindBot"));
            listOfPlayers.Add(new EvilBot("EvilBot"));
            listOfPlayers.Add(new GruderBot("GrudgerBot"));
            listOfPlayers.Add(new CopyCatBot("CopyCatBot"));

            Tournament tournament = new Tournament(listOfPlayers);
            tournament.BeginTournament();
            tournament.PrintSummary();
        }


        private static void PressStartForFriendly(BaseGame game)
        {

        }

    }
}
