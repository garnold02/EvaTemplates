#nullable enable

using Zh.Logic.Model;
using Zh.Logic.Persistence;
using Zh.Maui.Persistence;
using Zh.Maui.ViewModels;

namespace Zh.Maui;

public partial class AppShell : Shell
{
    #region Fields

    private readonly LogicModel _logicModel;

    private readonly ViewModel1 _viewModel1;
    private readonly ViewModel2 _viewModel2;
    private readonly ViewModel3 _viewModel3;
    private readonly ViewModel4 _viewModel4;
    private readonly SaveViewModel _saveViewModel;
    private readonly LoadViewModel _loadViewModel;

    private readonly IDispatcherTimer _timer;
    private readonly IStore _store;

    #endregion

    #region Constructors

    public AppShell()
	{
		InitializeComponent();

        _logicModel = new LogicModel(new FileDataAccess());
        _logicModel.Event1 += LogicModel_Event1;

        _viewModel1 = new ViewModel1();
        _viewModel1.Event1 += ViewModel1_Event1;
        _viewModel1.SetGridSize(5, 5);

        _viewModel2 = new ViewModel2();
        _viewModel2.Event1 += ViewModel2_Event1;

        _viewModel3 = new ViewModel3();
        _viewModel3.Event1 += ViewModel3_Event1;

        _viewModel4 = new ViewModel4();
        _viewModel4.Event1 += ViewModel4_Event1;

        _saveViewModel = new SaveViewModel();
        _saveViewModel.SaveEvent += SaveViewModel_Save;
        _saveViewModel.CancelEvent += SaveViewModel_Cancel;

        _loadViewModel = new LoadViewModel();
        _loadViewModel.LoadEvent += LoadViewModel_Load;
        _loadViewModel.CancelEvent += LoadViewModel_Cancel;

        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(0.5);
        _timer.Tick += Timer_Tick;
        _timer.Stop();

        _store = new MauiStore();

        BindingContext = _viewModel1;
    }

    #endregion

    #region Model Event Methods

    private void LogicModel_Event1(object? sender, EventArgs e)
    {
    }

    #endregion

    #region ViewModel1 Event Methods

    private void ViewModel1_Event1(object? sender, EventArgs e)
    {
    }

    #endregion

    #region ViewModel2 Event Methods

    private void ViewModel2_Event1(object? sender, EventArgs e)
    {
    }

    #endregion

    #region ViewModel3 Event Methods

    private void ViewModel3_Event1(object? sender, EventArgs e)
    {
    }

    #endregion

    #region ViewModel4 Event Methods

    private void ViewModel4_Event1(object? sender, EventArgs e)
    {
    }

    #endregion

    #region SaveViewModel Event Methods

    private async void SaveViewModel_Save(object? sender, SaveEventArgs e)
    {
        try
        {
            await _logicModel.SaveAsync(Path.Combine(FileSystem.AppDataDirectory, e.Name));
            await DisplayAlert("Save Game", "The game has been saved!", "OK");
        }
        catch
        {
            await DisplayAlert("Save Game", "The game cannot be saved!", "OK");
        }

        await Navigation.PopAsync();
    }

    private async void SaveViewModel_Cancel(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    #endregion

    #region LoadViewModel Event Methods

    private async void LoadViewModel_Load(object? sender, SaveEventArgs e)
    {
        try
        {
            await _logicModel.LoadAsync(Path.Combine(FileSystem.AppDataDirectory, e.Name));
        }
        catch
        {
            await DisplayAlert("Load Game", "The game cannot be loaded!", "OK");
        }
    }

    private async void LoadViewModel_Cancel(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    #endregion

    #region Timer Events

    private void Timer_Tick(object? sender, EventArgs e)
    {
    }

    #endregion
}
