namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.Builders;

public interface IPlayerTableBuilder : IPlayerTableConfigBuilder
{
    PlayerTable Build();
}