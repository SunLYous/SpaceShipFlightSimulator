namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public abstract record DamageResult
{
    private DamageResult() { }

    public sealed record DeathCrew : DamageResult;

    public sealed record Destruction : DamageResult
    {
        public Destruction(decimal remainingDamage = 0)
        {
            RemainingDamage = remainingDamage;
        }

        public decimal RemainingDamage { get; }
    }

    public sealed record Success : DamageResult;
}