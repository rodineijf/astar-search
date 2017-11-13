using System;
using System.Collections.Generic;
using System.Linq;

namespace AStarSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var arad = new City("Arad", 366);
            var zerind = new City("Zerind", 374);
            var oradea = new City("Oradea", 380);
            var sibiu = new City("Sibiu", 253);
            var fagaras = new City("Fagaras", 178);
            var rimnicu = new City("Rimnicu Vilcea", 193);
            var pitesti = new City("Pitesti", 98);
            var timisoara = new City("Timisoara", 329);
            var lugoj = new City("Lugoj", 244);
            var mehadia = new City("Mehadia", 241);
            var drobeta = new City("Drobeta", 242);
            var craiova = new City("Craiova", 160);
            var bucharest = new City("Bucharest", 0);
            var giurgiu = new City("Giurgiu", 77);

            arad.Neighbors = new List<Neighbor>
            {
                new Neighbor(zerind, 75),
                new Neighbor(sibiu, 140),
                new Neighbor(timisoara, 118)
            };

            zerind.Neighbors = new List<Neighbor>
            {
                new Neighbor(arad, 75),
                new Neighbor(oradea, 71)
            };


            oradea.Neighbors = new List<Neighbor>
            {
                new Neighbor(zerind, 71),
                new Neighbor(sibiu, 151)
            };

            sibiu.Neighbors = new List<Neighbor>
            {
                new Neighbor(arad, 140),
                new Neighbor(fagaras, 99),
                new Neighbor(oradea, 151),
                new Neighbor(rimnicu, 80),
            };


            fagaras.Neighbors = new List<Neighbor>
            {
                new Neighbor(sibiu, 99),
                new Neighbor(bucharest, 211)
            };

            rimnicu.Neighbors = new List<Neighbor>
            {
                new Neighbor(sibiu, 80),
                new Neighbor(pitesti, 97),
                new Neighbor(craiova, 146)
            };

            pitesti.Neighbors = new List<Neighbor>
            {
                new Neighbor(rimnicu, 97),
                new Neighbor(bucharest, 101),
                new Neighbor(craiova, 138)
            };

            timisoara.Neighbors = new List<Neighbor>
            {
                new Neighbor(arad, 118),
                new Neighbor(lugoj, 111)
            };

            lugoj.Neighbors = new List<Neighbor>
            {
                new Neighbor(timisoara, 111),
                new Neighbor(mehadia, 70)
            };

            mehadia.Neighbors = new List<Neighbor>
            {
                new Neighbor(lugoj, 70),
                new Neighbor(drobeta, 75)
            };

            drobeta.Neighbors = new List<Neighbor>
            {
                new Neighbor(mehadia, 75),
                new Neighbor(craiova, 120)
            };

            craiova.Neighbors = new List<Neighbor>
            {
                new Neighbor(drobeta, 120),
                new Neighbor(rimnicu, 146),
                new Neighbor(pitesti, 138)
            };

            bucharest.Neighbors = new List<Neighbor>
            {
                new Neighbor(pitesti, 101),
                new Neighbor(giurgiu, 90),
                new Neighbor(fagaras, 211)
            };

            giurgiu.Neighbors = new List<Neighbor>
            {
                new Neighbor(bucharest, 90)
            };

            AStarSearch(bucharest, arad);
        }

        public static void AStarSearch(City startCity, City goalCity)
        {
            Console.WriteLine("Iniciando busca de " + startCity.Name + " até " + goalCity.Name);

            var openSet = new List<City>();
            var closedSet = new List<City>();
            startCity.GScore = 0;

            openSet.Add(startCity);

            while (openSet.Any())
            {
                var current = openSet.OrderBy(x => x.FScore).First();

                if (current.Name == goalCity.Name)
                {
                    var city = current;

                    while (city != null)
                    {
                        Console.WriteLine(city.Name + " gScore " + city.GScore);
                        city = city.Parent;
                    }
                    Console.ReadKey();
                    return;
                }

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var neighbor in current.Neighbors)
                {
                    if (closedSet.Contains(neighbor.City)) continue;

                    if (openSet.Contains(neighbor.City))
                    {
                        var gScore = current.GScore + neighbor.Cost;
                        var fScore = gScore + neighbor.City.Heuristic;

                        if (neighbor.City.FScore > fScore)
                        {
                            neighbor.City.GScore = gScore;
                            neighbor.City.FScore = fScore;
                            neighbor.City.Parent = current;
                        }
                    }
                    else
                    {
                        neighbor.City.GScore = current.GScore + neighbor.Cost;
                        neighbor.City.FScore = neighbor.City.GScore + neighbor.City.Heuristic;
                        neighbor.City.Parent = current;
                        openSet.Add(neighbor.City);
                    }
                }
            }
        }
    }
}