namespace MazeSolver;

public class Maze
{
    private Cell _start;
    
    private Cell _end;

    private Cell _cornerTopLeft;
    private Cell _cornerBottomRight;

    private int _width, _height;
    
    public Maze(int width, int height)
    {
        _width = width;
        _height = height;
        _cornerTopLeft = new Cell(0, 0);
        BuildMaze();
    }

    private void BuildMaze()
    {
        BuildFirstRow();
        for(int i = 1; i < _height; i++)
        {
            BuildMiddleRows(i);
        }
        //BuildLastRow();
    }

    private void BuildFirstRow()
    {
        Cell iterator = _cornerTopLeft;
        for(int i = 1; i < _width; i++)
        {
            Cell cellToAdd = new Cell(i, 0);
            AddCell(cellToAdd, iterator);
            iterator = cellToAdd;
        }
    }
    
    private void BuildLastRow()
    {
        Cell iterator = GetCell(0, _height - 1);
        for(int i = 0; i < _width; i++)
        {
            Cell cellToAdd = new Cell(i + 1, _height);
            AddCell(cellToAdd, iterator);
            iterator = cellToAdd;
        }
    }
    
    private void BuildMiddleRows(int row)
    {
        Cell iterator = _cornerTopLeft;
        for(int i = 0; i < _width; i++)
        {
            Cell cellToAdd = new Cell(i, row);
            AddCell(cellToAdd, iterator);
            iterator = cellToAdd;
        }
    }

    public CustomQueue<Cell> GetMaze()
    {
        try
        {
            CustomQueue<Cell> visitedCells = new CustomQueue<Cell>();
            return TraverseMaze(_cornerTopLeft, visitedCells);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public CustomQueue<Cell> TraverseMaze(Cell startCell, CustomQueue<Cell> visitedCells)
    {
        visitedCells.Enqueue(startCell);
        foreach(Cell cell in startCell.GetNeighbors())
        {
            if(!visitedCells.Contains(cell))
                TraverseMaze(cell, visitedCells);
        }
        return visitedCells;
    }
    
    private List<Cell> GetNeighbors(Cell cell)
    {
        return cell.GetNeighbors();
    }

    private void AddCell(Cell neighbour, Cell root)
    {
        root.AddNeighbor(neighbour);
    }
    
    private void AddCell(Cell cell, Cell neighbor, int width, int height)
    {
        if (cell.GetPoint().GetX() < 0 || cell.GetPoint().GetX() >= width)
            return;
        if (cell.GetPoint().GetY() < 0 || cell.GetPoint().GetY() >= height)
            return;
        if (neighbor.GetPoint().GetX() < 0 || neighbor.GetPoint().GetX() >= width)
            return;
        if (neighbor.GetPoint().GetY() < 0 || neighbor.GetPoint().GetY() >= height)
            return;
        cell.AddNeighbor(neighbor);
        AddCell(new Cell(cell.GetPoint().GetX() + 1, cell.GetPoint().GetY()), cell, width, height);
        AddCell(new Cell(cell.GetPoint().GetX(), cell.GetPoint().GetY() + 1), cell, width, height);
    }
    
    public bool[][] PrintMaze()
    {
        bool[][] maze = new bool[10][];
        
        return maze;
    }

    public Cell GetCell(int x, int y)
    {
        Cell cell = GetCellRecursion(x, y, _cornerTopLeft);
        UnvisitAll(_cornerTopLeft);
        return cell;
    }

    public Cell GetCellRecursion(int x, int y, Cell startCell)
    {
        startCell.SetVisited(true);
        if(startCell.GetPoint().GetX() == x && startCell.GetPoint().GetY() == y)
            return startCell;
        foreach(Cell cell in startCell.GetNeighbors())
        {
            if(cell.GetPoint().GetX() == x && cell.GetPoint().GetY() == y)
                return cell;
            if(!cell.IsVisited())
                return GetCellRecursion(x, y, cell);
        }
        return null;
    }
    
    public void UnvisitAll(Cell startCell)
    {
        startCell.SetVisited(false);
        foreach(Cell cell in startCell.GetNeighbors())
        {
            if(cell.IsVisited())
                UnvisitAll(cell);
        }
    }
    
}