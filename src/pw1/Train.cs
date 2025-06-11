using System;

namespace TrainSimulationApp
{
    abstract class Train
    {
        string ID { get; set; }
        int ArrivalTime { get; set; }
        string Type { get; set; }
        public TrainStatus Status { get; set; }
        public Train(string ID, int ArrivalTime, string Type)
        {
            this.ID = ID;
            this.ArrivalTime = ArrivalTime;
            this.Type = Type;
            this.Status = TrainStatus.OnRoute; //by logic I initialize it on the way to the station


        }
    }
}