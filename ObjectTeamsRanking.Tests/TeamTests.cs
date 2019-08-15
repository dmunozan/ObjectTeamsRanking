using System;
using Xunit;

namespace ObjectTeamsRanking.Tests
{
    public class TeamTests
    {
        [Fact]
        public void HasLessPointsWhenTeam1HasLessPointsThanTeam2ShouldReturnTrue()
        {
            Team team1 = new Team("Team 1", 12);
            Team team2 = new Team("Team 2", 24);

            Assert.True(team1.HasLessPoints(team2));
        }

        [Fact]
        public void HasLessPointsWhenTeam1HasMorePointsThanTeam2ShouldReturnFalse()
        {
            Team team1 = new Team("Team 1", 24);
            Team team2 = new Team("Team 2", 12);

            Assert.False(team1.HasLessPoints(team2));
        }

        [Fact]
        public void HasLessPointsWhenTeam1HasTheSamePointsThanTeam2ShouldReturnFalse()
        {
            Team team1 = new Team("Team 1", 12);
            Team team2 = new Team("Team 2", 12);

            Assert.False(team1.HasLessPoints(team2));
        }

        [Fact]
        public void GetTeamDetailsWhenTeam1And12PointsShouldReturnArrayWithDetails()
        {
            Team team1 = new Team("Team 1", 12);

            Assert.Equal(new[] { "Team 1", "12" }, team1.GetTeamDetails());
        }
    }
}
