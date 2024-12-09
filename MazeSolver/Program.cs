namespace MazeSolver;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        //ApplicationConfiguration.Initialize();
        //Application.Run(new Form1());
        
        Maze maze = new Maze(10, 10);
        bool[][] mazeArray = new bool[10][];

        Console.WriteLine("Maze:");
        
        CustomQueue<Cell> mazeQueue = maze.GetMaze();
        for (int i = 0; i < mazeQueue.GetQueue().Count; i++)
        {
            Cell cell = mazeQueue.GetElement(i);
            Console.WriteLine(cell.GetPoint().GetX() + " " + cell.GetPoint().GetY());
        }
    }
}