using System;
using System.Collections.Generic;
using System.Text;

namespace AStarSearch
{
    public class City
    {
        public readonly string Name;
        public readonly int Heuristic;
        public IEnumerable<Neighbor> Neighbors { get; set; }
        public City Parent { get; set; }

        // Custo de chegada neste nó
        public int GScore { get; set; }
        public int FScore { get; set; }

        public City(string name, int heuristic)
        {
            Heuristic = heuristic;
            Name = name;
        }
    }
}
