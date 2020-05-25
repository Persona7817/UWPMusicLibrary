using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;

namespace UWPMusicLibrary.Model
{
    public enum Category
    {
        AudioBooks,
        Talks
    }
    public enum Name
    {
        Androcles_and_the_Lion,
        Die_to_Live,
        Essentialism,
        How_Peace_and_Love_came_to_the_Woods,
        Mindset,
        Science_of_the_Soul,
        The_Boy_who_cried_Wolf,
        The_Grasshopper_and_the_Ants,
        The_Hare_and_the_Tortoise,
        The_Oak_and_the_Reed,
        The_Rat_and_the_Elephant,
        The_Town_Mouse_and_the_Country_Mouse,
        The_Two_Frogs_and_the_Well
    }
    public enum Audience
    {
        Adults,
        KidsandTeens,
    }
    public enum Genre
    {
        AesopsFables,
        SelfHelp,
        Spirituality,
    }
    public class Audio
    {
        
        public Name AudioName { get; set; }
        public Audience AudioAudience { get; set; }
        public Genre AudioGenre { get; set; }
        public Category AudioCategory { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public Audio(Category category, Name name, Audience audience, Genre genre)
        {
            AudioCategory = category;
            AudioName = name;
            AudioAudience = audience;
            AudioGenre = genre;
            ImageFile = $"/Assets/Images/{category}/{audience}/{genre}/{name}.jpg";
            if (name == Name.Die_to_Live || name == Name.Science_of_the_Soul) 
            {
                AudioFile = $"/Assets/Audio/{category}/{audience}/{genre}/{name}.m4a";
            }
            /*else if(name == Name.Essentialism || name == Name.Mindset)
            {
                AudioFile = $"/Assets/Audio/{category}/{audience}/{genre}/{name}.aax";
            }*/
            else
            {
                AudioFile = $"/Assets/Audio/{category}/{audience}/{genre}/{name}.mp3";
            }
        }
    }
}
