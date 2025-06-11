using System;

namespace TrainSimulationApp
{
    public class FreightTrain : Train
    {
        public int MaxWeight { get; set; }
        public string? FreightType { get; set; }

        public FreightTrain(string ID, int ArrivalTime, string Type, int maxWeight, string freightType) : base(ID, ArrivalTime, Type)
        {
            MaxWeight = maxWeight;
            FreightType = freightType;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"  -Max weight: {MaxWeight} tons");
            Console.WriteLine($"  -Freight type: {FreightType}");
            Console.WriteLine("---------------------------------");
        }
    }
}
