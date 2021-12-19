﻿using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using StoryBuilder.DAL;
using StoryBuilder.Models;
using StoryBuilder.Models.Tools;
using StoryBuilder.Services.Dialogs;

namespace StoryBuilder.ViewModels
{
    public class UnifiedVM : ObservableRecipient
    {
        //Since the original menu was designed with the shell in mind we need to call some commands on the ShellVM so it can be done correctly
        ShellViewModel shell = Ioc.Default.GetService<ShellViewModel>();
        public PreferencesModel UserPrefs = GlobalData.Preferences;

        private int _selectedRecentIndex;
        public int SelectedRecentIndex
        {
            get => _selectedRecentIndex;
            set { SetProperty(ref _selectedRecentIndex, value); }
        }

        private string _selectedTemplate;
        public string SelectedTemplate
        {
            get => _selectedTemplate;
            set { SetProperty(ref _selectedTemplate, value); }
        }
        private string _projectName;
        public string ProjectName
        {
            get => _projectName;
            set { SetProperty(ref _projectName, value); }
        }

        private string _ProjectPath;
        public string ProjectPath
        {
            get => _ProjectPath;
            set { SetProperty(ref _ProjectPath, value); }
        }

        /// <summary>
        /// This makes the UI one consistant color
        /// </summary>
        private Microsoft.UI.Xaml.Media.SolidColorBrush _adjustmentColor;
        public Microsoft.UI.Xaml.Media.SolidColorBrush AdjustmentColor
        {
            get => _adjustmentColor;
            set { SetProperty(ref _adjustmentColor, value); }
        }

        private ListBoxItem _currentTab;
        public ListBoxItem CurrentTab
        {
            get => _currentTab;
            set { SetProperty(ref _currentTab, value); }

        }

        public UnifiedVM()
        {
            SelectedRecentIndex = -1;
            ProjectName = string.Empty;
            PreferencesModel prefs = GlobalData.Preferences;
            ProjectPath = prefs.ProjectDirectory;
        }

        public UnifiedMenuPage.UpdateContentDelegate UpdateContent;

        public void Hide()
        {
            shell.CloseUnifiedCommand.Execute(null);
        }

        /// <summary>
        /// This controls the frame and sets it content.
        /// </summary>
        /// <returns></returns>
        private StackPanel _contentView = new();
        public StackPanel ContentView
        {
            get => _contentView;
            set { SetProperty(ref _contentView, value); }
        }

        /// <summary>
        /// This changes the content of the frame in unifiedUI.xaml depending on the selected option on the sidebar.
        /// </summary>
        public void SidebarChange(object sender, SelectionChangedEventArgs e)
        {
            ContentView.Children.Clear();
            UpdateContent();
        }

        public async void LoadStory()
        {
            await shell.OpenFile(); //Calls the open file in shell so it can load the file
            Hide();
        }


     
        /// <summary>
        /// Loads a story from the recents page
        /// </summary>
        public async void LoadRecentStory()
        {
            switch (SelectedRecentIndex)
            {
                case 0: await shell.OpenFileFromPath(GlobalData.Preferences.LastFile1); UpdateRecents(GlobalData.Preferences.LastFile1); break;
                case 1: await shell.OpenFileFromPath(GlobalData.Preferences.LastFile2); UpdateRecents(GlobalData.Preferences.LastFile2); break;
                case 2: await shell.OpenFileFromPath(GlobalData.Preferences.LastFile3); UpdateRecents(GlobalData.Preferences.LastFile3); break;
                case 3: await shell.OpenFileFromPath(GlobalData.Preferences.LastFile4); UpdateRecents(GlobalData.Preferences.LastFile4); break;
                case 4: await shell.OpenFileFromPath(GlobalData.Preferences.LastFile5); UpdateRecents(GlobalData.Preferences.LastFile5); break;
            }
            if (SelectedRecentIndex != -1)
            {
                Hide();
            }
        }

        /// <summary>
        /// Makes project and then closes UnifiedMenu
        /// </summary>
        public async void MakeProject()
        {
            //Checks for validity
            //TODO: check if path is valid (Not illegal) 
            if (!String.IsNullOrWhiteSpace(SelectedTemplate) && !String.IsNullOrWhiteSpace(ProjectPath) && !String.IsNullOrWhiteSpace(ProjectName))
            {
                await shell.UnifiedNewFile(this);
                UpdateRecents(System.IO.Path.Combine(ProjectPath, ProjectName));
                Hide();
            }
        }

        /// <summary>
        /// This updates prefs.RecentFiles1 through 5
        /// </summary>
        public async void UpdateRecents(string Path)
        {
            if (Path != GlobalData.Preferences.LastFile1 && Path != GlobalData.Preferences.LastFile2 && Path != GlobalData.Preferences.LastFile3 && Path != GlobalData.Preferences.LastFile4 && Path != GlobalData.Preferences.LastFile5)
            {
                GlobalData.Preferences.LastFile5 = GlobalData.Preferences.LastFile4;
                GlobalData.Preferences.LastFile4 = GlobalData.Preferences.LastFile3;
                GlobalData.Preferences.LastFile3 = GlobalData.Preferences.LastFile2;
                GlobalData.Preferences.LastFile2 = GlobalData.Preferences.LastFile1;
                GlobalData.Preferences.LastFile1 = Path;
            }
            else //This shuffle the file used to the top
            {
                List<String> NewRecents = new();
                if (Path == GlobalData.Preferences.LastFile2) { NewRecents = new List<string>() { GlobalData.Preferences.LastFile2, GlobalData.Preferences.LastFile1, GlobalData.Preferences.LastFile3, GlobalData.Preferences.LastFile4, GlobalData.Preferences.LastFile5 }; }
                else if (Path == GlobalData.Preferences.LastFile3) { NewRecents = new List<string>() { GlobalData.Preferences.LastFile3, GlobalData.Preferences.LastFile1, GlobalData.Preferences.LastFile2, GlobalData.Preferences.LastFile4, GlobalData.Preferences.LastFile5 }; }
                else if (Path == GlobalData.Preferences.LastFile4) { NewRecents = new List<string>() { GlobalData.Preferences.LastFile4, GlobalData.Preferences.LastFile1, GlobalData.Preferences.LastFile2, GlobalData.Preferences.LastFile3, GlobalData.Preferences.LastFile5 }; }
                else if (Path == GlobalData.Preferences.LastFile5) { NewRecents = new List<string>() { GlobalData.Preferences.LastFile5, GlobalData.Preferences.LastFile1, GlobalData.Preferences.LastFile2, GlobalData.Preferences.LastFile3, GlobalData.Preferences.LastFile4 }; }
                
                if (NewRecents.Count > 0)
                {
                    GlobalData.Preferences.LastFile1 = NewRecents[0];
                    GlobalData.Preferences.LastFile2 = NewRecents[1];
                    GlobalData.Preferences.LastFile3 = NewRecents[2];
                    GlobalData.Preferences.LastFile4 = NewRecents[3];
                    GlobalData.Preferences.LastFile5 = NewRecents[4];
                }
            }

            PreferencesIO loader = new(GlobalData.Preferences, GlobalData.RootDirectory);
            await loader.UpdateFile();
        }

    }
}