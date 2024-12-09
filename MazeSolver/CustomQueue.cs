namespace MazeSolver;

public class CustomQueue <Cell>
{
    public List <Cell> _queue = new();
    
    public CustomQueue ()
    {
    }
    
    public void Enqueue(Cell cell)
    {
        if(_queue.Contains(cell))
            return;
        foreach (Cell iterator in _queue)
        {
            if(iterator.Equals(cell))
                return;
        }
        _queue.Add(cell);
    }
    
    public Cell Dequeue()
    {
        Cell cell = _queue[0];
        _queue.RemoveAt(0);
        return cell;
    }
    
    public List<Cell> GetQueue()
    {
        return _queue;
    }
    
    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }
    
    public void Clear()
    {
        _queue.Clear();
    }
    
    public bool Contains(Cell cell)
    {
        return _queue.Contains(cell);
    }
    
    public void EnqueueRange(List<Cell> cells)
    {
        _queue.AddRange(cells);
    }

    public Cell GetElement(int index)
    {
        return _queue.ElementAt(index);
    }
}