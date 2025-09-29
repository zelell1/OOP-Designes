using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestsLab1
{
    [Fact]
    public void Test1()
    {
        var forceSection1 = new MagneticForcePath(
            sectionLength: new SectionLength(10000),
            forceOnTrain: new Force(100));
        var convSection2 = new ConventionalMagneticPath(sectionLength: new SectionLength(1000000));
        IReadOnlyList<ISection> sections = new List<ISection> { forceSection1, convSection2 };
        var train = new Train(
            massTrain: new Mass(10),
            passengerFlow: new PassengerFlow(5),
            timeAccuracy: new TimeAccuraccy(0.0001),
            maxForce: new Force(1000));
        var route = new Route(
            sections: sections,
            maxSpeed: new Speed(500));
        SimulateResult result = route.Simulate(train);
        Assert.True(result is SimulateResult.Succes);
        if (result is SimulateResult.Succes res)
        {
            Assert.Equal(2280.787, res.TimeValue.ValueT, 3);
        }
    }

    [Fact]
    public void Test2()
    {
        var forceSection1 = new MagneticForcePath(
            sectionLength: new SectionLength(10000),
            forceOnTrain: new Force(100));
        var convSection2 = new ConventionalMagneticPath(sectionLength: new SectionLength(1000000));
        IReadOnlyList<ISection> sections = new List<ISection> { forceSection1, convSection2 };
        var train = new Train(
            massTrain: new Mass(10),
            passengerFlow: new PassengerFlow(5),
            timeAccuracy: new TimeAccuraccy(0.0001),
            maxForce: new Force(1000));
        var route = new Route(
            sections: sections,
            maxSpeed: new Speed(400));
        SimulateResult result = route.Simulate(train);
        Assert.True(result is SimulateResult.Failure);
    }

    [Fact]
    public void Test3()
    {
        var forceSection1 = new MagneticForcePath(
            sectionLength: new SectionLength(10000),
            forceOnTrain: new Force(100));
        var convSection2 = new ConventionalMagneticPath(sectionLength: new SectionLength(1000));
        var stationSection3 = new Station(
            maxSpeed: new Speed(450),
            passengerCountIn: new PassengerCount(20),
            passengerCountOut: new PassengerCount(30));
        var convSection4 = new ConventionalMagneticPath(sectionLength: new SectionLength(10000));
        IReadOnlyList<ISection> sections = new List<ISection>
        {
            forceSection1, convSection2,  stationSection3, convSection4,
        };
        var train = new Train(
            massTrain: new Mass(10),
            passengerFlow: new PassengerFlow(10),
            timeAccuracy: new TimeAccuraccy(0.1),
            maxForce: new Force(1000));
        var route = new Route(
            sections: sections,
            maxSpeed: new Speed(480));
        SimulateResult result = route.Simulate(train);
        Assert.True(result is SimulateResult.Succes);
        if (result is SimulateResult.Succes res)
        {
            Assert.Equal(74.400, res.TimeValue.ValueT, 3);
        }
    }

    [Fact]
    public void Test4()
    {
        var forceSection1 = new MagneticForcePath(
            sectionLength: new SectionLength(10000),
            forceOnTrain: new Force(100));
        var stationSection2 = new Station(
            maxSpeed: new Speed(200),
            passengerCountIn: new PassengerCount(20),
            passengerCountOut: new PassengerCount(30));
        var convSection3 = new ConventionalMagneticPath(sectionLength: new SectionLength(1000));
        IReadOnlyList<ISection> sections = new List<ISection>
        {
            forceSection1, stationSection2, convSection3,
        };
        var train = new Train(
            massTrain: new Mass(10),
            passengerFlow: new PassengerFlow(10),
            timeAccuracy: new TimeAccuraccy(0.1),
            maxForce: new Force(1000));
        var route = new Route(
            sections: sections,
            maxSpeed: new Speed(480));
        SimulateResult result = route.Simulate(train);
        Assert.True(result is SimulateResult.Failure);
    }

    [Fact]
    public void Test5()
    {
        var forceSection1 = new MagneticForcePath(
            sectionLength: new SectionLength(10000),
            forceOnTrain: new Force(100));
        var convSection2 = new ConventionalMagneticPath(sectionLength: new SectionLength(1000));
        var stationSection3 = new Station(
            maxSpeed: new Speed(450),
            passengerCountIn: new PassengerCount(20),
            passengerCountOut: new PassengerCount(30));
        var convSection4 = new ConventionalMagneticPath(sectionLength: new SectionLength(10000));
        IReadOnlyList<ISection> sections = new List<ISection>
        {
            forceSection1, convSection2,  stationSection3, convSection4,
        };
        var train = new Train(
            massTrain: new Mass(10),
            passengerFlow: new PassengerFlow(10),
            timeAccuracy: new TimeAccuraccy(0.1),
            maxForce: new Force(1000));
        var route = new Route(
            sections: sections,
            maxSpeed: new Speed(440));
        SimulateResult result = route.Simulate(train);
        Assert.True(result is SimulateResult.Failure);
    }

    [Fact]
    public void Test6()
    {
        var forceSection1 = new MagneticForcePath(
            sectionLength: new SectionLength(400),
            forceOnTrain: new Force(1000));
        var convSection2 = new ConventionalMagneticPath(new SectionLength(1000));
        var forceSection3 = new MagneticForcePath(
            sectionLength: new SectionLength(110),
            forceOnTrain: new Force(-2000));
        var stationSection4 = new Station(
            maxSpeed: new Speed(200),
            passengerCountIn: new PassengerCount(25),
            passengerCountOut: new PassengerCount(15));
        var convSection5 = new ConventionalMagneticPath(new SectionLength(5000));
        var forceSection6 = new MagneticForcePath(
            sectionLength: new SectionLength(1700),
            forceOnTrain: new Force(1000));
        var convSection7 = new ConventionalMagneticPath(new SectionLength(10000));
        var forceSection8 = new MagneticForcePath(
            sectionLength: new SectionLength(400),
            forceOnTrain: new Force(-2000));
        IReadOnlyList<ISection> sections = new List<ISection>
        {
            forceSection1, convSection2, forceSection3, stationSection4,
            convSection5, forceSection6, convSection7, forceSection8,
        };
        var train = new Train(
            massTrain: new Mass(10),
            passengerFlow: new PassengerFlow(10),
            timeAccuracy: new TimeAccuraccy(0.001),
            maxForce: new Force(1000));
        var route = new Route(
            sections: sections,
            maxSpeed: new Speed(500));
        SimulateResult result = route.Simulate(train);
        Assert.True(result is SimulateResult.Succes);
        if (result is SimulateResult.Succes res)
        {
            Assert.Equal(58.49, res.TimeValue.ValueT, 2);
        }
    }

    [Fact]
    public void Test7()
    {
        var convSection1 = new ConventionalMagneticPath(sectionLength: new SectionLength(100));
        IReadOnlyList<ISection> sections = new List<ISection> { convSection1 };
        var train = new Train(
            massTrain: new Mass(10),
            passengerFlow: new PassengerFlow(5),
            timeAccuracy: new TimeAccuraccy(1),
            maxForce: new Force(1000));
        var route = new Route(
            sections: sections,
            maxSpeed: new Speed(500));
        SimulateResult result = route.Simulate(train);
        Assert.True(result is SimulateResult.Failure);
    }

    [Fact]
    public void Test8()
    {
        var forceSection1 = new MagneticForcePath(
            sectionLength: new SectionLength(10000),
            forceOnTrain: new Force(100));
        var forceSection2 = new MagneticForcePath(
            sectionLength: new SectionLength(10000),
            forceOnTrain: new Force(-200));
        IReadOnlyList<ISection> sections = new List<ISection> { forceSection1, forceSection2 };
        var train = new Train(
            massTrain: new Mass(10),
            passengerFlow: new PassengerFlow(5),
            timeAccuracy: new TimeAccuraccy(0.0001),
            maxForce: new Force(1000));
        var route = new Route(
            sections: sections,
            maxSpeed: new Speed(500));
        SimulateResult result = route.Simulate(train);
        Assert.True(result is SimulateResult.Failure);
    }
}