using System;
using System.Collections.Generic;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Bags;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            bool switchMode = Enum.TryParse<Faction>(faction, out Faction currentFaction);

            if (switchMode)
            {
                switch (characterType)
                {
                    case "Warrior":
                        return new Warrior(name, currentFaction);
                    case "Cleric":
                        return new Cleric(name, currentFaction);
                    default:
                        throw new ArgumentException($"Invalid character type \"{characterType}\"!");
                }
            }
            else
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }
        }
    }
}
