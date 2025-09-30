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
    public void CalculatePassageTime_WithForceAndConventionalRoute_ReturnsCorrectTime()
    {
        // Arrange
        var forceSection1 = new MagneticForcePath(
            new SectionLength(10000),
            new Force(100));

        var convSection2 = new ConventionalMagneticPath(new SectionLength(1000000));
        IReadOnlyList<ISection> sections = new List<ISection> { forceSection1, convSection2 };

        var train = new Train(
            new Mass(10),
            new PassengerFlow(5),
            new TimeAccuracy(0.0001),
            new Force(1000));

        var route = new Route(
            sections,
            new Speed(500));

        // Act
        SimulateResult result = route.Simulate(train);

        // Assert
        Assert.True(result is SimulateResult.Success);
        if (result is SimulateResult.Success res)
        {
            Assert.Equal(2280.787, res.TimeValue.Value, 3);
        }
    }

    [Fact]
    public void CalculatePassageTime_WhenTrainExceedsMaxRouteSpeed_ReturnsFailure()
    {
        // Arrange
        var forceSection1 = new MagneticForcePath(
            new SectionLength(10000),
            new Force(100));

        var convSection2 = new ConventionalMagneticPath(new SectionLength(1000000));
        IReadOnlyList<ISection> sections = new List<ISection> { forceSection1, convSection2 };

        var train = new Train(
            new Mass(10),
            new PassengerFlow(5),
            new TimeAccuracy(0.0001),
            new Force(1000));

        var route = new Route(
            sections,
            new Speed(400));

        // Act
        SimulateResult result = route.Simulate(train);

        // Assert
        Assert.True(result is SimulateResult.Failure);
    }

    [Fact]
    public void CalculatePassageTime_WhenSpeedIsWithinAllSpeedLimits_ReturnsCorrectTime()
    {
        // Arrange
        var forceSection1 = new MagneticForcePath(
            new SectionLength(10000),
            new Force(100));

        var convSection2 = new ConventionalMagneticPath(new SectionLength(1000));
        var stationSection3 = new Station(
            new Speed(450),
            new PassengerCount(20),
            new PassengerCount(30));

        var convSection4 = new ConventionalMagneticPath(new SectionLength(10000));

        IReadOnlyList<ISection> sections = new List<ISection>
        {
            forceSection1, convSection2, stationSection3, convSection4,
        };

        var train = new Train(
            new Mass(10),
            new PassengerFlow(10),
            new TimeAccuracy(0.1),
            new Force(1000));

        var route = new Route(
            sections,
            new Speed(480));

        // Act
        SimulateResult result = route.Simulate(train);

        // Assert
        Assert.True(result is SimulateResult.Success);
        if (result is SimulateResult.Success res)
        {
            Assert.Equal(74.400, res.TimeValue.Value, 3);
        }
    }

    [Fact]
    public void CalculatePassageTime_WhenTrainExceedsMaxStationSpeed_ReturnsFailure()
    {
        // Arrange
        var forceSection1 = new MagneticForcePath(
            new SectionLength(10000),
            new Force(100));

        var stationSection2 = new Station(
            new Speed(200),
            new PassengerCount(20),
            new PassengerCount(30));

        var convSection3 = new ConventionalMagneticPath(new SectionLength(1000));

        IReadOnlyList<ISection> sections = new List<ISection>
        {
            forceSection1, stationSection2, convSection3,
        };

        var train = new Train(
            new Mass(10),
            new PassengerFlow(10),
            new TimeAccuracy(0.1),
            new Force(1000));

        var route = new Route(
            sections,
            new Speed(480));

        // Act
        SimulateResult result = route.Simulate(train);

        // Assert
        Assert.True(result is SimulateResult.Failure);
    }

    [Fact]
    public void CalculatePassageTime_RouteSpeedLimitOverridesStationSpeedLimit_ReturnsFailure()
    {
        // Arrange
        var forceSection1 = new MagneticForcePath(
            new SectionLength(10000),
            new Force(100));

        var convSection2 = new ConventionalMagneticPath(new SectionLength(1000));

        var stationSection3 = new Station(
            new Speed(450),
            new PassengerCount(20),
            new PassengerCount(30));

        var convSection4 = new ConventionalMagneticPath(new SectionLength(10000));
        IReadOnlyList<ISection> sections = new List<ISection>
        {
            forceSection1, convSection2, stationSection3, convSection4,
        };

        var train = new Train(
            new Mass(10),
            new PassengerFlow(10),
            new TimeAccuracy(0.1),
            new Force(1000));

        var route = new Route(
            sections,
            new Speed(440));

        // Act
        SimulateResult result = route.Simulate(train);

        // Assert
        Assert.True(result is SimulateResult.Failure);
    }

    [Fact]
    public void CalculatePassageTime_WhenSpeedIsCorrectedByForceSections_ReturnsCorrectTime()
    {
        // Arrange
        var forceSection1 = new MagneticForcePath(
            new SectionLength(400),
            new Force(1000));

        var convSection2 = new ConventionalMagneticPath(new SectionLength(1000));

        var forceSection3 = new MagneticForcePath(
            new SectionLength(110),
            new Force(-2000));

        var stationSection4 = new Station(
            new Speed(200),
            new PassengerCount(25),
            new PassengerCount(15));

        var convSection5 = new ConventionalMagneticPath(new SectionLength(5000));

        var forceSection6 = new MagneticForcePath(
            new SectionLength(1700),
            new Force(1000));

        var convSection7 = new ConventionalMagneticPath(new SectionLength(10000));

        var forceSection8 = new MagneticForcePath(
            new SectionLength(400),
            new Force(-2000));

        IReadOnlyList<ISection> sections = new List<ISection>
        {
            forceSection1, convSection2, forceSection3, stationSection4,
            convSection5, forceSection6, convSection7, forceSection8,
        };

        var train = new Train(
            new Mass(10),
            new PassengerFlow(10),
            new TimeAccuracy(0.001),
            new Force(1000));

        var route = new Route(
            sections,
            new Speed(500));

        // Act
        SimulateResult result = route.Simulate(train);

        // Assert
        Assert.True(result is SimulateResult.Success);
        if (result is SimulateResult.Success res)
        {
            Assert.Equal(58.49, res.TimeValue.Value, 2);
        }
    }

    [Fact]
    public void CalculatePassageTime_WhenTrainDontHaveStartBoost_ReturnsFailure()
    {
        // Arrange
        var convSection1 = new ConventionalMagneticPath(new SectionLength(100));
        IReadOnlyList<ISection> sections = new List<ISection> { convSection1 };

        var train = new Train(
            new Mass(10),
            new PassengerFlow(5),
            new TimeAccuracy(1),
            new Force(1000));

        var route = new Route(
            sections,
            new Speed(500));

        // Act
        SimulateResult result = route.Simulate(train);

        // Assert
        Assert.True(result is SimulateResult.Failure);
    }

    [Fact]
    public void CalculatePassageTime_WhenTrainStops_ReturnsFailure()
    {
        // Arrange
        var forceSection1 = new MagneticForcePath(
            new SectionLength(10000),
            new Force(100));

        var forceSection2 = new MagneticForcePath(
            new SectionLength(10000),
            new Force(-200));

        IReadOnlyList<ISection> sections = new List<ISection> { forceSection1, forceSection2 };

        var train = new Train(
            new Mass(10),
            new PassengerFlow(5),
            new TimeAccuracy(0.0001),
            new Force(1000));

        var route = new Route(
            sections,
            new Speed(500));

        // Act
        SimulateResult result = route.Simulate(train);

        // Assert
        Assert.True(result is SimulateResult.Failure);
    }
}