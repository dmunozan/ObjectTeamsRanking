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
        public void AddTeamWhenEmptyShouldDoNothing()
        {
            string[,] teamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(teamList);
            string[,] teamListToAdd = { { } };
            initialCompetition.AddTeam(teamListToAdd);

            Assert.Equal(teamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void AddTeamWhenTeamsShouldAddTeamsAndSortClasification()
        {
            string[,] finalTeamList = { { "Team 1", "12" }, { "Team 3", "11" }, { "Team 2", "10" } };
            string[,] initialTeamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(initialTeamList);
            string[,] teamListToAdd = { { "Team 3", "11" } };
            initialCompetition.AddTeam(teamListToAdd);

            Assert.Equal(finalTeamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void AddTeamWhenMoreThanOneTeamShouldAddTeamsAndSortClasification()
        {
            string[,] finalTeamList = { { "Team 1", "12" }, { "Team 3", "11" }, { "Team 2", "10" }, { "Team 4", "8" } };
            string[,] initialTeamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(initialTeamList);
            string[,] teamListToAdd = { { "Team 3", "11" }, { "Team 4", "8" } };
            initialCompetition.AddTeam(teamListToAdd);

            Assert.Equal(finalTeamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void AddTeamWhenTeamAlreadyExistsShouldIgnoreItAddTheOtherTeamsAndSortClasification()
        {
            string[,] finalTeamList = { { "Team 1", "12" }, { "Team 3", "11" }, { "Team 2", "10" } };
            string[,] initialTeamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(initialTeamList);
            string[,] teamListToAdd = { { "Team 3", "11" }, { "Team 2", "8" } };
            initialCompetition.AddTeam(teamListToAdd);

            Assert.Equal(finalTeamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void AddMatchWhenNullShouldDoNothing()
        {
            string[,] teamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(teamList);
            initialCompetition.AddMatch(null);

            Assert.Equal(teamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void AddMatchWhenEmptyShouldDoNothing()
        {
            string[,] teamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(teamList);
            string[,] matchList = { { } };
            initialCompetition.AddTeam(matchList);

            Assert.Equal(teamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void AddMatchWhenOneMatchShouldIncreaseTeamPointsAndSortClasification()
        {
            string[,] finalTeamList = { { "Team 2", "13" }, { "Team 1", "12" } };
            string[,] initialTeamList = { { "Team 1", "12" }, { "Team 2", "10" } };
            Competition initialCompetition = new Competition(initialTeamList);
            string[,] matchListToAdd = { { "Team 2", "3" } };
            initialCompetition.AddMatch(matchListToAdd);

            Assert.Equal(finalTeamList, initialCompetition.GetClasification());
        }

        [Fact]
        public void AddMatchWhenMoreThanOneMatchShouldIncreaseTeamsPointsAndSortClasification()
        {
            string[,] finalTeamList = { { "Team 3", "12" }, { "Team 1", "11" }, { "Team 2", "11" }, { "Team 4", "8" } };
            string[,] initialTeamList = { { "Team 1", "11" }, { "Team 2", "10" }, { "Team 3", "9" }, { "Team 4", "7" } };
            Competition initialCompetition = new Competition(initialTeamList);
            string[,] matchListToAdd = { { "Team 2", "1" }, { "Team 3", "3" }, { "Team 4", "1" } };
            initialCompetition.AddMatch(matchListToAdd);

            Assert.Equal(finalTeamList, initialCompetition.GetClasification());
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
