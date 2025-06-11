using System;

namespace TrainSimulationApp
{
    abstract class Train
    {
        string ID { get; set; }
        int ArrivalTime { get; set; }
        string Type { get; set; }
        public TrainStatus Status { get; set; }
    }

    
}