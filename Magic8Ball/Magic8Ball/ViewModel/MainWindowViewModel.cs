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
        public ICommand WindowCloseCommand { get; set; }
        private Ball b = new Ball();
        private string trEn;
        private string trVis;


        public MainWindowViewModel()
        {
            OnSentenceButtonClick = new RelayCommand(OnSentenceDraw, o => true);
            var w = new WindowCloseCmd();
            WindowCloseCommand = new RelayCommand(w.Execute, w.CanExecute);
            TrEn = "false";
            TrVis = "Hidden";  
        }
        
        public void OnSentenceDraw(object o)
        {
            DrawnSentence = b.DrawSentence();
            TrEn = "True";
            TrVis = "Visible";
        }

        public string DrawnSentence
        {
            get
            {
                return _drawnSentece;
            }
            set
            {
                NotifyPropertyChanged("DrawnSentence");
                _drawnSentece = value;
               // MessageBox.Show("Drawn");
            }
        }

        public string TrVis
        {
            get => trVis;
            set
            {
                NotifyPropertyChanged("TrVis");
                trVis = value;
            }
        }

        public string TrEn { get => trEn;
            set
            {
                NotifyPropertyChanged("TrEn");
                trEn = value;
            }
        }

        //for future pmv usage

        class WindowCloseCmd : ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged
            {
                add { }
                remove { }
            }

            public void Execute(object wnd)
            {
                if (wnd is Window) ((Window)wnd).Close();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
