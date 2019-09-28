using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class GameMachine : BaseGame
    {   
        public enum selection { Cheat = 0, COoperate = 1, CopyCat = 3 };
        protected readonly int iterations;

        protected Player playerOne;
        protected Player playerTwo;
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
                selection p1Selection = playerOne.GamePlay();                
                selection p2Selection = playerTwo.GamePlay();

                // let other to peek opponent selection
                playerOne.setOppenentSelection(p2Selection, _iterator);
                playerTwo.setOppenentSelection(p1Selection, _iterator);

                this.calculateScore(p1Selection, p2Selection);
            }

        }

        protected void calculateScore(selection p1Selection, selection p2Selection)
        {
            // both are in some cooperation 
            if (p1Selection == p2Selection)
            {                
                P1Score += forOddSelection(p1Selection);
                P2Score += forLikeSelection(p1Selection);
                return;
            }
            // some one cheating
            if (p1Selection != p2Selection)
            {
                P1Score += forOddSelection(p1Selection);
                P2Score += forLikeSelection(p2Selection);
                return;
            }
        }

        private int forOddSelection(selection playerSelection)
        {
            return playerSelection == selection.Cheat ? 3 : -1;
        }

        private int forLikeSelection(selection playerSelection)
        {
            return playerSelection == (int)selection.Cheat ? 0 : 2;
        }


    }
}
