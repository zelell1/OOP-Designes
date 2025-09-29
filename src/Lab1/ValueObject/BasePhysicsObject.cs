using System.Numerics;

namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public abstract record BasePhysicsObject<T> where T : INumber<T>
{
    public T ValueT { get; }

    protected BasePhysicsObject(T valueT)
    {
        IsValid(valueT);
        ValueT = valueT;
    }

    protected abstract void IsValid(T valueT);

    public static bool operator >(BasePhysicsObject<T> lhs, BasePhysicsObject<T> rhs) => lhs.ValueT > rhs.ValueT;

    public static bool operator <(BasePhysicsObject<T> lhs, BasePhysicsObject<T> rhs) => lhs.ValueT < rhs.ValueT;
}