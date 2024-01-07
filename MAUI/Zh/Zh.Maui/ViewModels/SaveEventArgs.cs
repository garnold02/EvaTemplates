namespace Zh.Maui.ViewModels
{
    public class SaveEventArgs : EventArgs
    {
        public string Name { get; }

        public SaveEventArgs(string name)
        {
            Name = name;
        }
    }
}
