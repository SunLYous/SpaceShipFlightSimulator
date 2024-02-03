using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class HitPoints
{
    private const decimal HitPointsAmount = 100;
    private const decimal MinimumHitPoints = 0;

    public HitPoints()
    {
        Value = HitPointsAmount;
    }

    public decimal Value { get; private set; }

    public void TakeDamage(decimal damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException(
                "Damage cannot be negative",
                nameof(damage));
        }

        Value -= damage;
    }

    public bool IntegrityCheck()
    {
        return Value > MinimumHitPoints;
    }
}