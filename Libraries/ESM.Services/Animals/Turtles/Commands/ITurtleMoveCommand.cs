using ESM.Core.Base.Obstacles.Mines;

namespace ESM.Services.Animals.Turtles.Commands
{
    /// <summary>
    /// Represents the contract of turtle move <see cref="IAnimalMoveCommand{TAnimal, YObstacle}"/>
    /// </summary>
    public interface ITurtleMoveCommand : IAnimalMoveCommand<ITurtle,IMine>
    {
    }
}
