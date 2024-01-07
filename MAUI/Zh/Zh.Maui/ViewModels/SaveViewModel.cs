#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zh.Logic.Persistence;
using System.Collections.ObjectModel;

namespace Zh.Maui.ViewModels
{
    public partial class SaveViewModel : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private ObservableCollection<SaveFileViewModel>? _files;

        #endregion

        #region Events

        public EventHandler<SaveEventArgs>? SaveEvent;
        public EventHandler? CancelEvent;

        #endregion

        #region Public Methods

        public async Task Populate(IStore store)
        {
            Files = new ObservableCollection<SaveFileViewModel>();
            foreach (string name in await store.GetFilesAsync())
            {
                Files.Add(new SaveFileViewModel(name, await store.GetModifiedTimeAsync(name)));
            }
        }

        #endregion

        #region Command Methods

        [RelayCommand]
        private void Save()
        {
            SaveEvent?.Invoke(this, new SaveEventArgs(Name));
        }

        [RelayCommand]
        private void Cancel()
        {
            CancelEvent?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
