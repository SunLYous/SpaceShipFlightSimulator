using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IShipWithJumpEngine
{
    public IJumpEngine JumpEngine { get; }
}