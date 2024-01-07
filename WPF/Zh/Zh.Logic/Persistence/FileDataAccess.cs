namespace Zh.Logic.Persistence
{
    public class FileDataAccess : IDataAccess
    {
        public Task<LogicTable> LoadAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(string path, LogicTable table)
        {
            throw new NotImplementedException();
        }

        private static async Task<int> Read(StreamReader reader)
        {
            string? line = await reader.ReadLineAsync();

            if (line == null)
            {
                throw new DataAccessException();
            }

            if (!int.TryParse(line, out int value))
            {
                throw new DataAccessException();
            }

            return value;
        }

        private static async Task Write(StreamWriter writer, int value)
        {
            try
            {
                await writer.WriteLineAsync($"{value}");
            }
            catch
            {
                throw new DataAccessException();
            }
        }
    }
}
