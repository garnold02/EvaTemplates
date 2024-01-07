#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Zh.Maui.ViewModels
{
    public partial class ViewModel1 : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private RowDefinitionCollection? _rowDefinitions;

        [ObservableProperty]
        private ColumnDefinitionCollection? _columnDefinitions;

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
            RowDefinitions = new RowDefinitionCollection(Enumerable.Repeat(new RowDefinition(GridLength.Star), height).ToArray());
            ColumnDefinitions = new ColumnDefinitionCollection(Enumerable.Repeat(new ColumnDefinition(GridLength.Star), width).ToArray());
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
