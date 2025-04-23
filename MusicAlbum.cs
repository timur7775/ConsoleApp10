using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class MusicAlbum : Media
    {
        public string Artist { get; set; }
        public int TrackCount { get; set; }
        public MusicAlbum(string title, string author, int yearPublished, string artist, int trackCount)
            : base(title, author, yearPublished)
        {
            Artist = artist;
            TrackCount = trackCount;
        }
        public override string ToString() =>
            $"Music Album: {Title}, Artist: {Artist}, Year: {YearPublished}, Tracks: {TrackCount}, Available: {IsAvailable}";
    }
    interface IMediaManager<T> where T : Media
    {
        void Add(T item);
        bool Remove(string title);
        T FindByTitle(string title);
        IEnumerable<T> FilterByYear(int year);
        IEnumerable<T> GetAllAvailable();
    }
}
