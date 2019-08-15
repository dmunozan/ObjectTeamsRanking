using System;

namespace ObjectTeamsRanking
{
    public class Team
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
            if (that == null)
            {
                throw new ArgumentNullException(nameof(that));
            }

            return this.points < that.points;
        }

        public string[] GetTeamDetails()
        {
            return new[] { name, points.ToString() };
        }
    }
}
