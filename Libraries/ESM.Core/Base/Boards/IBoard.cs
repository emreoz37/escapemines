using ESM.Core.Base.Points;

namespace ESM.Core.Base.Boards
{
    /// <summary>
    /// Represents the contract of board
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Gets or sets the value of board size
        /// </summary>
        Size Size { get; set; }

        /// <summary>
        /// Set size of board
        /// </summary>
        /// <param name="size">Size</param>
        void SetSize(Size size);

        /// <summary>
        /// Is valid point of board
        /// </summary>
        /// <param name="point">Point</param>
        /// <returns>Boolean</returns>
        bool IsValid(IPoint point);
    }
}
