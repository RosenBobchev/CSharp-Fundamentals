using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForBullet = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(bulletsInput);
            var locks = new Queue<int>(locksInput);
            int bulletsUsed = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();
                
                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                bulletsUsed++;

                if (bulletsUsed % gunBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            int moneyEarned = value - (bulletsUsed * priceForBullet);

            if (locks.Count > 0)
            {
                int locksCount = locks.Count;
                Console.WriteLine($"Couldn't get through. Locks left: {locksCount}");
            }
            else
            {
                int bulletsCount = bullets.Count;
                Console.WriteLine($"{bulletsCount} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
