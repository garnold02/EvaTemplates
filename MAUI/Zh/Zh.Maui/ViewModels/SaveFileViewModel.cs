#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Zh.Maui.ViewModels
{
    public partial class SaveFileViewModel : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _date;

        #endregion

        #region Events

        public EventHandler<SaveEventArgs>? SelectEvent;

        #endregion

        #region Constructors

        public SaveFileViewModel(string name, DateTime date)
        {
            Name = name;
            Date = date.ToString();
        }

        #endregion

        #region Command Methods

        [RelayCommand]
        private void Select()
        {
            SelectEvent?.Invoke(this, new SaveEventArgs(Name));
        }

        #endregion
    }
}
