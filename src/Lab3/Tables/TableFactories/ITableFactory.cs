using Itmo.ObjectOrientedProgramming.Lab3.Tables.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.TableFactories;

public interface ITableFactory
{
    IPlayerTableBuilder CreateBuilder();
}