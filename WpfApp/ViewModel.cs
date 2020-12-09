using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Browser;
using WpfApp.Annotations;

namespace WpfApp
{
    public sealed class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Namespace> _namespace = new ObservableCollection<Namespace>();
        public ObservableCollection<Namespace> namespaces
        {
            get => _namespace;
            set
            {
                _namespace = value;
                OnPropertyChanged(nameof(namespaces));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoadCommand loadCommand { get; set; }

        public ViewModel()
        {
            loadCommand = new LoadCommand(renewList);
        }

        private void renewList(string path)
        {
            namespaces = new ObservableCollection<Namespace>(new DllTreeProvider(path).getTree());
        }
    }
}
