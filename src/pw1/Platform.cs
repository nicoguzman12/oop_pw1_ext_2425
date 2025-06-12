using System;

namespace TrainSimulationApp
{
    public class Platform
    {
        public int PlatformNumber { get; }
        public Train? CurrentTrain { get; private set; }
        public int DockingTicksRemaining { get; set; }

        public bool IsOccupied => CurrentTrain != null;

        public Platform(int platformNumber)
        {
            PlatformNumber = platformNumber;
            CurrentTrain = null;
            DockingTicksRemaining = 0;
        }

        public bool AssignTrainToPlatform(Train train)
        {
            if (IsOccupied)
            {
                Console.WriteLine($"Platform {PlatformNumber} is already occupied.");
                return false;
            }

            CurrentTrain = train;
            return true;
        }

        public void ReleasePlatform()
        {
            CurrentTrain = null;
            DockingTicksRemaining = 0;
        }

        public override string ToString()
        {
            if (IsOccupied && CurrentTrain != null)
            {
                return $"Platform {PlatformNumber}: Occupied by {CurrentTrain.ID}, " +
                       $"ticks left: {DockingTicksRemaining}";
            }
            else
            {
                return $"Platform {PlatformNumber}: Free";
            }
        }
    }
}
