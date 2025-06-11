using System;
using System.IO;

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

            Station station = new Station("UFV Station", numberOfPlatforms);

            while (true)
            {
                Console.WriteLine("\n------- MENU ---------");
                Console.WriteLine("1. Load trains from file");
                Console.WriteLine("2. Start simulation");
                Console.WriteLine("3. Display system state");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-----------------------\n");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
                {
                    Console.WriteLine("Invalid option chosen, please select one from the menu.");
                }
                else
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Loading trains from data/Trains.csv");
                            string filePath = Path.Combine("data", "Trains.csv");
                            if (filePath != null)
                            {
                                var trains = ReadTrainsFromCsv(filePath);
                                station.LoadTrains(trains);
                                Console.WriteLine("Trains were loaded succesfully!!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid File Path");
                            }
                            break;

                        case "2":
                            if (station.Trains.Count == 0)
                            {
                                Console.WriteLine("No trains loaded. Please load a CSV file first.");
                            }
                            else
                            {
                                station.StartSimulation();
                            }
                            break;

                        case "3":
                            station.DisplayPlatformStatus();
                            break;

                        case "4":
                            Console.WriteLine("Exiting the program...");
                            return;

                    }
                }
            }

        }

        public static List<Train> ReadTrainsFromCsv(string filePath)
        {
            var trains = new List<Train>();

            try
            {
                var lines = File.ReadAllLines(filePath);

                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');

                    if (parts.Length < 5) //evaluating if the are 5 columns
                    {
                        continue;
                    }

                    string id = parts[0];
                    int arrivalTime = int.Parse(parts[1]);
                    string type = parts[2];

                    if (type.ToLower() == "passenger")
                    {
                        int numberOfCarriages = int.Parse(parts[3]);
                        int capacity = int.Parse(parts[4]);
                        trains.Add(new PassengerTrain(id, arrivalTime, type, numberOfCarriages, capacity));
                    }
                    else if (type.ToLower() == "freight")
                    {
                        int maxWeight = int.Parse(parts[3]);
                        string freightType = parts[4];
                        trains.Add(new FreightTrain(id, arrivalTime, type, maxWeight, freightType));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred reading CSV: " + ex.Message);
            }

            return trains;
        }
    }
}