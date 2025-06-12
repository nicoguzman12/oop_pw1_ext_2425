using System;
using System.Collections.Generic;

namespace TrainSimulationApp
{
    public class Station
    {
        public string Name { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Train> Trains { get; set; }

        public Station(string name, int numberOfPlatforms)
        {
            this.Name = name;
            Platforms = new List<Platform>();
            Trains = new List<Train>();

            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                Platforms.Add(new Platform(i));
            }
        }
        public void LoadTrains(List<Train> trainsFromFile)
        {
            foreach (var train in trainsFromFile)
            {
                Trains.Add(train);
            }
        }

        public bool AssignTrainToPlatform(Train train)
        {
            foreach (var platform in Platforms)
            {
                if (!platform.IsOccupied)
                {
                    platform.AssignTrainToPlatform(train);
                    train.Status = TrainStatus.Docking;
                    return true;
                }
            }
            return false;
        }

        public void AdvanceTick()
        {

            foreach (var train in Trains)    //reduce arrival time 
            {
                train.AdvanceTick();
            }

            foreach (var train in Trains.Where(t => t.Status == TrainStatus.OnRoute && t.ArrivalTime == 0)) //try to assign
                {
                    bool ok = AssignTrainToPlatform(train);
                    if (!ok) train.Status = TrainStatus.Waiting;
                }
            foreach (var platform in Platforms.Where(p => p.IsOccupied)) //manage docking in platforms
            {
                if (platform.DockingTicksRemaining > 0)
                {
                    platform.DockingTicksRemaining--;
                    platform.CurrentTrain!.Status = TrainStatus.Docking;
                    if (platform.DockingTicksRemaining == 0)
                        platform.CurrentTrain.Status = TrainStatus.Docked;
                }
            }
        }

        public void ReleaseArrivedTrains()
        {
            foreach (var platform in Platforms)
            {
                if (platform.IsOccupied && platform.CurrentTrain != null)
                {
                    Train train = platform.CurrentTrain;

                    if (train.ArrivalTime == 0 && (train.Status == TrainStatus.Docking || train.Status == TrainStatus.Docked))
                    {
                        train.Status = TrainStatus.Docked;
                        platform.ReleasePlatform();
                    }
                }
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine("\n---- Trains ----");
            foreach (var t in Trains)
                t.DisplayInfo();

            Console.WriteLine("\n---- Platforms ----");
            foreach (var p in Platforms)
            {
                if (p.IsOccupied)
                    Console.WriteLine($"Platform {p.PlatformNumber}: Occupied by {p.CurrentTrain!.ID}, Docking ticks left {p.DockingTicksRemaining}");
                else
                    Console.WriteLine($"Platform {p.PlatformNumber}: Free");
            }
        }

        public void StartSimulation()
        {
            int tick = 0;

            Console.WriteLine("\n------Simulation started------");

            foreach (var train in Trains)
            {
                train.Status = TrainStatus.OnRoute;
            }

            while (Trains.Any(t => t.Status != TrainStatus.Docked))
            {
                Console.WriteLine($"\n>>> Tick {tick}");

                AdvanceTick();
                ReleaseArrivedTrains();
                DisplayStatus();

                Console.WriteLine("Press Enter to continue to the next tick...");
                Console.ReadLine();
                tick++;
            }

            Console.WriteLine(" --------------------------------------");
            Console.WriteLine("\n ----All trains have been docked-----");
            Console.WriteLine("\n --------SIMULATION COMPLETED--------");
            Console.WriteLine(" --------------------------------------");
        }
    }
}