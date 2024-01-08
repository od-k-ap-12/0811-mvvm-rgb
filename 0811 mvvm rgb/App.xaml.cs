using _0811_mvvm_rgb.ViewModels;
using _0811_mvvm_rgb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _0811_mvvm_rgb
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow view = new MainWindow();
            MainViewModel viewModel = new MainViewModel(view);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
