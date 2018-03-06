using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<ISoldier> soldiers = new List<ISoldier>();

        string input = "";
        while ((input = Console.ReadLine()) != "End")
        {
            string[] splitInput = input.Split();

            string soldierType = splitInput[0];
            int id = int.Parse(splitInput[1]);
            string firstName = splitInput[2];
            string lastNames = splitInput[3];
            decimal salary = decimal.Parse(splitInput[4]);

            ISoldier soldier = null;
            try
            {
                switch (splitInput[0])
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastNames, salary);
                        break;
                    case "Spy":
                        int codeNumber = (int)salary;
                        soldier = new Spy(id, firstName, lastNames, salary, codeNumber);
                        break;
                    case "LeutenantGeneral":
                        LeutenantGeneral leutenant = new LeutenantGeneral(id, firstName, lastNames, salary);
                        for (int i = 5; i < splitInput.Length; i++)
                        {
                            int privateId = int.Parse(splitInput[i]);
                            ISoldier @private = soldiers.First(x => x.Id == privateId);
                            leutenant.AddPrivate(@private);
                        }
                        soldier = leutenant;
                        break;
                    case "Engineer":
                        string engineerCorps = splitInput[5];
                        Engineer engineer = new Engineer(id, firstName, lastNames, salary, engineerCorps);

                        for (int i = 6; i < splitInput.Length; i++)
                        {
                            string partName = splitInput[i];
                            int hoursWorked = int.Parse(splitInput[++i]);
                            try
                            {
                                IRepair repair = new Repair(partName, hoursWorked);
                                engineer.AddRepairs(repair);
                            }
                            catch { }

                        }
                        soldier = engineer;
                        break;
                    case "Commando":
                        string commandoCorps = splitInput[5];
                        Commando commando = new Commando(id, firstName, lastNames, salary, commandoCorps);

                        for (int i = 6; i < splitInput.Length; i++)
                        {
                            string codeName = splitInput[i];
                            string missionState = splitInput[++i];
                            try
                            {
                                IMission mission = new Mission(codeName, missionState);
                                commando.AddMissions(mission);
                            }
                            catch { }
                        }
                        soldier = commando;
                        break;
                    default: throw new ArgumentException("Invalid soldier type!");
                }
                soldiers.Add(soldier);
            }
            catch { }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}

