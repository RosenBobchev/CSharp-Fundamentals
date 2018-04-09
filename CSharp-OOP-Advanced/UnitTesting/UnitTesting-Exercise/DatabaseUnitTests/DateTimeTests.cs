using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class DateTimeTests
{
    private IDatetime sut;

    [SetUp]
    public void TestInit()
    {
        this.sut = new MyDateTime();
    }

    [Test]
    public void NowShouldReturnCurrentDate()
    {
        var expectedValue = DateTime.Now.Date;
        
        Assert.AreEqual(expectedValue, this.sut.Now().Date);
    }

    [Test]
    public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
    {
        var testDate = new DateTime(2000, 10, 31);
        var expectedDate = new DateTime(2000, 11, 1);
        
        testDate = testDate.AddDays(1);
        
        Assert.AreEqual(expectedDate, testDate);
    }
}