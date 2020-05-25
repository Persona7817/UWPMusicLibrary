using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPMusicLibrary.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPMusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AudioBooks : Page
    {
        private List<MainMenuItem> MainMenuItems;
        private ObservableCollection<Audio> Audios;
        public AudioBooks()
        {
            this.InitializeComponent();
            Audios = new ObservableCollection<Audio>();
            AudioManager.GetFullLibrary(Audios);

            MainMenuItems = new List<MainMenuItem>();
           // MainMenuItems.Add(new MainMenuItem { FilterCategory = Audience.Adults, IconFile = $"Assets/Icons/Adults.jpeg" });
            MainMenuItems.Add(new MainMenuItem { FilterCategory = Audience.KidsandTeens, IconFile = $"Assets/Icons/KidsandTeens.jpg" });

            BackButton.Visibility = Visibility.Collapsed;

        }
    

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MainMenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.FilterCategory.ToString();
            AudioManager.GetAudiosbyAudience(Audios, menuItem.FilterCategory);
            BackButton.Visibility = Visibility.Visible;
        }
        private void AudioGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var audio = (Audio)e.ClickedItem;
            MyMediaElement.Source = new Uri(BaseUri, audio.AudioFile);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AudioManager.GetFullLibrary(Audios);
            CategoryTextBlock.Text = "My Library";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}


