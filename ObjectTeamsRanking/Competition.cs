using System;

namespace ObjectTeamsRanking
{
    public class Competition
    {
        private readonly Team[] teams;

        public Competition(string[,] teamList)
        {
            int numberOfTeams = 0;
            if (teamList != null)
            {
                numberOfTeams = teamList.GetLength(0);
            }

            this.teams = new Team[numberOfTeams];
        }

        public string[,] GetClasification()
        {
            return null;
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
