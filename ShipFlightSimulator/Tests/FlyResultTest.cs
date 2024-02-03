using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;
using ShipFlightSimulator.Environments.Entities;
using ShipFlightSimulator.Environments.Models.Obstacles;
using ShipFlightSimulator.Route;
using ShipFlightSimulator.Route.Result;
using ShipFlightSimulator.Ships.Entities;
using ShipFlightSimulator.Ships.Models.Deflectors;
using ShipFlightSimulator.Ships.Models.Engines;
using ShipFlightSimulator.Ships.Models.HullStrengthClasses;
using Xunit;

namespace Tests;

public class FlyResultTest
{
    [Theory]
    [InlineData(350)]
    public void CheckFlyResult_ShouldReturnImpossibleFly_WhenWalkingShipInNebulaeIncreasedDensitySpace(
        int distance)
    {
        // Arrange
        var nebulaeIncreasedDensityOfSpace = new NebulaeIncreasedDensityOfSpace(
            new ReadOnlyCollection<INebulaeIncreasedDensitySpaceObstacle>(new List<INebulaeIncreasedDensitySpaceObstacle>()), distance);
        var walkingShip = new WalkingShip(new ClassCPulseEngine(), new FirstClassHull());
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeIncreasedDensityOfSpace };

        // Act
        var route = new Route(environments);
        FlyResult result = route.CheckFlyResult(walkingShip);

        // Assert
        Assert.IsType<FlyResult.ImpossibleFly>(result);
    }

    [Theory]
    [InlineData(350)]
    public void CheckFlyResult_ShouldReturnShipLoss_WhenAvgurShipInNebulaeIncreasedDensitySpace(int distance)
    {
        // Arrange
        var nebulaeIncreasedDensityOfSpace = new NebulaeIncreasedDensityOfSpace(
            new ReadOnlyCollection<INebulaeIncreasedDensitySpaceObstacle>(new List<INebulaeIncreasedDensitySpaceObstacle>()), distance);
        var avgurShip = new AvgurShip(new ClassEPulseEngine(), new AlphaJumpEngine(), new ThirdClassDeflector(), new ThirdClassHull());
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeIncreasedDensityOfSpace };
        var route = new Route(environments);

        // Act
        FlyResult result = route.CheckFlyResult(avgurShip);

        // Assert
        Assert.IsType<FlyResult.ShipLoss>(result);
    }

    [Theory]
    [InlineData(350)]
    public void CheckFlyResult_ShouldReturnDeathCrew_WhenVaclasShipInNebulaeIncreasedDensitySpaceWithAntimatterFlare(
        int distance)
    {
        // Arrange
        IReadOnlyCollection<INebulaeIncreasedDensitySpaceObstacle> obstacles = new List<INebulaeIncreasedDensitySpaceObstacle>
            { new AntimatterFlare() };
        var nebulaeIncreasedDensityOfSpace = new NebulaeIncreasedDensityOfSpace(obstacles, distance);
        var vaclasShip = new VaclasShip(new ClassEPulseEngine(), new GammaJumpEngine(), new FirstClassDeflector(), new SecondClassHull());
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeIncreasedDensityOfSpace };
        var route = new Route(environments);

        // Act
        FlyResult result = route.CheckFlyResult(vaclasShip);

        // Assert
        Assert.IsType<FlyResult.DeathCrew>(result);
    }

    [Theory]
    [InlineData(350)]
    public void
        CheckFlyResult_ShouldReturnDeathCrew_WhenVaclasShipWithPhotonDeflectorInNebulaeIncreasedDensitySpaceWithAntimatterFlare(
            int distance)
    {
        // Arrange
        IReadOnlyCollection<INebulaeIncreasedDensitySpaceObstacle> obstacles = new List<INebulaeIncreasedDensitySpaceObstacle>
            { new AntimatterFlare() };
        var nebulaeIncreasedDensityOfSpace = new NebulaeIncreasedDensityOfSpace(obstacles, distance);
        var vaclasShip = new VaclasShip(new ClassEPulseEngine(), new GammaJumpEngine(), new PhotonicDeflector(new FirstClassDeflector()), new SecondClassHull());
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeIncreasedDensityOfSpace };
        var route = new Route(environments);

        // Act
        FlyResult result = route.CheckFlyResult(vaclasShip);

        // Assert
        Assert.IsType<FlyResult.SuccessResult>(result);
    }

    [Theory]
    [InlineData(350)]
    public void CheckFlyResult_ShouldReturnDestructionShip_WhenVaclasShipInNebulaeNitrideParticlesWithSpaceWhales(
        int distance)
    {
        // Arrange
        IReadOnlyCollection<INebulaeNitrideParticlesObstacle> obstacles = new List<INebulaeNitrideParticlesObstacle>
            { new SpaceWhales(1) };
        var nebulaeNitrideParticles = new NebulaeNitrideParticles(obstacles, distance);
        var vaclasShip = new VaclasShip(new ClassEPulseEngine(), new GammaJumpEngine(), new FirstClassDeflector(), new SecondClassHull());
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeNitrideParticles };
        var route = new Route(environments);

        // Act
        FlyResult result = route.CheckFlyResult(vaclasShip);

        // Arrange
        Assert.IsType<FlyResult.DestructionShip>(result);
    }

    [Theory]
    [InlineData(350, 85)]
    public void CheckFlyResult_ShouldReturnSuccessResult_WhenAvgurShipInNebulaeNitrideParticlesWithSpaceWhales(
        int distance, int hitPointsHullStrengthClass)
    {
        // Arrange
        IReadOnlyCollection<INebulaeNitrideParticlesObstacle> obstacles = new List<INebulaeNitrideParticlesObstacle>
            { new SpaceWhales(1) };
        var nebulaeNitrideParticles = new NebulaeNitrideParticles(obstacles, distance);
        var avgurShip = new AvgurShip(new ClassEPulseEngine(), new AlphaJumpEngine(), new ThirdClassDeflector(), new ThirdClassHull());
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeNitrideParticles };
        var route = new Route(environments);

        // Act
        FlyResult result = route.CheckFlyResult(avgurShip);

        // Assert
        Assert.IsType<FlyResult.SuccessResult>(result);
        Assert.Equal(avgurShip.Hull.HitPoints.Value, hitPointsHullStrengthClass);
    }

    [Theory]
    [InlineData(350, 100)]
    public void CheckFlyResult_ShouldReturnSuccessResult_WhenMeredianShipInNebulaeNitrideParticlesWithSpaceWhales(
        int distance, int hitPointsHullStrengthClass)
    {
        // Arrange
        IReadOnlyCollection<INebulaeNitrideParticlesObstacle> obstacles = new List<INebulaeNitrideParticlesObstacle>
            { new SpaceWhales(1) };
        var nebulaeNitrideParticles = new NebulaeNitrideParticles(obstacles, distance);
        var meredianShip = new MeredianShip(new ClassEPulseEngine(), new SecondClassDeflector(), new SecondClassHull());
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeNitrideParticles };
        var route = new Route(environments);

        // Act
        FlyResult result = route.CheckFlyResult(meredianShip);

        // Assert
        Assert.IsType<FlyResult.SuccessResult>(result);
        Assert.Equal(meredianShip.Deflector.HitPoints.Value, hitPointsHullStrengthClass);
    }
}