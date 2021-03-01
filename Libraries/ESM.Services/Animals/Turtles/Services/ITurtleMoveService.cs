using ESM.Core.Base.Animals.Turtles;
using ESM.Core.Base.Obstacles.Mines;

namespace ESM.Services.Animals.Turtles
{
    /// <summary>
    /// Represents the contract of turtle move service <see cref="IAnimalMoveService{TAnimal, YObstacle}"/>
    /// </summary>
    public interface ITurtleMoveService : IAnimalMoveService<ITurtle,IMine>
    {
        /// <summary>
        /// Move Forward
        /// </summary>
        /// <param name="point">Turtle point</param>
        void MoveForward(TurtlePoint point);

        /// <summary>
        /// Move Left
        /// </summary>
        /// <param name="point">Turtle point</param>
        void MoveLeft(TurtlePoint point);

        /// <summary>
        /// Move Right
        /// </summary>
        /// <param name="point">Turtle point</param>
        void MoveRight(TurtlePoint point);
    }
}
