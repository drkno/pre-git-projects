using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Game
    {
        public static int CurrentGameState;
        public static void Init()
        {
            CurrentGameState = 0;
        }

        public static void UpdateGameState()
        {
            switch (CurrentGameState)
            {
                case 0:
                {
                    Display.Write("Searching For Player 2");
                    break;
                }
                case 1:
                case 2:
                default:
                    break;
            }
        }

        public static bool[] GetCurrentGameState()
        {
            return null;
        }
    }
}
