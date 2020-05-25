using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMusicLibrary.Model
{
    public static class AudioManager
    {
        public static void GetFullLibrary(ObservableCollection<Audio> audios)
        {
            var Allaudios = getAudios();
            audios.Clear();
            Allaudios.ForEach(A => audios.Add(A));
        }
        public static void GetAudiosbyAudience(ObservableCollection<Audio> audios, Audience audience)
        {
            var Allaudios = getAudios();
            var filteredAudios = Allaudios.Where(audio => audio.AudioAudience == audience).ToList();
            audios.Clear();
            filteredAudios.ForEach(audio => audios.Add(audio));
        }
        private static List<Audio> getAudios()
        {
            var audios = new List<Audio>();
            audios.Add(new Audio(Category.AudioBooks, Name.Androcles_and_the_Lion, Audience.KidsandTeens, Genre.AesopsFables));
            audios.Add(new Audio(Category.AudioBooks, Name.How_Peace_and_Love_came_to_the_Woods, Audience.KidsandTeens, Genre.AesopsFables));
            audios.Add(new Audio(Category.AudioBooks, Name.The_Boy_who_cried_Wolf, Audience.KidsandTeens,Genre.AesopsFables));
            audios.Add(new Audio(Category.AudioBooks, Name.The_Grasshopper_and_the_Ants, Audience.KidsandTeens, Genre.AesopsFables));
            audios.Add(new Audio(Category.AudioBooks, Name.The_Hare_and_the_Tortoise, Audience.KidsandTeens, Genre.AesopsFables));
            audios.Add(new Audio(Category.AudioBooks, Name.The_Oak_and_the_Reed, Audience.KidsandTeens, Genre.AesopsFables));
            audios.Add(new Audio(Category.AudioBooks, Name.The_Rat_and_the_Elephant, Audience.KidsandTeens,Genre.AesopsFables));
            audios.Add(new Audio(Category.AudioBooks, Name.The_Town_Mouse_and_the_Country_Mouse, Audience.KidsandTeens, Genre.AesopsFables));
            audios.Add(new Audio(Category.AudioBooks, Name.The_Two_Frogs_and_the_Well, Audience.KidsandTeens, Genre.AesopsFables));
           // audios.Add(new Audio(Category.AudioBooks, Name.Die_to_Live, Audience.Adults, Genre.Spirituality));
           // audios.Add(new Audio(Category.AudioBooks, Name.Science_of_the_Soul, Audience.Adults, Genre.Spirituality));
            /*audios.Add(new Audio(Category.AudioBooks, Name.Essentialism, Audience.Adults, Genre.SelfHelp));
            audios.Add(new Audio(Category.AudioBooks, Name.Mindset, Audience.Adults, Genre.SelfHelp));*/
            

            return audios;
        } 
    }
}
