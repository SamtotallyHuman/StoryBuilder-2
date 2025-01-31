﻿using System.ComponentModel;
using Microsoft.UI.Xaml;

namespace StoryBuilder.ViewModels;

public class TreeViewSelection : DependencyObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public object SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set
        {
            SetValue(SelectedItemProperty, value);
            NotifyPropertyChanged("SelectedItem");
        }
    }

    // Use a DependencyProperty as the backing store for SelectedItem
    //TODO: Can this be made more readable?
    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(object),
            typeof(TreeViewSelection), new PropertyMetadata(null));

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}