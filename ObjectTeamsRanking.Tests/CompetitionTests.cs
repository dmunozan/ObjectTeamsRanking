using System;
using Xunit;

namespace ObjectTeamsRanking.Tests
{
    public class CompetitionTests
    {
        [Fact]
        public void AddTeamWhenNullShouldDoNothing()
        {
            string[,] teamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(teamList);
            initialCompetition.AddTeam(null);

            Assert.Equal(teamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void GetClasificationWhenNoTeamsShouldReturnNull()
        {
            Competition initialCompetition = new Competition(null);

            Assert.Null(initialCompetition.GetClasification());
        }

        [Fact]
        public void GetClasificationWhenTeamsShouldReturnCurrentClasification()
        {
            string[,] teamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(teamList);

            Assert.Equal(teamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void EqualsWhenCompetitionsAreEqualShouldReturnTrue()
        {
            string[,] teamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(teamList);
            Competition competitionToCompare = new Competition(teamList);

            Assert.True(initialCompetition.Equals(competitionToCompare));
        }

        [Fact]
        public void EqualsWhenCompetitionsAreNotEqualShouldReturnFalse()
        {
            string[,] initialteamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(initialteamList);
            string[,] teamListToCompare = { { "Team 1", "12" }, { "Team 2", "11" } };
            Competition competitionToCompare = new Competition(teamListToCompare);

            Assert.False(initialCompetition.Equals(competitionToCompare));
        }
    }
}
