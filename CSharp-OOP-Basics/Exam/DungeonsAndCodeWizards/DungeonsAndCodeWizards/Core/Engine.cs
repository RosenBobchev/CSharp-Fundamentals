using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            while (!dungeonMaster.IsGameOver())
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                var commandInput = input.Split();
                this.ProcessCommand(commandInput);
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }

        private void ProcessCommand(string[] commandInput)
        {
            var command = commandInput[0];

            var args = commandInput.Skip(1).ToArray();
            try
            {
                switch (command)
                {
                    case "JoinParty":
                        Console.WriteLine(this.dungeonMaster.JoinParty(args));
                        break;
                    case "AddItemToPool":
                        Console.WriteLine(this.dungeonMaster.AddItemToPool(args));
                        break;
                    case "PickUpItem":
                        Console.WriteLine(this.dungeonMaster.PickUpItem(args));
                        break;
                    case "UseItem":
                        Console.WriteLine(this.dungeonMaster.UseItem(args));
                        break;
                    case "UseItemOn":
                        Console.WriteLine(this.dungeonMaster.UseItemOn(args));
                        break;
                    case "GiveCharacterItem":
                        Console.WriteLine(this.dungeonMaster.GiveCharacterItem(args));
                        break;
                    case "GetStats":
                        Console.WriteLine(this.dungeonMaster.GetStats());
                        break;
                    case "Attack":
                        Console.WriteLine(this.dungeonMaster.Attack(args));
                        break;
                    case "Heal":
                        Console.WriteLine(this.dungeonMaster.Heal(args));
                        break;
                    case "EndTurn":
                        Console.WriteLine(this.dungeonMaster.EndTurn(args));
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType().Name == "ArgumentException")
                {
                    Console.WriteLine($"Parameter Error: {ex.Message}");
                }
                else if (ex.GetType().Name == "InvalidOperationException")
                {
                    Console.WriteLine($"Invalid Operation: {ex.Message}");
                }
            }
        }
    }
}
