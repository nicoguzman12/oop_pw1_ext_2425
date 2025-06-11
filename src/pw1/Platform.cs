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

        public void AssignTrainToPlatform(Train train)
        {
            CurrentTrain = train;
            IsOccupied = true;
        }
    }

}