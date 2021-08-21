﻿using CommunityToolkit.Mvvm.DependencyInjection;
using StoryBuilder.ViewModels.Tools;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StoryBuilder.Services.Dialogs.Tools
{
    public sealed partial class PreferencesDialog
    {
        public PreferencesViewModel PreferencesVm => Ioc.Default.GetService<PreferencesViewModel>();
        public PreferencesDialog()
        {
            InitializeComponent();
            DataContext = PreferencesVm;
        }
    }
}
