﻿using Magic8Ball.Data;
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
        private int _xpos;
        private int _ypos;
        public ICommand onSentenceDraw;
        private Ball b = new Ball();

        public MainWindowViewModel()
        {
            onSentenceDraw = new RelayCommand(OnSentenceDraw, o => true);
        }

        public void OnSentenceDraw(object o)
        {
            DrawnSentece = b.DrawSentence();
        }

        private Point p = new Point(50, 50);
        public int Xpos
        {
            get
            {
                return _xpos;
            }   
            set
            {
                _xpos = value;
                NotifyPropertyChanged("xpos");
            }
        }

        public string DrawnSentece {
            get => _drawnSentece;
            set
            {
                _drawnSentece = value;
                NotifyPropertyChanged("DrawnSentence");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
