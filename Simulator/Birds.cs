namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; init; } = true;

    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";

    public override void Move(Direction direction)
    {
        if (CurrentMap == null)
            throw new InvalidOperationException("Birds cannot move without being assigned to a map.");

        if (CanFly)
        {
            var firstMove = CurrentMap.Next(CurrentPosition, direction);
            var secondMove = CurrentMap.Next(firstMove, direction);
            CurrentMap.Move(this, CurrentPosition, secondMove);
            CurrentPosition = secondMove;
        }
        else
        {
            var diagonalMove = CurrentMap.NextDiagonal(CurrentPosition, direction);
            CurrentMap.Move(this, CurrentPosition, diagonalMove);
            CurrentPosition = diagonalMove;
        }
    }
}
