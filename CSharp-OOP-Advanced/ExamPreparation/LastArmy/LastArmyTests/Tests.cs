using NUnit.Framework;
using System;

namespace LastArmyTests
{
    public class Tests
    {
        private MissionController sut;
        private IArmy army;
        private IWareHouse wareHouse;

        [SetUp]
        public void TestInit()
        {
            this.army = new Army();
            this.wareHouse = new WareHouse();

            this.sut = new MissionController(army, wareHouse);
        }

        [Test]
        public void CorrectMissionCount()
        {
            this.sut.PerformMission(new Easy(50));

            Assert.AreEqual(1, sut.Missions.Count);
        }

        [Test]
        public void MissionWithoutNeededSoldiersCount()
        {
            var mission = new Hard(20);

            var message = this.sut.PerformMission(mission).Trim();

            Assert.AreEqual($"Mission on hold - {mission.Name}", message);
        }

        [Test]
        public void PerformExactlyThreeMissions()
        {
            var firstMission = new Hard(20);
            var secondMission = new Hard(20);
            var thirdMission = new Hard(20);
            var fourthMission = new Hard(20);

            this.sut.PerformMission(firstMission);
            this.sut.PerformMission(secondMission);
            this.sut.PerformMission(thirdMission);
            this.sut.PerformMission(fourthMission);

            Assert.AreEqual(3, this.sut.Missions.Count);
        }

        [Test]
        public void PerformCorrectMission()
        {
            var mission = new Easy(20);

            this.wareHouse.AddAmmunitions("Gun", 10);
            this.wareHouse.AddAmmunitions("AutomaticMachine", 10);
            this.wareHouse.AddAmmunitions("Helmet", 10);

            var soldier = new Ranker("Soldier", 30, 50, 50);
            this.army.AddSoldier(soldier);
            this.wareHouse.EquipArmy(this.army);

            var message = this.sut.PerformMission(mission).Trim();

            Assert.AreEqual($"Mission completed - {mission.Name}", message);
        }

        [Test]
        public void SuccessfulIncreasingMissionCounter()
        {
            var mission = new Easy(20);
            
            this.wareHouse.AddAmmunitions("Gun", 10);
            this.wareHouse.AddAmmunitions("AutomaticMachine", 10);
            this.wareHouse.AddAmmunitions("Helmet", 10);

            var soldier = new Ranker("Soldier", 30, 50, 50);
            this.army.AddSoldier(soldier);
            this.wareHouse.EquipArmy(this.army);

            var message = this.sut.PerformMission(mission).Trim();

            Assert.AreEqual(1, this.sut.SuccessMissionCounter);
        }

        [Test]
        public void MissionDeclining()
        {
            var mission = new Hard(20);
            this.sut.PerformMission(mission).Trim();
            this.sut.PerformMission(mission).Trim();
            this.sut.PerformMission(mission).Trim();

            var message = this.sut.PerformMission(mission).Trim();

            Assert.IsTrue(message.StartsWith($"Mission declined - {mission.Name}"));
        }

        [Test]
        public void FailedMissionsCounter()
        {
            var mission = new Hard(20);
            this.sut.PerformMission(mission).Trim();

            this.sut.FailMissionsOnHold();

            Assert.AreEqual(1, this.sut.FailedMissionCounter);
        }

        [Test]
        public void FailedMissionIfCounterIsZero()
        {
            this.sut.PerformMission(new Easy(0));

            Assert.AreEqual(0, this.sut.FailedMissionCounter);
        }

        [Test]
        public void FailIfThereIsMoreThanThreeMissions()
        {
            this.sut.Missions.Enqueue(new Easy(0));
            this.sut.Missions.Enqueue(new Easy(0));
            this.sut.Missions.Enqueue(new Easy(0));

            this.sut.PerformMission(new Easy(0));

            Assert.AreEqual(1, this.sut.FailedMissionCounter);
        }
    }
}
