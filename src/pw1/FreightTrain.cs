using System;

namespace TrainSimulationApp
{

    class PassengerTrain : Train
    {
        public int NumberofCarriages { get; set; }
        public int Capacity { get; set; }

        public PassengerTrain(string ID, int ArrivalTime, string Type, int NumberofCarriages, int Capacity) : base(ID, ArrivalTime, Type) //base allows reuse and extend the class functionality
        {
            this.NumberofCarriages = NumberofCarriages;
            this.Capacity = Capacity;
        }

        public override void DisplayInfo() //it does not take arguments because it directly uses the internal properties
        {
            base.DisplayInfo();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"  -Number of Carriages: {NumberofCarriages}");
            Console.WriteLine($"  -Capacity: {Capacity} passengers");
            Console.WriteLine("---------------------------------");
        }
    }

}