using System;
using System.Timers;

namespace Game_Of_Life
{
    public class Program
    {
        public static void Main()
        {
            var board = new GameBoard();
            board.FillBoard();
        }

        private static void PlayWithTimer(GameBoard board)
        {
            var timer = GetTimer();
            timer.Elapsed += board.NextGeneration;

            Console.WriteLine("Press Enter to end");
            Console.Read();
        }
        /**
         * Interval in ms
         */
        private static Timer GetTimer(int interval = 5000)
        {
            return
                new()
                {
                    Interval = interval,
                    AutoReset = true,
                    Enabled = true
                };
        }

    }
}