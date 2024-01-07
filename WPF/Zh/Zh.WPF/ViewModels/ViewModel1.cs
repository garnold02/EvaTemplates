using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Zh.WPF.ViewModels
{
    public partial class ViewModel1 : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private int _width;

        [ObservableProperty]
        private int _height;

        [ObservableProperty]
        private ObservableCollection<FieldViewModel>? _fields;

        #endregion

        #region Events

        public EventHandler? Event1 { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Public Methods

        public void SetGridSize(int width, int height)
        {
            Width = width;
            Height = height;
            Fields = new ObservableCollection<FieldViewModel>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Fields.Add(new FieldViewModel(x, y, (x + y) % 2 == 0 ? "field_a.png" : "field_b.png" ));
                }
            }
        }

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
