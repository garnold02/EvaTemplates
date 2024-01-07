using System;
using System.ComponentModel;
using System.Windows;
using Zh.Logic.Model;
using Zh.Logic.Persistence;
using Zh.WPF.ViewModels;
using Zh.WPF.Views;

namespace Zh.WPF
{
    public partial class App : Application
    {
        #region Fields

        private readonly LogicModel _logicModel;

        private readonly ViewModel1 _viewModel1;
        private readonly ViewModel1 _viewModel2;
        private readonly ViewModel1 _viewModel3;
        private readonly ViewModel1 _viewModel4;

        private Window? _view;

        #endregion

        #region Constructors

        public App()
        {
            _logicModel = new LogicModel(new FileDataAccess());
            _logicModel.Event1 += LogicModel_Event1;

            _viewModel1 = new ViewModel1();
            _viewModel1.Event1 += ViewModel1_Event1;

            _viewModel2 = new ViewModel1();
            _viewModel2.Event1 += ViewModel2_Event1;

            _viewModel3 = new ViewModel1();
            _viewModel3.Event1 += ViewModel3_Event1;

            _viewModel4 = new ViewModel1();
            _viewModel4.Event1 += ViewModel4_Event1;
        }

        #endregion

        #region Navigation Methods

        private void Navigate_View1()
        {
            if (_view != null)
            {
                _view.Close();
            }

            _view = new View1();
            _view.Closing += View1_Closing;
            _view.DataContext = _viewModel1;
            _view.Show();
        }

        private void Navigate_View2()
        {
            if (_view != null)
            {
                _view.Close();
            }

            _view = new View2();
            _view.Closing += View2_Closing;
            _view.DataContext = _viewModel2;
            _view.Show();
        }

        private void Navigate_View3()
        {
            if (_view != null)
            {
                _view.Close();
            }

            _view = new View3();
            _view.Closing += View3_Closing;
            _view.DataContext = _viewModel3;
            _view.Show();
        }

        private void Navigate_View4()
        {
            if (_view != null)
            {
                _view.Close();
            }

            _view = new View4();
            _view.Closing += View4_Closing;
            _view.DataContext = _viewModel4;
            _view.Show();
        }

        #endregion

        #region App Event Methods

        private void App_Startup(object sender, StartupEventArgs e)
        {
            Navigate_View1();
        }

        #endregion

        #region LogicModel Event Methods

        private void LogicModel_Event1(object? sender, EventArgs e)
        {
        }

        #endregion

        #region ViewModel1 Event Methods

        private void ViewModel1_Event1(object? sender, EventArgs e)
        {
        }

        private void View1_Closing(object? sender, CancelEventArgs e)
        {
            if (_view != null)
            {
                _view.Close();
            }
        }

        #endregion

        #region ViewModel2 Event Methods

        private void ViewModel2_Event1(object? sender, EventArgs e)
        {
        }

        private void View2_Closing(object? sender, CancelEventArgs e)
        {
            if (_view != null)
            {
                _view.Close();
            }
        }

        #endregion

        #region ViewModel3 Event Methods

        private void ViewModel3_Event1(object? sender, EventArgs e)
        {
        }

        private void View3_Closing(object? sender, CancelEventArgs e)
        {
            if (_view != null)
            {
                _view.Close();
            }
        }

        #endregion

        #region ViewModel4 Event Methods

        private void ViewModel4_Event1(object? sender, EventArgs e)
        {
        }

        private void View4_Closing(object? sender, CancelEventArgs e)
        {
            if (_view != null)
            {
                _view.Close();
            }
        }

        #endregion
    }
}
