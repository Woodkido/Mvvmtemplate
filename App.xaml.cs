using mvvm2.View;
using mvvm2.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace mvvm2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            MainView mainView = new MainView();
            MainViewModel mainViewModel = new MainViewModel();

            mainView.DataContext = mainViewModel;
            mainView.Show();
        }
    }
}
