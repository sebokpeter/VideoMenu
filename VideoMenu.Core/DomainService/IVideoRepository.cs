using System.Collections.Generic;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core
{
    public interface IVideoRepository
    {
        Video Create(Video vid);
        Video ReadById(int id);
        List<Video> ReadAll();

        Video UpdateVideo(Video vidToUpdate);
        Video Delete(int id);
    }
}
