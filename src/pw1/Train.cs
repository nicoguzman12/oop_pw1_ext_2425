using System;

namespace TrainSimulationApp
{
    abstract class Train
    {
        public string ID { get; set; }
        public int ArrivalTime { get; set; }
        public string Type { get; set; }
        public TrainStatus Status { get; set; }

        public Train(string ID, int ArrivalTime, string Type)
        {
            this.ID = ID;
            this.ArrivalTime = ArrivalTime;
            this.Type = Type;
            this.Status = TrainStatus.OnRoute; //by logic I initialize it on the way to the station
        }

        public virtual void AdvanceTick()
        {
            if (ArrivalTime >= 15)
            {
                ArrivalTime -= 15;
            }
            else
            {
                ArrivalTime = 0;
            }
        }

        public virtual void DisplayInfo(string ID, int ArrivalTime, string Type)
        {
            Console.WriteLine("------- Train Information -------");
            Console.WriteLine($"  -ID: {ID}");
            Console.WriteLine($"  -Type: {Type}");
            Console.WriteLine($"  -Remaining Arrival Time: {ArrivalTime} minutes");
            Console.WriteLine($"  -Status: {Status}");
            Console.WriteLine("---------------------------------");
        }
    }
}