using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> party;
        private Stack<Item> itemsPool;
        private ItemFactory itemFactory;
        private CharacterFactory characterFactory;
        private int lastSurvivorRound;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemsPool = new Stack<Item>();
            this.itemFactory = new ItemFactory();
            this.characterFactory = new CharacterFactory();
            this.lastSurvivorRound = 0;
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = null;
            character = characterFactory.CreateCharacter(faction, characterType, name);

            party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            var item = itemFactory.CreateItem(itemName);

            this.itemsPool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = FindCharacter(characterName);

            var anyItemsLeft = this.itemsPool.Any();

            if (!anyItemsLeft)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.itemsPool.Pop();

            character.ReceiveItem(item);
            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = FindCharacter(characterName);

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.FindCharacter(giverName);
            var receiver = this.FindCharacter(receiverName);

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);
            return $"{giver.Name} used {itemName} on {receiver.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.FindCharacter(giverName);
            var receiver = this.FindCharacter(receiverName);

            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);
            return $"{giver.Name} gave {receiver.Name} {itemName}.";
        }

        public string GetStats()
        {
            var sortedParty = party.OrderByDescending(p => p.IsAlive).ThenByDescending(p => p.Health);
            StringBuilder sb = new StringBuilder();
            foreach (var character in sortedParty)
            {
                if (character.IsAlive == false)
                {
                    sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Dead");
                }
                else
                {
                    sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Alive");
                }
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var attackReceiverName = args[1];

            var attacker = this.FindCharacter(attackerName);
            var receiver = this.FindCharacter(attackReceiverName);

            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attackingCharacter.Attack(receiver);

            var result =
                $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = this.FindCharacter(healerName);
            var receiver = this.FindCharacter(healingReceiverName);

            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            healingCharacter.Heal(receiver);

            var result =
                $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = this.party.Where(c => c.IsAlive == true).ToList();
            StringBuilder sb = new StringBuilder();

            if (aliveCharacters.Count <= 1)
            {
                this.lastSurvivorRound++;
            }
            foreach (var character in aliveCharacters)
            {
                var oldHp = character.Health;
                character.Rest();
                var newHp = character.Health;
                sb.AppendLine($"{character.Name} rests ({oldHp} => {newHp})");

            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (this.lastSurvivorRound > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Character FindCharacter(string name)
        {
            var character = this.party.FirstOrDefault(e => e.Name == name);

            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return character;
        }
    }
}
