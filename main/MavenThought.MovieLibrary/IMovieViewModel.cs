using System.ComponentModel;

namespace MavenThought.MovieLibrary
{
    public interface IMovieViewModel : INotifyPropertyChanged
    {
        string Title { get; set; }
        string Description { get; set; }
    }
}