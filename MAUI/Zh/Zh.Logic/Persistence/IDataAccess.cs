namespace Zh.Logic.Persistence
{
    public interface IDataAccess
    {
        #region Public Methods

        Task SaveAsync(string path, LogicTable table);
        Task<LogicTable> LoadAsync(string path);

        #endregion
    }
}
