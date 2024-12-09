namespace MazeSolver;

public class Cell
{
    private List<Cell> _neighbors = new();
    private Point _point;
    private bool _visited = false;
    private bool _isWall = false;
    
    public Cell(int x, int y)
    {
        _point = new Point(x, y);
    }
    
    public Cell(Point point)
    {
        _point = point;
    }
    
    public void AddNeighbor(Cell neighbor)
    {
        if(_neighbors.Contains(neighbor))
            return;
        if(_neighbors.Count == 4)
            return;
        foreach (Cell iterator in _neighbors)
        {
            if(iterator.GetX() == neighbor.GetX() && iterator.GetY() == neighbor.GetY())
                return;
        }
        _neighbors.Add(neighbor);
        neighbor.AddNeighbor(this);
    }
    
    public List<Cell> GetNeighbors()
    {
        return _neighbors;
    }
    
    public void SetVisited(bool visited)
    {
        _visited = visited;
    }
    
    public bool IsVisited()
    {
        return _visited;
    }
    
    public void SetWall(bool isWall)
    {
        _isWall = isWall;
    }
    
    public bool IsWall()
    {
        return _isWall;
    }
    
    public Point GetPoint()
    {
        return _point;
    }
    
    public int GetX()
    {
        return _point.GetX();
    }
    
    public int GetY()
    {
        return _point.GetY();
    }
}