using ESM.Core.Base.Animals.Turtles;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Directions;
using ESM.Core.Base.Points;
using ESM.Core.Base.Obstacles.Mines;
using System.Collections.Generic;
using System.Linq;

namespace ESM.Services.Animals.Turtles
{
    /// <summary>
    /// Represents the concrete class of the turtle move service
    /// </summary>
    public class TurtleMoveService : ITurtleMoveService
    {
        #region Methods
        /// <summary>
        /// Is obstacle hit
        /// </summary>
        /// <param name="point">Point</param>
        /// <param name="mines">Mines</param>
        /// <returns>Bool</returns>
        public bool IsObstacleHit(IPoint point, IEnumerable<IMine> mines)
        {
            return mines.Any(x => x.Point.X == point.X && x.Point.Y == point.Y);
        }

        /// <summary>
        /// Is exit
        /// </summary>
        /// <param name="point">Point</param>
        /// <param name="exit">Exit</param>
        /// <returns></returns>
        public bool IsExit(IPoint point, IExit exit)
        {
            return exit.Point.X == point.X && exit.Point.Y == point.Y;
        }

        /// <summary>
        /// Move Forward
        /// </summary>
        /// <param name="point">Turtle point</param>
        public void MoveForward(TurtlePoint point)
        {
            switch (point.Direction)
            {
                case Direction.North:
                    point.Y += 1;
                    break;
                case Direction.West:
                    point.X -= 1;
                    break;
                case Direction.South:
                    point.Y -= 1;
                    break;
                case Direction.East:
                    point.X += 1;
                    break;
            }
        }

        /// <summary>
        /// Move Left
        /// </summary>
        /// <param name="point">Turtle point</param>
        public void MoveLeft(TurtlePoint point)
        {
            switch (point.Direction)
            {
                case Direction.North:
                    point.Direction = Direction.West;
                    break;
                case Direction.West:
                    point.Direction = Direction.South;
                    break;
                case Direction.South:
                    point.Direction = Direction.East;
                    break;
                case Direction.East:
                    point.Direction = Direction.North;
                    break;
            }
        }

        /// <summary>
        /// Move Right
        /// </summary>
        /// <param name="point">Turtle point</param>
        public void MoveRight(TurtlePoint point)
        {
            switch (point.Direction)
            {
                case Direction.North:
                    point.Direction = Direction.East;
                    break;
                case Direction.East:
                    point.Direction = Direction.South;
                    break;
                case Direction.South:
                    point.Direction = Direction.West;
                    break;
                case Direction.West:
                    point.Direction = Direction.North;
                    break;
            }
        }
        #endregion
    }
}
