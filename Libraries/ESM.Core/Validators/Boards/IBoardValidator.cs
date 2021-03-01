namespace ESM.Core.Validators.Boards
{
    public interface IBoardValidator : IBaseValidator
    {
        void IsValidBoardSize(string boardSize);

    }

}
