using ESM.Core.Base.Points;

namespace ESM.Core.Base.Boards
{
    /// <summary>
    /// Represents the contract of base board item
    /// </summary>
    public interface IBaseBoardItem
    {
        /// <summary>
        /// Gets or sets the value of point
        /// </summary>
        Point Point { get; set; }

        /// <summary>
        /// Sets a point on the board
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="point">Point</param>
        void Set(IBoard board, Point point);
    }
}
