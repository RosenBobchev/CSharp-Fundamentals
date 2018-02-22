using System;
using System.Collections.Generic;

public class Program
{
    private static Dictionary<string, Team> teams = new Dictionary<string, Team>();
    private const string TEAM_DOES_NOT_EXIST = "Team {0} does not exist.";

    public static void Main()
    {
        var input = string.Empty;

        while ((input = Console.ReadLine())!= "END")
        {
            var tokens = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var command = tokens[0];
            var teamName = tokens[1];

            try
            {
                switch (command)
                {
                    case "Team":
                        CreateNewTeam(teamName);
                        break;

                    case "Add":
                        AddNewPlayerToTeam(teamName, tokens);
                        break;

                    case "Remove":
                        var playerName = tokens[2];
                        RemovePlayerFromTeam(teamName, playerName);
                        break;

                    case "Rating":
                        ShowRating(teamName);
                        break;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }

    private static void CheckIfTeamExists(string teamName)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new InvalidOperationException(string.Format(TEAM_DOES_NOT_EXIST, teamName));
        }
    }

    private static void ShowRating(string teamName)
    {
        CheckIfTeamExists(teamName);

        var team = teams[teamName];
        Console.WriteLine(team);
    }

    private static void RemovePlayerFromTeam(string teamName, string playerName)
    {
        CheckIfTeamExists(teamName);

        teams[teamName].RemovePlayer(playerName);
    }

    private static void AddNewPlayerToTeam(string teamName, string[] tokens)
    {
        CheckIfTeamExists(teamName);
        Player newPlayer = CreateNewPlayer(tokens);

        teams[teamName].AddPlayer(newPlayer);
    }

    private static Player CreateNewPlayer(string[] tokens)
    {
        return new Player
                                        (tokens[2],
                        new Stats("Endurance", int.Parse(tokens[3])),
                        new Stats("Sprint", int.Parse(tokens[4])),
                        new Stats("Dribble", int.Parse(tokens[5])),
                        new Stats("Passing", int.Parse(tokens[6])),
                        new Stats("Shooting", int.Parse(tokens[7])));
    }

    private static void CreateNewTeam(string name)
    {
        Team newTeam = new Team(name);
        teams.Add(name, newTeam);
    }
}

