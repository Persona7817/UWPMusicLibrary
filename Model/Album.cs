using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

/*
 * 
 * Album class maintains the details of every album 
 */

namespace UWPMusicLibrary.Model
{

    public class Album
    {
        public string AlbumName { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public string ImageFileDefault { get; set; }
        public StorageFile AudioFiles { get; set; }
        public string Artist { get; set; }



        public Album(string name, StorageFile audioFiles, string artist)
        {
            this.AlbumName = name;
            this.AudioFiles = audioFiles;
            this.Artist = artist;
            this.ImageFile = $"/Assets/Audio/{name}.png";
            this.ImageFile = $"/Assets/Images/{name}.png";
            this.ImageFileDefault = $"/Assets/Images/songLogo.png";
        }


    }
}
