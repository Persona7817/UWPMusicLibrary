using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

/*
 * This class enables the creation of Playlist objects 
 */

namespace UWPMusicLibrary.Model
{
    public class PlaylistFiles
    {
        public StorageFile File { get; set; }
        public string FileName { get; set; }

        public PlaylistFiles(StorageFile file, string fileName)
        {
            this.File = file;
            this.FileName = fileName;
        }
    }
}
