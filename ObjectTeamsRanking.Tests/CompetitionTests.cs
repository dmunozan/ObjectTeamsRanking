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

    }
}
