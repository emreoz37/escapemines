using ESM.Core.Base.Points;
using ESM.Core.Exceptions;

namespace ESM.Core.Base.Boards
{
    /// <summary>
    /// Represents the concrete class of the exit
    /// </summary>
    public class Exit : IExit
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value of point
        /// </summary>
        public Point Point { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Sets a point on the board
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="point">Point</param>
        public void Set(IBoard board, Point point)
        {
            if (board.IsValid(point))
            {
                Point = point;
            }
            else
            {
                throw new PointValidationException("Exit point is not valid!");
            }
        }
        #endregion

    }
}
