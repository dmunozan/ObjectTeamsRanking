﻿using System;

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

            for (int i = 0; teamList != null && i < numberOfTeams; i++)
            {
                this.teams[i] = new Team(teamList[i, 0], Convert.ToInt32(teamList[i, 1]));
            }
        }

        public string[,] GetClasification()
        {
            return null;
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
