using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core
{
    //Responsible for handling video collections
    public class VideoManager
    {
        private List<Video> videos;
        private int currentId;

        public VideoManager()
        {
            videos = new List<Video>();
            currentId = 0;
        }

        public void AddVideo(string title, Genre genre)
        {
            Video v = new Video(title, genre)
            {
                ID = this.currentId++
            };
            videos.Add(v);
        }   

        // Replaces an old video with a new one based on ID
        // Returns true if the update was successfull, false otherwise.
        public bool UpdateVideo(int id, string newTitle, Genre newGenre)
        {
            Video vidToUpdate = videos.FirstOrDefault(v => v.ID == id);
            if (vidToUpdate == null)
            {
                return false;
            }

            vidToUpdate.Title = newTitle;
            vidToUpdate.VideoGenre = newGenre;
            return true;
        }

        public string ListVideos()
        {
            StringBuilder sb = new StringBuilder();

            int i = 1;
            foreach (Video item in videos)
            {
                sb.Append(String.Format("Video #{0}:\n", i));
                sb.Append(String.Format(item.ToString()));
                i++;
            }

            return sb.ToString();
        }

        public bool DeleteVideo(int id)
        {

            Video vidToDelete = videos.FirstOrDefault(v => v.ID == id);
            if (vidToDelete == null)
            {
                return false;
            }

            videos.Remove(vidToDelete);
            return true;
        }

        public string FindVideo(int id)
        {

            Video vid = videos.FirstOrDefault(v => v.ID == id);

            if (vid == null)
            {
                string notSuccessfull = "Unable to find video!";
                return notSuccessfull;
            }
            else
            {
                return vid.ToString();
            }
        }

        private void WriteVideoInformation(Video video)
        {
            Console.WriteLine("\tID: {0}", video.ID);
            Console.WriteLine("\tTitle: {0}", video.Title);
            Console.WriteLine("\tGenre: {0}", video.VideoGenre.ToString());
        }
    }
}