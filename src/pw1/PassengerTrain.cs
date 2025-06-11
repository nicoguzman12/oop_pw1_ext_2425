using System;

namespace TrainSimulationApp
{
    class FreightTrain : Train
    {
        public int MaxWeight { get; set; }
        public string? FreightType { get; set; }
    }
    public FreightTrain(string ID, int ArrivalTime, string Type, int maxWeight, string freightType): base(ID, ArrivalTime, Type)
    {
        MaxWeight = maxWeight;
        FreightType = freightType;
    }
    public override void DisplayInfo() //it does not take arguments because it directly uses the internal properties
    {
        base.DisplayInfo();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"  -Max weight: {MaxWeight} tons");
        Console.WriteLine($"  -Freight type: {FreightType}");
        Console.WriteLine("---------------------------------");
    }
}