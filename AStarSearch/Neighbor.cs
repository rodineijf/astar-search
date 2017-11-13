using System;
using System.Collections.Generic;
using System.Text;

namespace AStarSearch
{
    public class Neighbor
    {
        public readonly int Cost;
        public readonly City City;

        public Neighbor(City city, int cost)
        {
            Cost = cost;
            City = city;
        }
    }
}
