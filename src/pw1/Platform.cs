using System;

namespace TrainSimulationApp
{
    public class Platform()
    {
        public int PlatformNumber { get; set; }
        public bool IsOccupied { get; set; }
        public Train? CurrentTrain { get; set; }
    }


}