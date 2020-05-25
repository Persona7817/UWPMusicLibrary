using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using System.Text;
using UWPMusicLibrary.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Search;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playlists;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using static UWPMusicLibrary.MainPage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPMusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class CreatePlayList : Page
    {

        private MainPage rootPage = MainPage.Current;

        string[] extensions = new string[] { ".wma", ".mp3", ".mp2", ".aac", ".adt", ".adts", ".m4a" };

        Playlist playlist = new Playlist();

        private ObservableCollection<PlaylistFiles> PlaylistFilesList;

        public CreatePlayList()
        {
            this.InitializeComponent();
            PlaylistFilesList = new ObservableCollection<PlaylistFiles>();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void BrowseMusicLibrary_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
            foreach (string extension in extensions)
            {
                picker.FileTypeFilter.Add(extension);
            }

            IReadOnlyList<StorageFile> files = await picker.PickMultipleFilesAsync();
            PlaylistFilesList.Clear();
            var fileList = new List<PlaylistFiles>();
            Playlist playlist = new Playlist();

            if (files.Count > 0)
            {
                foreach (StorageFile file in files)
                {
                        playlist.Files.Add(file);
                        // Display User Selected music files in a list view in the UI
                        fileList.Add(new PlaylistFiles(file, file.Path));
                }
            }
            foreach (var file in fileList)
            {
                PlaylistFilesList.Add(file);
            }
         }

        private async void ButtonSavePlayList_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = KnownFolders.MusicLibrary;
            string name = this.PlaylistName.Text;
            NameCollisionOption collisionOption = NameCollisionOption.GenerateUniqueName;
            PlaylistFormat format = PlaylistFormat.WindowsMedia;

            try
            {
                if(PlaylistName == null || PlaylistName.Text == "")
                {
                    MessageDialog showDialog = new MessageDialog("Please Enter a Playlist Name");
                    var result = await showDialog.ShowAsync();
                }
                else if(PlaylistFilesList.Count == 0)
                {
                    MessageDialog showDialog = new MessageDialog("Please Select Files To Save To Playlist");
                    var result = await showDialog.ShowAsync();
                }
                else if (PlaylistFilesList.Count > 0) {
                    StorageFile savedFile = await playlist.SaveAsAsync(folder, name, collisionOption, format);

                    MessageDialog showDialog = new MessageDialog("Playlist Saved!");
                    var result = await showDialog.ShowAsync();
                    PlaylistFilesList.Clear();
                    this.PlaylistName.Text = "";
                }
            }
            catch (Exception error)
            {
                MessageDialog showDialog = new MessageDialog(error.ToString());
                var result = await showDialog.ShowAsync();
            }

        }

    }
       

    
}
