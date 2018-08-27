using System.Text;

namespace VideoMenu.Core.Entity
{
    public enum Genre { Action, Adventure}

    public class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Genre VideoGenre { get; set; }

        public Video(string title, Genre genre)
        {
            this.Title = title;
            this.VideoGenre = genre;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("\tID: {0} ", ID));
            sb.Append(string.Format("\tTitle: {0} ", Title));
            sb.Append(string.Format("\tGenre: {0} ", VideoGenre));

            return sb.ToString();
        }
    }
}
