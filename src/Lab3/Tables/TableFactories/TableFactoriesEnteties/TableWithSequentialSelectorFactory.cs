using Itmo.ObjectOrientedProgramming.Lab3.CreatureSelector.CreatureSelectorEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.TableFactories.TableFactoriesEnteties;

public class TableWithSequentialSelectorFactory : ITableFactory
{
    public IPlayerTableBuilder CreateBuilder()
    {
        return PlayerTable.Builder.AddCreatureSelector(new SequentiallySelector());
    }
}