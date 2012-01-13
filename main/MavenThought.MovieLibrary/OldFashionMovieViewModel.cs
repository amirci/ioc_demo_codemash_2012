using System.ComponentModel;

namespace MavenThought.MovieLibrary
{
    public class OldFashionMovieViewModel : IMovieViewModel
    {
        private string _title;

        private string _description;

        public virtual string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public virtual string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };
    }
}