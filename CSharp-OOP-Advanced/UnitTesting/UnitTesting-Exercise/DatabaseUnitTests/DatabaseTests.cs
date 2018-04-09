using NUnit.Framework;
using System;

public class DatabaseTests
{
    private Database database;

    [SetUp]
    public void SetUpMethod()
    {
        this.database = new Database(1);
    }

    [Test]
    public void AddingNumberToArray()
    {
        database.Add(2);

        Assert.That(database.Count, Is.EqualTo(2));
    }

    [Test]
    public void ThrowingExceptionWhenTheArrayIsFull()
    {
        for (int i = 0; i < 15; i++)
        {
            database.Add(1);
        }

        Assert.That(() => database.Add(1),
            Throws.InvalidOperationException.With.Message.EqualTo("The Array Is Full!"));
    }

    [Test]
    public void RemovingElementFromArray()
    {
        database.Remove();

        Assert.That(database.Count, Is.EqualTo(0));
    }

    [Test]
    public void ThrowingExceptionWhenTheArrayIsEmpty()
    {
        database.Remove();

        Assert.That(() => database.Remove(),
            Throws.InvalidOperationException.With.Message.EqualTo("The Array Is Empty!"));
    }

    [Test]
    public void FetchTheArray()
    {
        database.Add(2);
        database.Add(3);

        Assert.That(() => database.Fetch(), Is.EquivalentTo(new[] { 1, 2, 3 }));
    }
}