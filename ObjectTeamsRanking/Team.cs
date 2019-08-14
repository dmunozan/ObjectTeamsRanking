using System;

namespace ObjectTeamsRanking
{
    class Team
    {
        private readonly string name;
        private readonly int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public bool HasLessPoints(Team that)
        {
            return this.points < that.points;
        }

        public void PrintName()
        {
            Console.Write(this.name);
        }

        public void PrintPoints()
        {
            Console.Write(this.points);
        }
    }
}
