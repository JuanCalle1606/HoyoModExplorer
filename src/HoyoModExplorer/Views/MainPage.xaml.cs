﻿using HoyoModExplorer.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace HoyoModExplorer.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
