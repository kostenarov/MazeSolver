﻿namespace MazeSolver;

public class Point
{
    private int x, y;
    
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    public int GetX()
    {
        return x;
    }
    
    public int GetY()
    {
        return y;
    }
}