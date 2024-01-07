using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Zh.WPF.ViewModels
{
    public partial class ViewModel2: ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private int _property1;

        #endregion

        #region Events

        public EventHandler? Event1 { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Public Methods
        #endregion

        #region Command Methods

        [RelayCommand]
        private void Command1()
        {
            Event1?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
