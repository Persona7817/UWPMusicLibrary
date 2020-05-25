using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Media.Playlists;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace UWPMusicLibrary.Model
{
    public static class AlbumManager
    {
        public static async void GetAllAlbumsAsync(ObservableCollection<Album> albums)
        {
            Windows.Storage.StorageFolder musicFolder = KnownFolders.MusicLibrary;
            albums.Clear();
            await RetrieveFilesInFolders( albums , musicFolder);
        }

        private async static Task RetrieveFilesInFolders(ObservableCollection<Album> list, StorageFolder parent)
        {
            foreach (var item in await parent.GetFilesAsync())
            {
                Windows.Storage.FileProperties.MusicProperties properties = await item.Properties.GetMusicPropertiesAsync();

                if (item.FileType == ".mp3" || item.FileType == ".wma"
                        || item.FileType == ".mp3" || item.FileType == ".mp2" || item.FileType == ".aac"
                        || item.FileType == ".adt" || item.FileType == ".adts" || item.FileType == ".m4a" ||
                        item.FileType == ".m3u" || item.FileType == ".zpl")
                {
                    list.Add(new Album(parent.DisplayName, item, properties.Artist));
                }
                else if (item.FileType == ".wpl" || item.FileType == ".zpl" || item.FileType == ".m3u")
                {
                    Playlist playlist = await PickPlaylistAsync(item);
                    if (playlist != null)
                    {
                        foreach (StorageFile file in playlist.Files)
                        {
                            list.Add(new Album(item.DisplayName + "/" + file.Name, file, properties.Artist));
                        }
                    }
                }
            }

            foreach (var folder in await parent.GetFoldersAsync())
            {
                await RetrieveFilesInFolders(list, folder);

            }

        }


        /// <summary> 
        /// Picks and loads a playlist. 
        /// </summary> 
        async static Task<Playlist> PickPlaylistAsync(StorageFile file)
        {
            try
            {
                return await Playlist.LoadAsync(file);
            }
            catch (Exception ex)
            {
                string error = ex.StackTrace;
                return null;
            }
        }


    }
}
