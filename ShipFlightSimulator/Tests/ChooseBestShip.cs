using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;
using ShipFlightSimulator.Environments.Entities;
using ShipFlightSimulator.Environments.Models.Obstacles;
using ShipFlightSimulator.Route;
using ShipFlightSimulator.Route.Services;
using ShipFlightSimulator.Ships.Entities;
using ShipFlightSimulator.Ships.Models.Deflectors;
using ShipFlightSimulator.Ships.Models.Engines;
using ShipFlightSimulator.Ships.Models.HullStrengthClasses;
using Xunit;

namespace Tests;

public class ChooseBestShip
{
    [Fact]
    public void CheckChooseBestShip_ShouldReturnWalkingShuttleShip_WhenVaclarAndWalkingShipLaunch()
    {
        // Arrange
        IReadOnlyCollection<INormalSpaceObstacleObstacle> obstacles = new List<INormalSpaceObstacleObstacle>();
        var normalSpace = new NormalSpace(obstacles, 300);
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { normalSpace };
        var walkingShip = new WalkingShip(new ClassCPulseEngine(), new FirstClassHull());
        var vaclasShip = new VaclasShip(new ClassEPulseEngine(), new GammaJumpEngine(), new FirstClassDeflector(), new SecondClassHull());
        var route = new Route(environments);

        // Act
        IShip? result = new ChooseShips(new List<IShip>() { vaclasShip, walkingShip }, route).ChooseBestShip();

        // Assert
        Assert.Equal(walkingShip, result);
    }

    [Fact]
    public void CheckChooseBestShip_ShouldReturnStella_WhenAvgurAndStellaLaunch()
    {
        // Arrange
        IReadOnlyCollection<INebulaeIncreasedDensitySpaceObstacle> obstacles = new List<INebulaeIncreasedDensitySpaceObstacle>();
        var nebulaeIncreasedDensityOfSpace = new NebulaeIncreasedDensityOfSpace(obstacles, 500);
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeIncreasedDensityOfSpace };
        var avgurShip = new AvgurShip(new ClassEPulseEngine(), new AlphaJumpEngine(), new ThirdClassDeflector(), new ThirdClassHull());
        var stellaShip = new StellaShip(new ClassCPulseEngine(), new OmegaJumpEngine(), new FirstClassDeflector(), new FirstClassHull());
        var route = new Route(environments);

        // Act
        IShip? result = new ChooseShips(new List<IShip>() { avgurShip, stellaShip }, route).ChooseBestShip();

        // Assert
        Assert.Equal(stellaShip, result);
    }

    [Fact]
    public void CheckChooseBestShip_ShouldReturnVaclas_WhenVaclasAndWalkingShipLaunch()
    {
        // Arrange
        IReadOnlyCollection<INebulaeNitrideParticlesObstacle> obstacles = new List<INebulaeNitrideParticlesObstacle>();
        var nebulaeNitrideParticles = new NebulaeNitrideParticles(obstacles, 500);
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment> { nebulaeNitrideParticles };
        var walkingShip = new WalkingShip(new ClassCPulseEngine(), new FirstClassHull());
        var vaclasShip = new VaclasShip(new ClassEPulseEngine(), new GammaJumpEngine(), new FirstClassDeflector(), new SecondClassHull());
        var route = new Route(environments);

        // Act
        IShip? result = new ChooseShips(new List<IShip>() { vaclasShip, walkingShip }, route).ChooseBestShip();

        // Assert
        Assert.Equal(vaclasShip, result);
    }

    [Fact]
    public void CheckChooseBestShip_ShouldReturnVaclas_WhenVaclasAndAvgurShipLaunch()
    {
        // Arrange
        IReadOnlyCollection<INormalSpaceObstacleObstacle> normalSpaceObstacles = new List<INormalSpaceObstacleObstacle>
            { new Meteorite(), new SmallAsteroid(), new Meteorite() };
        var normalSpace = new NormalSpace(normalSpaceObstacles, 400);
        IReadOnlyCollection<INebulaeIncreasedDensitySpaceObstacle> nebulaeNebulaeIncreasedDensitySpacesObstacles =
            new List<INebulaeIncreasedDensitySpaceObstacle>();
        var nebulaeIncreasedDensityOfSpace =
            new NebulaeIncreasedDensityOfSpace(nebulaeNebulaeIncreasedDensitySpacesObstacles, 250);
        IReadOnlyCollection<IEnvironment> environments = new List<IEnvironment>
            { normalSpace, nebulaeIncreasedDensityOfSpace };
        var stellaShip = new StellaShip(new ClassCPulseEngine(), new OmegaJumpEngine(), new FirstClassDeflector(), new FirstClassHull());
        var vaclasShip = new VaclasShip(new ClassEPulseEngine(), new GammaJumpEngine(), new FirstClassDeflector(), new SecondClassHull());
        var route = new Route(environments);

            // Act
        IShip? result = new ChooseShips(new List<IShip>() { vaclasShip, stellaShip }, route).ChooseBestShip();

        // Assert
        Assert.Equal(stellaShip, result);
    }
}