using System;

namespace ObjectTeamsRanking
{
    class Program
    {
        static void Main()
        {
            Competition teamsCompetition = new Competition(14);
            teamsCompetition.BubbleSort();
            teamsCompetition.Print();
            Console.Read();
        }
    }
}
