using System;

namespace ObjectTeamsRanking
{
    public class Competition
    {
        private Team[] teams;

        public Competition(string[,] teamList)
        {
            const int InitialnumberOfTeams = 0;

            this.teams = new Team[InitialnumberOfTeams];

            this.AddTeam(teamList);
        }

        public void AddTeam(string[,] teamList)
        {
            const int TeamName = 0;
            const int TeamPoints = 1;

            if (teamList == null || teamList.Length == 0)
            {
                return;
            }

            int numberOfTeamsToAdd = teamList.GetLength(0);
            int numberOfNotRepeatedTeams = 0;
            int currentNumberOfTeams = this.teams.Length;

            Team[] newTeams = new Team[numberOfTeamsToAdd];

            for (int i = 0; i < numberOfTeamsToAdd; i++)
            {
                bool isOnTheList = false;
                for (int j = 0; !isOnTheList && j < currentNumberOfTeams; j++)
                {
                    isOnTheList = this.teams[j].GetTeamDetails()[TeamName] == teamList[i, TeamName];
                }

                if (!isOnTheList)
                {
                    newTeams[i] = new Team(teamList[i, TeamName], Convert.ToInt32(teamList[i, TeamPoints]));
                    numberOfNotRepeatedTeams++;
                }
            }

            Team[] totalTeams = new Team[currentNumberOfTeams + numberOfNotRepeatedTeams];

            this.teams.CopyTo(totalTeams, 0);
            Array.Copy(newTeams, 0, totalTeams, currentNumberOfTeams, numberOfNotRepeatedTeams);

            this.teams = totalTeams;

            BubbleSort();
        }

        public string[,] GetClasification()
        {
            const int TeamName = 0;
            const int TeamPoints = 1;
            const int DetailsPerTeam = 2;
            if (this.teams.Length == 0)
            {
                return null;
            }

            string[,] clasification = new string[this.teams.Length, DetailsPerTeam];

            for (int i = 0; i < this.teams.Length; i++)
            {
                string[] teamDetails = this.teams[i].GetTeamDetails();
                clasification[i, TeamName] = teamDetails[TeamName];
                clasification[i, TeamPoints] = teamDetails[TeamPoints];
            }

            return clasification;
        }

        public override bool Equals(object obj)
        {
            Competition other = obj as Competition;

            if (other == null || this.teams.Length != other.teams.Length)
            {
                return false;
            }

            for (int i = 0; i < this.teams.Length; i++)
            {
                if (this.teams[i].GetTeamDetails()[0] != other.teams[i].GetTeamDetails()[0] ||
                    this.teams[i].GetTeamDetails()[1] != other.teams[i].GetTeamDetails()[1])
                {
                    return false;
                }
            }

            return true;
        }

        public void AddMatch(string[,] matchList)
        {
            const int TeamName = 0;
            const int TeamPoints = 1;

            if (matchList == null || matchList.Length == 0)
            {
                return;
            }

            int numberOfMatchesToAdd = matchList.GetLength(0);
            int currentNumberOfTeams = this.teams.Length;

            for (int i = 0; i < numberOfMatchesToAdd; i++)
            {
                for (int j = 0; j < currentNumberOfTeams; j++)
                {
                    string[] teamDetails = this.teams[j].GetTeamDetails();
                    if (teamDetails[TeamName] == matchList[i, TeamName])
                    {
                        int currentPoints = Convert.ToInt32(teamDetails[TeamPoints]);
                        int matchPoints = Convert.ToInt32(matchList[i, TeamPoints]);
                        this.teams[j] = new Team(teamDetails[TeamName], currentPoints + matchPoints);
                    }
                }
            }

            BubbleSort();
        }

        private void BubbleSort()
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
    }
}
