using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Tournament 
    {
       
        private Dictionary<Player, int> Rounds = new Dictionary<Player, int>();
        private GameMachine gameEngine;
        private List<Player> PlayersOfTornament;

      
        public Tournament(List<Player> _players)
        {
            this.PlayersOfTornament = _players;
        }

        public void BeginTournament() {

            
            foreach (var firstPlayer in PlayersOfTornament)
            {
                foreach (var secondPlayer in PlayersOfTornament)
                {
                    if (firstPlayer == secondPlayer) continue;
                    this.gameEngine = new GameMachine(5, firstPlayer, secondPlayer);
                    this.gameEngine.RunMachine();

                    if (this.Rounds.ContainsKey(firstPlayer))
                    {
                        this.Rounds[firstPlayer] += this.gameEngine.P1Score;
                        continue;
                    }

                    if (this.Rounds.ContainsKey(secondPlayer))
                    {
                        this.Rounds[secondPlayer] += this.gameEngine.P2Score;
                        continue;
                    }

                    this.Rounds.Add(firstPlayer, this.gameEngine.P1Score);
                    this.Rounds.Add(secondPlayer, this.gameEngine.P2Score);
                }
            }         

        }    

        public void PrintSummary() {

            foreach (var score in this.Rounds)
            {
                Console.WriteLine($"{score.Key} Score ==> {score.Value}");
            }
        }
    

        
    }
}
