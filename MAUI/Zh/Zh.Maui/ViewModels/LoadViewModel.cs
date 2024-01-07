#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zh.Logic.Persistence;
using System.Collections.ObjectModel;

namespace Zh.Maui.ViewModels
{
    public partial class LoadViewModel : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private ObservableCollection<SaveFileViewModel>? _files;

        #endregion

        #region Events

        public EventHandler<SaveEventArgs>? LoadEvent;
        public EventHandler? CancelEvent;

        #endregion

        #region Public Methods

        public async Task Populate(IStore store)
        {
            Files = new ObservableCollection<SaveFileViewModel>();
            foreach (string name in await store.GetFilesAsync())
            {
                SaveFileViewModel saveFileViewModel = new SaveFileViewModel(name, await store.GetModifiedTimeAsync(name));
                saveFileViewModel.SelectEvent += SaveFileViewModel_Select;
                Files.Add(saveFileViewModel);
            }
        }

        #endregion

        #region Command Methods

        [RelayCommand]
        private void Cancel()
        {
            CancelEvent?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Event Methods

        private void SaveFileViewModel_Select(object? sender, SaveEventArgs e)
        {
            LoadEvent?.Invoke(this, e);
        }

        #endregion
    }
}
