using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class GameMachine : BaseGame
    {   
        public enum Selection { Cheat = 0, COoperate = 1, FirstSelection = 4 };
        protected readonly int iterations;

        private Player playerOne;
        private Player playerTwo;
        public GameMachine(int _iterations, Player _playerOne, Player _playerTwo)
        {
            this.iterations = _iterations;
            playerOne = _playerOne;
            playerTwo = _playerTwo;
        }


        public override void RunMachine()
        {
            int _iterator = 1;
            while (_iterator <= this.iterations)
            {
                _iterator++;

                // accepts selections
                Selection p1Selection = playerOne.GamePlay();                
                Selection p2Selection = playerTwo.GamePlay();

                // let other to peek opponent selection              
                playerOne.playerMemory.Add(p2Selection);
                playerTwo.playerMemory.Add(p1Selection);

                this.calculateScore(p1Selection, p2Selection);
            }

        }

        protected void calculateScore(Selection p1Selection, Selection p2Selection)
        {
            // both are in some cooperation 
            if (p1Selection == p2Selection)
            {                
                P1Score += forLikeSelection(p1Selection);
                P2Score += forLikeSelection(p1Selection);
                return;
            }
            // some one cheating
            if (p1Selection != p2Selection)
            {
                P1Score += forOddSelection(p1Selection);
                P2Score += forOddSelection(p2Selection);
                return;
            }
        }

        private int forOddSelection(Selection playerSelection)
        {
            return playerSelection == Selection.Cheat ? 3 : -1;
        }

        private int forLikeSelection(Selection playerSelection)
        {
            return playerSelection == (int)Selection.Cheat ? 0 : 2;
        }


    }
}
