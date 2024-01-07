using CommunityToolkit.Mvvm.ComponentModel;

namespace Zh.WPF.ViewModels
{
    public partial class FieldViewModel : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private int _x;

        [ObservableProperty]
        private int _y;

        [ObservableProperty]
        private string _content;

        #endregion

        #region Constructors

        public FieldViewModel(int x, int y, string content)
        {
            X = x;
            Y = y;
            Content = content;
        }

        #endregion
    }
}
