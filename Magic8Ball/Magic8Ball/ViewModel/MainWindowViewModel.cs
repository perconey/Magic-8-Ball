using Magic8Ball.Data;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace Magic8Ball.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _drawnSentece;
        public ICommand OnSentenceButtonClick { get; set; }
        private Ball b = new Ball();

        public MainWindowViewModel()
        {
            OnSentenceButtonClick = new RelayCommand(OnSentenceDraw, o => true);
        }

        public void OnSentenceDraw(object o)
        {
            DrawnSentence = b.DrawSentence();
        }

        private Point p = new Point(50, 50);

        public string DrawnSentence
        {
            get
            {
                return _drawnSentece;
            }
            set
            {
                _drawnSentece = value;
                NotifyPropertyChanged("DrawnSentence");
                MessageBox.Show("Drawn");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
