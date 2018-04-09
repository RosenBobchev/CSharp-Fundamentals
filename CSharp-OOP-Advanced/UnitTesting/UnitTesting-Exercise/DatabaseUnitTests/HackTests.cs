using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class HackTests
{
    public Mock<Hack> mockMatchClass;

    [SetUp]
    public void Create_Mock_Math_Object()
    {

        mockMatchClass = new Mock<Hack>();

    }

    [TestCase(-5.55)]
    [TestCase(66.11)]
    public void Get_The_Abs_Value(double num)
    {
        Hack absClass = mockMatchClass.Object;


        int someAbsResult = absClass.ReturnAbsValue(num);
        int fixedAbsValue = (int)Math.Abs(num);

        Assert.That(someAbsResult == fixedAbsValue);
    }

    [TestCase(4.55)]
    [TestCase(99.12)]
    public void Get_The_Floor_Value(double num)
    {
        Hack floorValuesClass = mockMatchClass.Object;

        int someFloorResult = floorValuesClass.ReturnAbsValue(num);
        int fixedFloorValue = (int)Math.Floor(num);

        Assert.That(someFloorResult == fixedFloorValue);
    }
}