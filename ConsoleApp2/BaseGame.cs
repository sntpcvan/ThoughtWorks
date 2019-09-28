using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public abstract class BaseGame 
    {
        public int P1Score;
        public int P2Score;

        public abstract void RunMachine();
        public virtual void PrintScore() {
            Console.WriteLine($"Player 1 Score {this.P1Score}");
            Console.WriteLine($"Player 2 Score {this.P2Score}");
        }
    }
}
