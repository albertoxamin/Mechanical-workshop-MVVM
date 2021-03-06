﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;
using System.ComponentModel;    
using System.Windows.Controls;
using Meccanici.View;

namespace Meccanici.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Tab> tabs;
        public ObservableCollection<Tab> Tabs
        {
            get { return tabs; }
            set
            {
                tabs = value;
                OnPropertyChanged("Tabs");
            }
        }

        private Tab selectedTab;
        public Tab SelectedTab
        {
            get { return selectedTab; }
            set
            {
                selectedTab = value;
                OnPropertyChanged("SelectedTab");
                LoadFrame();
            }
        }

        private Page tabPage;
        public Page TabPage
        {
            get { return tabPage; }
            set
            {
                tabPage = value;
                OnPropertyChanged("TabPage");
            }
        }

        void LoadFrame()
        {
            switch (SelectedTab.Title)
            {
                case "Clienti":
                    TabPage = new ClientiView();
                    break;
                case "Automobili":
                    TabPage = new AutoView();
                    break;
                case "Riparazioni":
                    TabPage = new FixesView();
                    break;
                case "Dipendenti":
                    TabPage = new ClientiView(true);
                    break;
                case "Impostazioni":
                    TabPage = new SettingsView();
                    break;
                default:
                    TabPage = new Page();
                    break;
            }
        }

        public HomeViewModel()
        {
            Tabs = new ObservableCollection<Tab>();
            Tabs.Add(new Tab() { Title = "Clienti",     Icon = ""});
            Tabs.Add(new Tab() { Title = "Automobili",  Icon = ""});
            Tabs.Add(new Tab() { Title = "Riparazioni", Icon = ""});
            Tabs.Add(new Tab() { Title = "Dipendenti",  Icon = ""});
            //Tabs.Add(new Tab() { Title = "Impostazioni",Icon = "" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class Tab
    {
        public string Title
        {
            get; set;
        }
        public string Image
        {
            get
            {
                return "/Assets/" + Title + ".png";
            }
        }
        public string Icon
        {
            get; set;
        }
        public Page Page
        {
            get;set;
        }
    }
}
