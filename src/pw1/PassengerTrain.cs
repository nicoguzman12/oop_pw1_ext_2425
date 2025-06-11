using System;

namespace TrainSimulationApp
{
    class FreightTrain : Train
    {
        public int MaxWeight { get; set; }
        public string? FreightType { get; set; }
    }

}