using System;

namespace TrainSimulationApp
{
    public class Station
    {
        public string Name { get; set; }
        public List<Platform> Platforms { get; set; }

        public Station(string name, int numberOfPlatforms)
        {
            this.Name = name;
            Platforms = new List<Platform>();

            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                Platforms.Add(new Platform(i));
            }
        }
    }
}