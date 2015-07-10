using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayingWithThreadpool
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program p = new Program();
            for (int i = 0; i < 10; i++)
            {
                int threadNumber = i;
                System.Threading.ThreadPool.QueueUserWorkItem(
                    new System.Threading.WaitCallback((threadNum) => {
                        for (int j = 0; j < 10; j++)
                        {
                            Console.ForegroundColor = p.getCommandLineColor((int)threadNum);
                            Console.WriteLine("thread id: {1}, number: {0}", j, (int)threadNum);
                        }
                    }), threadNumber);
            }
            Console.ReadLine();
        }

        private ConsoleColor getCommandLineColor(int i)
        {
            ConsoleColor color;
            int f = (i % 10) +1;
            color = (ConsoleColor) f;
            return color;
        }
    }
}
