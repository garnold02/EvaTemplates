using Zh.Logic.Persistence;

namespace Zh.Logic.Model
{
    public class LogicModel
    {
        #region Fields

        private IDataAccess _dataAccess;
        private LogicTable _table;

        #endregion

        #region Properties
        #endregion

        #region Events

        public EventHandler? Event1 { get; set; }

        #endregion

        #region Constructors

        public LogicModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _table = new LogicTable();
        }

        #endregion

        #region Public Methods

        public async Task SaveAsync(string path)
        {
            await _dataAccess.SaveAsync(path, _table);
        }

        public async Task LoadAsync(string path)
        {
            _table = await _dataAccess.LoadAsync(path);
        }

        #endregion

        #region Private Methods
        #endregion

    }
}
