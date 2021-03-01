using ESM.Core.Base.Animals.Turtles;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Movements;
using ESM.Core.Base.Obstacles.Mines;
using ESM.Core.Exceptions;
using System.Collections.Generic;

namespace ESM.Services.Animals.Turtles.Services
{
    /// <summary>
    /// Represents the concrete class of the turtle
    /// </summary>
    public class Turtle : ITurtle
    {
        #region Fields
        private readonly ITurtleMoveService _turtleMoveService;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the board
        /// </summary>
        private IBoard Board { get; set; }

        /// <summary>
        /// Gets or sets the value of turtle point
        /// </summary>
        public TurtlePoint Point { get; set; }

        /// <summary>
        /// Gets or sets the value of result 
        /// </summary>
        public string Result { get; set; }
        #endregion

        #region CtOr
        public Turtle(ITurtleMoveService turtleMoveService)
        {
            _turtleMoveService = turtleMoveService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="point">Turtle point</param>
        public void Set(IBoard board, TurtlePoint point)
        {
            if (board.IsValid(point))
                Point = point;
            else
                throw new PointValidationException("Turtle point is not valid!");

            Board = board;
        }

        /// <summary>
        /// Move
        /// </summary>
        /// <param name="movements">Movement</param>
        /// <param name="mines">Collection of mine</param>
        /// <param name="exit">Exit</param>
        public void Move(IEnumerable<Movement> movements, IEnumerable<IMine> mines, IExit exit)
        {
            var isHitMine = false;
            var isExit = false;

            foreach (var movement in movements)
            {
                if (movement == Movement.Move)
                {
                    // Make sure the turtle still in the board.
                    if (!Board.IsValid(Point))
                        throw new PointValidationException("Turtle cannot go out of board!");

                    // Move the turtle to the next tile.
                    _turtleMoveService.MoveForward(Point);

                    // If the turtle hits the mine it will not continue.
                    if (_turtleMoveService.IsObstacleHit(Point, mines))
                    {
                        Result = $"Mine Hit";
                        isHitMine = true;
                        break;
                    }

                    // If the turtle finds the exit it will not continue.
                    if (_turtleMoveService.IsExit(Point, exit))
                    {
                        Result = $"Success";
                        isExit = true;
                        break;
                    }
                }
                else if (movement == Movement.Left)
                {
                    // Turn left the turtle.
                    _turtleMoveService.MoveLeft(Point);
                }
                else if (movement == Movement.Right)
                {
                    // Turn right the turtle.
                    _turtleMoveService.MoveRight(Point);
                }
            }

            if (!isHitMine && !isExit) Result = "Still In Danger";
        }
        #endregion
    }
}
