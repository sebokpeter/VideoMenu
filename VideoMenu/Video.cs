namespace VideoMenu
{
    public enum Genre { Action, Adventure}

    class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Genre VideoGenre { get; set; }

        public Video(string title, Genre genre)
        {
            this.Title = title;
            this.VideoGenre = genre;
        }
    }
}
