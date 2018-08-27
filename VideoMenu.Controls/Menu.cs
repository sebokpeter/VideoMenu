using System;
using VideoMenu.Core;
using VideoMenu.Core.Entity;

namespace VideoMenu.Controls
{
    //Responsible for handling the UI.
    public class Menu
    {
        private static readonly string[] commands = new string[] { "1. - Create video", "2. - Find video",
            "3. - Update video", "4. - Delete video", "5. - List videos", "6. - Exit"};
        private VideoManager manager;
        private bool run;

        public Menu()
        {
            manager = new VideoManager();
            run = true; 
        }

        public void Run()
        {
            while (run)
            {
                DrawCommands();
                Console.WriteLine("Please enter a selection!");
                int input = Utility.ReadNumber();
                ProcessCommand(input);
                Console.ReadLine();
            }
        }

        private void ProcessCommand(int input)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            switch (input)
            {
                case 1:
                    Console.WriteLine("Enter the title of the video: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Select the genre of the video: ");
                    Genre genre = Utility.SelectGenre();

                    manager.AddVideo(title, genre);
                    break;
                case 2:
                    Console.WriteLine("Enter the ID of the video: ");
                    int lookId = Utility.ReadNumber();

                    Console.WriteLine(manager.FindVideo(lookId));
                    break;
                case 3:
                    Console.WriteLine("Enter the ID of the video to be updated: ");
                    int id = Utility.ReadNumber();

                    Console.WriteLine("Enter the title of the video: ");
                    string newTitle = Console.ReadLine();
                    Console.WriteLine("Select the genre of the video: ");
                    Genre newGenre = Utility.SelectGenre();

                    if (manager.UpdateVideo(id, newTitle, newGenre))
                    {
                        Console.WriteLine("Update successfull!");
                    }
                    else
                    {
                        Console.WriteLine("Update unsuccessfull!");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the ID of the video to be deleted: ");
                    int deleteId = Utility.ReadNumber();
                    if (manager.DeleteVideo(deleteId))
                    {
                        Console.WriteLine("Deletion successfull!");
                    }
                    else
                    {
                        Console.WriteLine("Deletion unsuccessfull!");
                    }
                    break;
                case 5:
                    Console.WriteLine(manager.ListVideos());
                    break;
                case 6:
                    run = false;
                    break;
                default:
                    Console.WriteLine("Other");
                    break;
            }
            Console.WriteLine("Press Enter to continue!");
        }

        private static void DrawCommands()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            foreach (string item in commands)
            {
                Console.WriteLine(item);
            }
        }
    }
}
