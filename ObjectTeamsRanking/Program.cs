using System;

namespace ObjectTeamsRanking
{
    class Team
    {
        readonly string Name;
        readonly int Points;

        public Team(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public bool HasLessPoints(Team that)
        {
            return this.Points < that.Points;
        }

        public void PrintName()
        {
            Console.Write(this.Name);
        }

        public void PrintPoints()
        {
            Console.Write(this.Points);
        }
    }

    class Program
    {
        static void Main()
        {
            Competition teamsCompetition = new Competition("Liga I", "Fotbal", 14);
            teamsCompetition.BubbleSort();
            teamsCompetition.Print();
            Console.Read();
        }
    }

    class Competition
    {

        readonly string name;
        readonly string type;
        readonly Team[] teams;

        public Competition(string name, string type, int numberOfTeams)
        {
            this.name = name;
            this.type = type;
            this.teams = ReadTeams(numberOfTeams);
        }

        public void BubbleSort()
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    if (teams[i].HasLessPoints(teams[i + 1]))
                    {
                        Swap(i, i + 1);
                        isSorted = false;
                    }
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);
            const string message = "Swapping elements with indexes ({0}, {1}) and values (";
            Console.Write(string.Format(message, minIndex, maxIndex));
            teams[minIndex].PrintName();
            Console.Write(", ");
            teams[maxIndex].PrintName();
            Console.WriteLine(")");

            Team temp = teams[minIndex];
            teams[minIndex] = teams[maxIndex];
            teams[maxIndex] = temp;
        }

        private (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }

        public void Print()
        {
            for (int i = 0; i < teams.Length; i++)
            {
                teams[i].PrintName();
                Console.Write("- ");
                teams[i].PrintPoints();
                Console.WriteLine("");
            }
        }

        private Team[] ReadTeams(int numberOfTeams)
        {
            Team[] result = new Team[numberOfTeams];

            for (int i = 0; i < result.Length; i++)
            {
                string[] teamData = Console.ReadLine().Split('-');
                int points = Convert.ToInt32(teamData[1]) + Convert.ToInt32(teamData[2]);
                result[i] = new Team(teamData[0], points);
            }

            return result;
        }
    }
}
