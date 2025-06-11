using System;

namespace TrainSimulationApp
{
    class FreightTrain : Train
    {
        public int MaxWeight { get; set; }
        public string? FreightType { get; set; }
    }
    public FreightTrain(string ID, int ArrivalTime, string Type, int maxWeight, string freightType)
            : base(ID, ArrivalTime, Type)
        {
            MaxWeight = maxWeight;
            FreightType = freightType;
        }
}