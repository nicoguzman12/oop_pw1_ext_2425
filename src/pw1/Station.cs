using System;
using System.Collections.Generic;

namespace TrainSimulationApp
{
    public class Station
    {

        public List<Platform> Platforms { get; set; }
        public List<Train> Trains { get; set; }

        public Station(int numberOfPlatforms)
        {

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
                    platform.DockingTicksRemaining = 2;
                    return true;
                }
            }
            train.Status = TrainStatus.Waiting;
            return false;
        }

        public void AdvanceTick()
        {
           
            foreach (var train in Trains)  //advance arrival time of trains
            {
                if (train.Status == TrainStatus.OnRoute)
                    train.AdvanceTick();
            }

            foreach (var train in Trains) //try to assign at income
            {
                if (train.Status == TrainStatus.OnRoute && train.ArrivalTime == 0)
                {
                    bool assigned = AssignTrainToPlatform(train);
                    if (!assigned)
                        train.Status = TrainStatus.Waiting;
                }
            }

            foreach (var platform in Platforms) //Manage docking in platforms
            {
                if (platform.IsOccupied && platform.DockingTicksRemaining > 0)
                {
                    platform.DockingTicksRemaining--;

                    if (platform.DockingTicksRemaining == 0 && platform.CurrentTrain != null)
                    {
                        platform.CurrentTrain.Status = TrainStatus.Docked;
                        platform.ReleasePlatform();
                    }
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
            Console.WriteLine("\n--- Simulation Start ---");
            int tick = 0;
            bool allDocked;

            do
            {
                Console.WriteLine($"\n --> Tick {tick}");
                AdvanceTick();
                DisplayStatus();

                allDocked = true;

                foreach (var train in Trains)
                {
                    if (train.Status != TrainStatus.Docked)
                    {
                        allDocked = false;
                        break;
                    }
                }

                if (!allDocked)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }

                tick++;

            } while (!allDocked);

            Console.WriteLine("\n--- Simulation Completed: All trains docked ---");
        }
    }
}