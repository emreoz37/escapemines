using ESM.Core.Base.Obstacles.Mines;

namespace ESM.Services.Obstacles.Mines
{
    /// <summary>
    /// Represents the conctract of mine set command <see cref="IObstacleSetCommand{T}"/>
    /// </summary>
    public interface IMineSetCommand : IObstacleSetCommand<IMine>
    {
    }
}
