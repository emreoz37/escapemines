using ESM.Core.Base.Directions;
using ESM.Core.Base.Points;

namespace ESM.Core.Base.Animals.Turtles
{
    /// <summary>
    /// Represents turtle locale point on the game board
    /// </summary>
    public class TurtlePoint : IPoint
    {
        #region Ctor
        public TurtlePoint(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value of X
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Gets or sets the value of Y
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Gets or sets the value of direction
        /// </summary>
        public Direction Direction { get; set; }
        #endregion
    }
}
