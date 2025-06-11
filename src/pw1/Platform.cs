using System;

namespace TrainSimulationApp
{
    public class Platform
    {
        public int PlatformNumber { get; set; }
        public bool IsOccupied { get; set; }
        public Train? CurrentTrain { get; set; }


        public Platform(int platformNumber)
        {
            this.PlatformNumber = platformNumber;
            this.IsOccupied = false;
            this.CurrentTrain = null;
        }

        public bool AssignTrainToPlatform(Train train)
        {
            if (IsOccupied)
            {
                Console.WriteLine("Platform is actually occupied");
                return false;
            }
                CurrentTrain = train;
                IsOccupied = true;
                return true;
        }

        public void ReleasePlatform()
        {
            CurrentTrain = null;
            IsOccupied = false;
        }
    }

}