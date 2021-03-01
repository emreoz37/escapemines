namespace ESM.Core.Base.Boards
{
    /// <summary>
    /// Represents the class of size
    /// </summary>
    public class Size
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value maximum row amount
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// Gets or sets the value maximum column amount
        /// </summary>
        public int MaxY { get; set; }
        #endregion

        #region CtOr
        public Size(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }
        #endregion


    }
}
