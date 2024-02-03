﻿using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullStrengthClasses;

public class SecondClassHull : IHull
{
    private const decimal DamageGradationCoefficient = 0.7m;

    public SecondClassHull()
    {
        HitPoints = new HitPoints();
    }

    public HitPoints HitPoints { get; }

    public DamageResult TakeDamage(decimal damage)
    {
        damage *= DamageGradationCoefficient;
        HitPoints.TakeDamage(damage);
        if (HitPoints.IntegrityCheck())
        {
            return new DamageResult.Success();
        }

        return new DamageResult.Destruction();
    }
}