using ESM.Core.Base.Points;

namespace ESM.Core.Base.Boards
{
    /// <summary>
    /// Represents the concrete class of the board.
    /// </summary>
    public class Board : IBoard
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value of board size
        /// </summary>
        public Size Size { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Set size of board
        /// </summary>
        /// <param name="size">Size</param>
        public void SetSize(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Is valid point of board
        /// </summary>
        /// <param name="point">Point</param>
        /// <returns>Boolean</returns>
        public bool IsValid(IPoint point)
        {
            return point != null && point.X >= 0 && point.X <= Size.MaxX && point.Y >= 0 && point.Y <= Size.MaxY;
        }
        #endregion

    }
}
