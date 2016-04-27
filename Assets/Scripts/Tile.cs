using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
//Basic skeleton of Tile class which will be used as grid node

/*      Tile States
 *  0       Default (fully transparent)
 *  1       Mouse Over (highlit blue)
 *  2       Selected (highlit white)
 *  3       Legal Move (highlit green)
 *  4       Pathing (impose path trail)
 *  5       Obstacle (highlit orange)
 *  6       Enemy (highlit red)
 */

public class Tile : GridObject, IHasNeighbours<Tile>
{
    public bool Passable;

    public Tile(int x, int y)
        : base(x, y)
    {
        Passable = true;
    }

    public IEnumerable <Tile> AllNeighbours { get; set; }
    public IEnumerable <Tile> Neighbours
    {
        get { return AllNeighbours.Where(o => o.Passable); }
    }

    public static List<Point> NeighbourShift
    {
        get
        {
            return new List<Point>
                {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(1, -1),
                    new Point(0, -1),
                    new Point(-1, 0),
                    new Point(-1, 1),
                };
        }
    }

    public void FindNeighbours(Dictionary<Point, Tile> Board,
        Vector2 BoardSize, bool EqualLineLengths)
    {
        List<Tile> neighbours = new List<Tile>();

        foreach (Point point in NeighbourShift)
        {
            int neighbourX = X + point.X;
            int neighbourY = Y + point.Y;
            //x coordinate offset specific to straight axis coordinates
            int xOffset = neighbourY / 2;

            //If every second hexagon row has less hexagons than the first one, just skip the last one when we come to it
            if (neighbourY % 2 != 0 && !EqualLineLengths &&
                neighbourX + xOffset == BoardSize.x - 1)
                continue;
            //Check to determine if currently processed coordinate is still inside the board limits
            if (neighbourX >= 0 - xOffset &&
                neighbourX < (int)BoardSize.x - xOffset &&
                neighbourY >= 0 && neighbourY < (int)BoardSize.y)
                neighbours.Add(Board[new Point(neighbourX, neighbourY)]);
        }

        AllNeighbours = neighbours;
    }
}