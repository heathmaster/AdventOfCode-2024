using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        private static Random rng = new Random();

        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;

            try
            {
                //Generate a list
                List<int> teamA = GenerateList(10, 1, 20);

                //Check that the list is not empty and has at least 1 item in it
                if (teamA == null || teamA.Count < 1) { throw new ApplicationException("Generated list was not valid"); }

                List<int> teamB = GenerateList(10, 1, 20);

                //Check that the list is not empty and has at least 1 item in it
                if (teamB == null || teamB.Count < 1) { throw new ApplicationException("Generated list was not valid"); }

                //Check that the lists have the same number of items
                if (teamA.Count != teamB.Count) { throw new ApplicationException("The lists must have the same number of items"); }

                //Sort each list
                teamA.Sort();

                PrintList("Team A:", teamA);

                teamB.Sort();

                PrintList("Team B:", teamB);

                //Loop through List A and compare to the item in list B and add the distances to the new list

                List<int> distances = new List<int>();

                for (int i = 0; i < teamA.Count; i++)
                {
                    distances.Add(CalculateDistance(teamA, teamB, i));
                }

                PrintList("Distances:", distances);

                int totalDistance = distances.Sum();

                Console.WriteLine(string.Format("The total distance is {0}", totalDistance.ToString()));

                endTime = DateTime.Now;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                endTime = DateTime.Now;
            }


            Console.WriteLine(string.Format("Code finished. Time elapsed: {0} ms", endTime.Subtract(startTime).Milliseconds.ToString()));

            Console.ReadLine();
        }
        
        private static List<int> GenerateList(int size, int lowerBound, int upperBound)
        {
            List<int> locationIds = new List<int>();

            for (int i = 0; i < size; i++)
            {
                locationIds.Add (rng.Next(lowerBound, upperBound));

            }

            return locationIds;
        }

        private static int CalculateDistance(List<int> a, List<int> b, int index)
        {
            return Math.Abs(a[index] - b[index]);
        }

        private static void PrintList(string title, List<int> list)
        {
            Console.WriteLine(title);

            foreach (int n in list)
            {
                Console.WriteLine(n.ToString());
            }

            Console.WriteLine();
        }
    }
}
