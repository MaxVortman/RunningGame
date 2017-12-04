using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RunningGame
{
    class Program
    {
        private const int Interval = 100;

        static void Main(string[] args)
        {
            var map = new Map();
            var timer = new Timer();
            timer.Interval = Interval;
            timer.Elapsed += (sender, e) =>
            {
                Console.Clear();
                map.Generate();
                Write(map.View);
            };
            timer.Enabled = true;
            Console.ReadKey();
        }

        private static void Write(char[,] view)
        {
            for (int i = 0; i < Map.Height; i++)
            {
                for (int j = 0; j < Map.Width; j++)
                {
                    Console.Write(view[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
