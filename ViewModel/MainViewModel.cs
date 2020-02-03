using mvvm2.DataAccess;
using mvvm2.Extensions;
using mvvm2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mvvm2.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private RelayCommand loadCommand;

        private DataItemRepository dataItemRepository;

        public ObservableCollection<DataItem> DataItems { get => dataItemRepository.DataItems; }
        public MainViewModel()
        {
            dataItemRepository = new DataItemRepository();
        }

        public ICommand LoadCommand
        {
           get
            {
                if (this.loadCommand == null)
                    this.loadCommand = new RelayCommand(x => OnRequestLoadData());

                return this.loadCommand;
            }
        }

        private void OnRequestLoadData()
        {
            dataItemRepository.GetData();

        }
    }
}
