﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace App1
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();
            EraseCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });
            SaveCommand = new Command(() =>
            {
                AllNotes.Add(theNote);
                TheNote = string.Empty;
            });
        }

        public ObservableCollection<string> AllNotes { get; set; } 

        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
    }
}
