using System;

namespace TrainSimulationApp
{

    class PassengerTrain : Train
    {
        public int NumberofCarriages { get; set; }
        public int Capacity { get; set; }

        public PassengerTrain(string ID, int ArrivalTime, string Type, int NumberofCarriages, int Capacity) : base(ID, ArrivalTime, Type)
        {
            this.NumberofCarriages = NumberofCarriages;
            this.Capacity = Capacity;
        }
    }

}