using ESM.Core.Base.Animals;
using ESM.Core.Base.Animals.Turtles;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Movements;
using ESM.Core.Base.Obstacles.Mines;
using System.Collections.Generic;

namespace ESM.Services.Animals.Turtles
{
    /// <summary>
    /// Represents the contract of turtle <see cref="IAnimal"/>
    /// </summary>
    public interface ITurtle: IAnimal
    {
        /// <summary>
        /// Gets or sets the value of turtle point
        /// </summary>
        TurtlePoint Point { get; set; }

        /// <summary>
        /// Gets or sets the value of result 
        /// </summary>
        string Result { get; set; }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="point">Turtle point</param>
        void Set(IBoard board, TurtlePoint point);

        /// <summary>
        /// Move
        /// </summary>
        /// <param name="movements">Movement</param>
        /// <param name="mines">Collection of mine</param>
        /// <param name="exit">Exit</param>
        void Move(IEnumerable<Movement> movements, IEnumerable<IMine> mines, IExit exit);
    }
}
