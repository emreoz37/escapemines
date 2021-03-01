using ESM.Core.Base.Boards;
using ESM.Core.Base.Obstacles;
using ESM.Core.Infrastructure;

namespace ESM.Services.Obstacles
{
    /// <summary>
    /// Generic obstacle set command of <see cref="ICommand"/>
    /// </summary>
    /// <typeparam name="TObstacle">Obstacle</typeparam>
    public interface IObstacleSetCommand<TObstacle> : ICommand where TObstacle : IObstacle
    {
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="obstacle">Obstacle</param>
        void Set(IBoard board, TObstacle obstacle);

    }
}
