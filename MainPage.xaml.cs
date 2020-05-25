using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWPMusicLibrary.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.Playlists;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPMusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<MainMenuItem> MainMenuItems;
        private ObservableCollection<Album> Albums;

        string[] extensions = new string[] { ".wma", ".mp3", ".mp2", ".aac", ".adt", ".adts", ".m4a" };

        public static MainPage Current;

        public MainPage()
        {
            this.InitializeComponent();
            Current = this;

            // POPULATE SPLITVIEW PANE
            MainMenuItems = new List<MainMenuItem>();
            MainMenuItems.Add(new MainMenuItem { IconFile = "Assets/Icons/home.png", Category = MainMenuCategory.Home });
            MainMenuItems.Add(new MainMenuItem { IconFile = "Assets/Icons/create.png", Category = MainMenuCategory.CreatePlayList });
            MainMenuItems.Add(new MainMenuItem { IconFile = "Assets/Icons/delete.png", Category = MainMenuCategory.DeletePlayList });
            MainMenuItems.Add(new MainMenuItem { IconFile = "Assets/Icons/mylibrary.png", Category = MainMenuCategory.AudioBooks });
            Title.Text = "Welcome To Music Library!";
            MainMenuItemsListView.SelectedItem = MainMenuCategory.Home;

            // POPULATE SPLITVIEW CONTENT WITH ALL AVAILABLE MUSIC ALBUM FOLDERS
            Albums = new ObservableCollection<Album>();
            AlbumManager.GetAllAlbumsAsync(Albums);

        }

        public void MainMenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MainMenuItem)e.ClickedItem;
            if (menuItem.Category.Equals(MainMenuCategory.Home))
            {
                Title.Text = "All Music";
                // POPULATE SPLITVIEW CONTENT WITH ALL AVAILABLE MUSIC ALBUM FOLDERS
                Albums = new ObservableCollection<Album>();
                AlbumManager.GetAllAlbumsAsync(Albums);
            }
            else if (menuItem.Category.Equals(MainMenuCategory.CreatePlayList))
            {
                this.Frame.Navigate(typeof(CreatePlayList));
            }
            else if (menuItem.Category.Equals(MainMenuCategory.DeletePlayList))
            {
                this.Frame.Navigate(typeof(DeletePlayList));
                //((Frame)MySplitView.Content).Navigate(typeof(CreatePlayList));
            }
            else if (menuItem.Category.Equals(MainMenuCategory.AudioBooks))
            {
                this.Frame.Navigate(typeof(AudioBooks));
             /*   Title.Text = menuItem.FilterCategory.ToString();
                AudioManager.GetAudiosbyAudience(Audios, menuItem.FilterCategory);
                BackButton.Visibility = Visibility.Visible; */
            }
        }

        public async void AlbumGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var album = (Album)e.ClickedItem;
            StorageFile storageFile = album.AudioFiles;
            IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.Read);
            MyMediaElement.SetSource(stream, storageFile.FileType);
            MyMediaElement.Play();

        }


    }
}
