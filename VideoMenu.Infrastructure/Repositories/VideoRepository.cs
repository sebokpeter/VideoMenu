using System.Collections.Generic;
using VideoMenu.Core;
using VideoMenu.Core.Entity;

namespace VideoMenu.Infrastructure.Data.Repositories
{

    class VideoRepository : IVideoRepository
    {
        private static int id = 1;
        private static List<Video> _videos = new List<Video>();

        public Video Create(Video vid)
        {
            vid.ID = id++;
            _videos.Add(vid);
        }

        public List<Video> ReadAll()
        {
            return _videos;
        }

        public Video ReadById(int id)
        {
            return _videos.Find(v => v.ID == id);
        }

        public Video UpdateVideo(Video updateVideo)
        {
            Video vidFromDB = this.ReadById(updateVideo.ID);
            if (updateVideo != null)
            {
                vidFromDB.Title = updateVideo.Title;
                vidFromDB.VideoGenre = updateVideo.VideoGenre;
                return vidFromDB;
            }

            return null;
        }

        public Video Delete(int id)
        {
            Video vidToRemove = this.ReadById(id);

            if (vidToRemove != null)
            {
                _videos.Remove(vidToRemove);
            }

            return null;
        }
    }
}
