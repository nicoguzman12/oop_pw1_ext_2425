using System;

namespace TrainSimulationApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to UFV train station");

            int numberOfPlatforms;

            while (true) //infinite loop until it find a break
            {
                Console.Write("Enter the number of platforms: ");
                if (int.TryParse(Console.ReadLine(), out numberOfPlatforms) && numberOfPlatforms > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number. Please enter a valid positive integer.");
                }          
            }
        }
    }
}