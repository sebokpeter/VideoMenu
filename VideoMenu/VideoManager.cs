using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VideoMenu
{
    //Responsible for handling video collections
    class VideoManager
    {
        private List<Video> videos;

        public VideoManager()
        {
            videos = new List<Video>();
        }

        public void AddVideo()
        {
            Console.WriteLine("Adding a video...");
            Console.WriteLine("Enter the title of the video: ");
            string title = Console.ReadLine();
            Console.WriteLine("Select the genre of the video: ");
            Genre genre = SelectGenre();

            int id = videos.Count + 1;

            Video vid = new Video(title, genre);
            vid.ID = id;

            videos.Add(vid);

            Console.WriteLine("Video added: ");
            WriteVideoInformation(vid);
            Console.WriteLine("Press any key to return to the previous menu");
        }   

        // Replaces an old video with a new one based on ID
        // Returns true if the update was successfull, false otherwise.
        public void UpdateVideo()
        {
            bool correctSelection = false;
            while (!correctSelection)
            {
                Console.WriteLine("Select the id of the video to be updated: ");
                int id = Utility.ReadNumber();

                Video vidToUpdate = videos.FirstOrDefault(v => v.ID == id);
                if (vidToUpdate != null)
                {
                    Console.WriteLine("Selected video: ");
                    WriteVideoInformation(vidToUpdate);
                    Console.WriteLine("Enter new title: ");
                    string title = Console.ReadLine();
                    Genre g = SelectGenre();

                    vidToUpdate.Title = title;
                    vidToUpdate.VideoGenre = g;

                    Console.WriteLine("Video updated: ");
                    WriteVideoInformation(vidToUpdate);
                    Console.WriteLine("Press any key to return to the previous menu!");

                    correctSelection = true;
                }
                else
                {
                    Console.WriteLine("Video with the specified id does not exist. Please enter a valid id!");
                }
            }


        }

        internal void ListVideos()
        {
            int i = 1;
            foreach (Video item in videos)
            {
                Console.WriteLine("Video #{0}:", i);
                WriteVideoInformation(item);
                i++;
            }
            Console.WriteLine("Press any key to return to the previous menu!");
        }

        public void DeleteVideo()
        {
            bool correctSelection = false;
            while (!correctSelection)
            {
                Console.WriteLine("Select the id of the video to be updated: ");
                int id = Utility.ReadNumber();

                Video vidToDelete = videos.FirstOrDefault(v => v.ID == id);
                if (vidToDelete != null)
                {
                    Console.WriteLine("Selected video: ");
                    WriteVideoInformation(vidToDelete);

                    if (videos.Remove(vidToDelete))
                    {
                        Console.WriteLine("Video succesfuly deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Video deletion unsuccessfull.");
                    }

                    Console.WriteLine("Press any key to return to the previous menu");

                    correctSelection = true;
                }
                else
                {
                    Console.WriteLine("Video with the specified id does not exist. Please enter a valid id!");
                }
            }
        }

        public void FindVideo()
        {
            Console.WriteLine("Enter the id: ");
            int id = Utility.ReadNumber();

            Video vid = videos.FirstOrDefault(v => v.ID == id);

            if (vid == null)
            {
                Console.WriteLine("Video with the id {0} does not exist.", id);
            }
            else
            {
                Console.WriteLine("Found video with the id of {0}: ", id);
                WriteVideoInformation(vid);
            }

            Console.WriteLine("Press any key to return to the previous menu");
        }

        private void WriteVideoInformation(Video video)
        {
            Console.WriteLine("\tID: {0}", video.ID);
            Console.WriteLine("\tTitle: {0}", video.Title);
            Console.WriteLine("\tGenre: {0}", video.VideoGenre.ToString());
        }


        private Genre SelectGenre()
        {
            bool correctSelection = false;
            Genre g = Genre.Action;

            while (!correctSelection)
            {
                int i = 1;
                foreach (var item in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine("{0}. -  {1}", i, item.ToString());
                    i++;
                }

                int selection = Utility.ReadNumber() - 1;

                if (Enum.IsDefined(typeof(Genre), selection))
                {
                    g = (Genre)selection;
                    correctSelection = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection!");
                }
            }
            return g;

        }
    }
}
