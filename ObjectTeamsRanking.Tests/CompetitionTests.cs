using System;
using Xunit;

namespace ObjectTeamsRanking.Tests
{
    public class CompetitionTests
    {
        [Fact]
        public void GetClasificationWhenNoTeamsShouldReturnNull()
        {
            Competition initialCompetition = new Competition(null);

            Assert.Null(initialCompetition.GetClasification());
        }

        [Fact]
        public void EqualsWhenCompetitionsAreEqualShouldReturnTrue()
        {
            string[,] teamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(teamList);
            Competition competitionToCompare = new Competition(teamList);

            Assert.True(initialCompetition.Equals(competitionToCompare));
        }
    }
}
