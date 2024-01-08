using _0811_mvvm_rgb.Models;
using mvvm_notebook.commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _0811_mvvm_rgb.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Color> ColorCollection = new ObservableCollection<Color>();
        byte R, G, B, A;
        MainWindow _view;
        public MainViewModel(MainWindow view)
        {
            _view = view;
        }
        public byte Red
        {
            get
            {
                return R;
            }
            set
            {
                R = value;
                OnPropertyChanged(nameof(Red));
            }
        }
        public byte Green
        {
            get
            {
                return G;
            }
            set
            {
                G = value;
                OnPropertyChanged(nameof(Green));
            }
        }
        public byte Blue
        {
            get
            {
                return B;
            }
            set
            {
                B = value;
                OnPropertyChanged(nameof(Blue));
            }
        }
        public byte Alpha
        {
            get
            {
                return A;
            }
            set
            {
                A = value;
                OnPropertyChanged(nameof(Alpha));
            }
        }

        private DelegateCommand AddCommand;
        public ICommand AddColor
        {
            get
            {
                if (AddCommand == null)
                {
                    AddCommand = new DelegateCommand(Add_Execute, Add_CanExecute);
                }
                return AddCommand;
            }
        }
        private void Add_Execute(object obj)
        {

            ListBoxItem NewColor = new ListBoxItem();
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            TextBlock color = new TextBlock();
            color.Text = Convert.ToString((Color.FromArgb(Alpha, Red, Green, Blue)));
            ColorCollection.Add((Color.FromArgb(Alpha, Red, Green, Blue)));
            color.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(color.Text));
            Button button = new Button();
            button.Content = "Delete";
            button.CommandParameter = NewColor;
            button.Command = DeleteColor;
            button.CommandTarget = _view.ColorList;
            grid.Children.Add(color);
            grid.Children.Add(button);
            button.Margin = new Thickness(5);
            button.Padding = new Thickness(5);
            color.Margin = new Thickness(5);
            color.Padding = new Thickness(5);
            Grid.SetColumn(color, 0);
            Grid.SetColumn(button, 1);
            NewColor.Content = grid;
            _view.ColorList.Items.Add(NewColor);
        }

        private bool Add_CanExecute(object obj)
        {
            return !ColorCollection.Contains((Color.FromArgb(Alpha, Red, Green, Blue)));
        }
        private DelegateCommand DeleteCommand;
        public ICommand DeleteColor
        {
            get
            {
                if (DeleteCommand == null)
                {
                    DeleteCommand = new DelegateCommand(Delete_Execute, Delete_CanExecute);
                }
                return DeleteCommand;
            }
        }
        private void Delete_Execute(object obj)
        {
            _view.ColorList.Items.Remove((ListBoxItem)obj);
        }

        private bool Delete_CanExecute(object obj)
        {
            return true;
        }
    }
}
