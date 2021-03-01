namespace ESM.Core.Base.Points
{
    /// <summary>
    /// Represents the concrete class of point
    /// </summary>
    public class Point : IPoint
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value of X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the value of Y
        /// </summary>
        public int Y { get; set; }
        #endregion

        #region CtOr
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion


    }
}
