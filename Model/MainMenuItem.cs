using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
 * This class contains the main menu split view pane categories
 */

namespace UWPMusicLibrary.Model
{
    public enum MainMenuCategory
    {

        Home = 1,
        Search = 2,
        [Description("Create PlayList")]
        CreatePlayList = 3,
        [Description("Audio Books")]
        AudioBooks = 4,
        [Description("Clear playList")]
        ClearPlayList = 5,
        [Description("Delete playList")]
        DeletePlayList = 6
    }

    public class MainMenuItem
    {
        public string IconFile { get; set; }
        public MainMenuCategory Category {get;set;}
        public Audience FilterCategory { get; set; }
    }
}
