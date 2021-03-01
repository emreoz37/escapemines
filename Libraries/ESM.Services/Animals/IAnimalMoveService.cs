using ESM.Core.Base.Animals;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Obstacles;
using ESM.Core.Base.Points;
using System.Collections.Generic;

namespace ESM.Services.Animals
{
    /// <summary>
    /// Represents the contract of animal move
    /// </summary>
    /// <typeparam name="TAnimal">Animal</typeparam>
    /// <typeparam name="YObstacle">Obstacle</typeparam>
    public interface IAnimalMoveService<TAnimal, YObstacle>
        where TAnimal : IAnimal
        where YObstacle : IObstacle
    {
        /// <summary>
        /// Is Obstacle hit
        /// </summary>
        /// <param name="point">Point</param>
        /// <param name="obstacles">Obstacles</param>
        /// <returns>Boolean</returns>
        bool IsObstacleHit(IPoint point, IEnumerable<YObstacle> obstacles);

        /// <summary>
        /// Is Exit
        /// </summary>
        /// <param name="point">Point</param>
        /// <param name="exit">Exit</param>
        /// <returns>Boolean</returns>
        bool IsExit(IPoint point, IExit exit);
    }
}
