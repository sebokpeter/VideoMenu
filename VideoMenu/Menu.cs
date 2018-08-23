using System;

namespace VideoMenu
{
    class Menu
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
                    manager.AddVideo();
                    break;
                case 2:
                    manager.FindVideo();
                    break;
                case 3:
                    manager.UpdateVideo();
                    break;
                case 4:
                    manager.DeleteVideo();
                    break;
                case 5:
                    manager.ListVideos();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    Console.WriteLine("Press any key to exit!");
                    run = false;
                    break;
                default:
                    Console.WriteLine("Other");
                    break;
            }
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
