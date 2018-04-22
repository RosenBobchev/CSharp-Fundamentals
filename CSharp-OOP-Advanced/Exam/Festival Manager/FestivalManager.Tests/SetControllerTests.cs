// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    [TestFixture]
    public class SetControllerTests
    {
        // [Test]
        // public void Test()
        // {
        //     //setcount and songcount to test and weardown and can perform?
        // }

        [Test]
        public void CorrectLength()
        {
            Stage stage = new Stage();
            Guitar guitar = new Guitar();
            Set set = new Long("Long");
            Song song = new Song("Song", new TimeSpan(0, 1, 0));
            Performer performer = new Performer("Gosho", 21);
            stage.AddPerformer(performer);
            stage.AddSet(set);
            stage.AddSong(song);
            
            SetController setController = new SetController(stage);
            
            Assert.That(setController.PerformSets().Length, Is.EqualTo(28));
        }

        [Test]
        public void Test()
        {
            Stage stage = new Stage();
            Guitar guitar = new Guitar();
            Set set = new Long("Long");
            Song song = new Song("Song", new TimeSpan(0, 1, 0));
            Performer performer = new Performer("Gosho", 21);
            stage.AddPerformer(performer);
            performer.AddInstrument(guitar);
            stage.AddSet(set);
            stage.AddSong(song);

            SetController setController = new SetController(stage);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Long:");
            sb.AppendLine("-- Did not perform");
            Assert.That(setController.PerformSets(), Is.EqualTo(sb.ToString().Trim()));
        }

        [Test]
        public void SecondTest()
        {
            Stage stage = new Stage();
            Guitar guitar = new Guitar();
            Set set = new Long("Long");
            Song song = new Song("Song", new TimeSpan(0, 1, 0));
            Performer performer = new Performer("Gosho", 21);
            stage.AddSet(set);
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);
            performer.AddInstrument(guitar);
            SetController setController = new SetController(stage);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1. Long:");
            sb.AppendLine("-- 1. Song (01:00)");
            sb.AppendLine("-- Set Successful");
            Assert.That(setController.PerformSets(), Is.EqualTo(sb.ToString().Trim()));
        }

        [Test]
        public void PerformSets_CanPerform_InstrumentWearsDown()
        {
            Stage stage = new Stage();
            Set set = new Long("short");
            set.AddSong(new Song("s2", new TimeSpan(0, 1, 0)));
            Performer performer = new Performer("pesho", 100);
            Instrument instrument = new Drums();

            performer.AddInstrument(instrument);
            set.AddPerformer(performer);
            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            setController.PerformSets();

            double actualResult = instrument.Wear;
            double expectedResult = 80;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
