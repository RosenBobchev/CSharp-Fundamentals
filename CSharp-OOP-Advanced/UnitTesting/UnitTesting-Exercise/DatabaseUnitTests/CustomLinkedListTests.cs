using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class CustomLinkedListTests
{
    private DynamicList<int> sut;

    [SetUp]
    public void TestInit()
    {
        this.sut = new DynamicList<int>();
    }

    [Test]
    public void CannotCallElementWithNegativeIndex()
    {
        var incorrectIndex = -1;
        
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var test = this.sut[incorrectIndex];
        }
        , "Provided index is less than zero");
    }

    [Test]
    public void CannotCallElementWithIndexAboveTheRange()
    {
        var incorrectIndex = 1;
        
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var test = this.sut[incorrectIndex];
        }
        , "Provided index is greater than the range of the collection");
    }

    [Test]
    public void AddShouldIncreaseCollectionCount()
    {
        this.sut.Add(1);
        
        Assert.AreEqual(1, this.sut.Count, "Adding an element doesn't affect the collection's count");
    }

    [Test]
    [TestCase(1, 0)]
    [TestCase(5, 3)]
    [TestCase(10, 8)]
    [TestCase(15, 14)]
    public void AddShouldSaveTheElementInTheCollection(int numberOfAdditions, int indexToCheck)
    {
        this.AddElements(numberOfAdditions);
        
        Assert.AreEqual(indexToCheck, this.sut[indexToCheck], "Element is not the same as the one added");
    }

    [Test]
    [TestCase(-1)]
    [TestCase(1)]
    [TestCase(-5)]
    [TestCase(5)]
    public void RemoveAtIndexOusideTheBoundariesOfTheCollectionIsImpossible(int indexToRemove)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.sut.RemoveAt(indexToRemove));
    }

    [Test]
    [TestCase(3, 1)]
    [TestCase(10, 5)]
    [TestCase(10, 0)]
    [TestCase(10, 8)]
    public void RemoveAtShouldRemoveTheElementAtTheGivenIndex(int numberOfAdditions, int indexToRemove)
    {
        this.AddElements(numberOfAdditions);
        
        this.sut.RemoveAt(indexToRemove);
        
        Assert.AreEqual(indexToRemove + 1, sut[indexToRemove]);
    }

    [Test]
    [TestCase(3, 1)]
    [TestCase(5, 4)]
    [TestCase(10, 7)]
    public void IndexOfShouldReturnTheIndexPointingAtTheCurrentLocationOfTheElement(int numberOfAdditions, int keyElement)
    {
        this.AddElements(numberOfAdditions);
        var expectedIndex = keyElement;
        
        var foundIndex = this.sut.IndexOf(keyElement);
        
        Assert.AreEqual(expectedIndex, foundIndex, "Returned index is not correct");
    }

    [Test]
    [TestCase(3, 3)]
    [TestCase(5, -1)]
    [TestCase(10, 15)]
    public void IndexOfShouldReturnNegativeIntegerIfTheGivenElementDoesNotExists(int numberOfAdditions, int keyElement)
    {
        this.AddElements(numberOfAdditions);
        
        var isReturnedValueLessThanZero = this.sut.IndexOf(keyElement) < 0;
        
        Assert.IsTrue(isReturnedValueLessThanZero, "Returned index is not negative");
    }

    [Test]
    [TestCase(3, 1)]
    [TestCase(10, 5)]
    [TestCase(10, 0)]
    [TestCase(10, 8)]
    [TestCase(10, 9)]
    public void RemoveShouldDeleteParticularElement(int numberOfAdditions, int elementToRemove)
    {
        this.AddElements(numberOfAdditions);
        
        this.sut.Remove(elementToRemove);
        
        Assert.AreEqual(-1, this.sut.IndexOf(elementToRemove), "Removed element is still in the collection");
    }

    [Test]
    [TestCase(3, 3)]
    [TestCase(3, -1)]
    [TestCase(3, 10)]
    public void RemoveUnexistentEelementShouldReturnNegativeInteger(int numberOfAdditions, int elementToRemove)
    {
        this.AddElements(numberOfAdditions);
        
        var isRemovingResultLesThanZero = this.sut.Remove(elementToRemove) < 0;
        
        Assert.IsTrue(isRemovingResultLesThanZero, "Attempting to remove an unexistent element returns positive integer");
    }

    [Test]
    [TestCase(3, 1)]
    [TestCase(5, 4)]
    [TestCase(10, 7)]
    public void RemoveShouldReturnTheIndexOfTheRemovedElement(int numberOfAdditions, int elementToRemove)
    {
        this.AddElements(numberOfAdditions);
        var expectedIndex = elementToRemove;
        
        var returnedIndex = this.sut.Remove(elementToRemove);
        
        Assert.AreEqual(expectedIndex, returnedIndex, "Remove returns wrong index");
    }

    [Test]
    [TestCase(3, 1)]
    [TestCase(5, 4)]
    [TestCase(10, 7)]
    public void ContainsShouldReturnTrueIfElementExists(int numberOfAdditions, int keyElement)
    {
        this.AddElements(numberOfAdditions);
        
        Assert.IsTrue(this.sut.Contains(keyElement), "Contains returns false for existing element");
    }

    [Test]
    [TestCase(3, 3)]
    [TestCase(5, 10)]
    [TestCase(10, 15)]
    public void ContainsShouldReturnfalseIfElementDoesNotExists(int numberOfAdditions, int keyElement)
    {
        this.AddElements(numberOfAdditions);
        
        Assert.IsFalse(this.sut.Contains(keyElement), "Contains returns true for element which doesn't exists");
    }

    private void AddElements(int numberOfAdditions)
    {
        for (int i = 0; i < numberOfAdditions; i++)
        {
            this.sut.Add(i);
        }
    }
}