using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battles;

public class Battle
{
    private readonly PlayerTable _firstPlayer;

    private readonly PlayerTable _secondPlayer;

    public Battle(PlayerTable firstPlayer, PlayerTable secondPlayer)
    {
        _firstPlayer = firstPlayer.Clone();
        _secondPlayer = secondPlayer.Clone();
    }

    public FightResult Fight()
    {
        List<PlayerTable> playerTables = [_firstPlayer, _secondPlayer];
        int isFirst = 0;

        while (true)
        {
            PlayerTable attackingTable = playerTables[isFirst];
            PlayerTable defendingTable = playerTables[(isFirst + 1) % 2];

            ICreature? attackingCreature = attackingTable.FindAttackingCreature();
            ICreature? defendingCreature = defendingTable.FindDefendingCreature();

            if (attackingCreature is null && defendingCreature is null)
            {
                return new FightResult.Draw();
            }

            if (attackingCreature is null)
            {
                if (isFirst == 0)
                {
                    return new FightResult.SecondPlayerWin();
                }

                return new FightResult.FirstPlayerWin();
            }

            if (defendingCreature is null)
            {
                if (isFirst == 0)
                {
                    return new FightResult.FirstPlayerWin();
                }

                return new FightResult.SecondPlayerWin();
            }

            attackingCreature.Attacking(defendingCreature);
            isFirst = (isFirst + 1) % 2;
        }
    }
}