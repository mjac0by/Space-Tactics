using UnityEngine;
using System.Collections.Generic;
using System;

public class GridManager : MonoBehaviour
{

    //public Tile selectedTile = null;            //selectedTile stores the tile mouse cursor is hovering on
    //public TileBehaviour originTileTB = null;   //TB of the tile which is the start of the path
   // public TileBehaviour destTileTB = null;     //TB of the tile which is the end of the path

    public GameObject Hex;  //Base hex image set by import from unity editor

    public static int gridWidth = 20;   //Changeable from editor; with default case
    public static int gridHeight = 12;  //Changeable from editor; with default case

    public GameObject[,] hexGridArray = new GameObject[gridWidth, gridHeight];

    public static GridManager instance = null;

    void Awake()
    {
        instance = this;
    }

    //Hexagon tile width and height in game world
    private float hexWidth;
    private float hexHeight;

    //Method to initialise Hexagon width and height
    void setSizes()
    {
        //renderer component attached to the Hex prefab is used to get the current width and height
        hexWidth = Hex.GetComponent<Renderer>().bounds.size.x;
        hexHeight = Hex.GetComponent<Renderer>().bounds.size.y;
    }
    public Vector2 hexSize()
    {
        return new Vector2 (hexWidth, hexHeight);
    }

    //Method to calculate the position of the first hexagon tile
    //The upper left of the hex grid is (0,0,0)
    Vector3 calcInitPos()
    {
        Vector3 initPos;
        //the initial position will be in the left upper corner
        initPos = new Vector3(-hexWidth * gridWidth / 2f + hexWidth / 2,
            gridHeight / 2f * hexHeight - hexHeight / 2 -1.5f, 0);

        return initPos;
    }

    //method used to convert hex grid coordinates to game world coordinates
    public Vector3 calcWorldCoord(Vector2 gridPos)
    {
        //Position of the first hex tile
        Vector3 initPos = calcInitPos();
        //Every second row is offset by half of the tile width
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = initPos.x + offset + gridPos.x * hexWidth;
        //Every new line is offset in y direction by 3/4 of the hexagon height
        float y = initPos.y - gridPos.y * hexHeight * 0.75f;
        return new Vector3(x, y, 0);
    }

    //Finally the method which initialises and positions all the tiles
    void createGrid()
    {

		GameObject hexGridGO = new GameObject("HexGrid");


        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                //GameObject assigned to Hex public variable is cloned
                hexGridArray[x, y] = (GameObject)Instantiate(Hex);
                //Current position in grid
                Vector2 gridPos = new Vector2(x, y);
                hexGridArray[x, y].transform.position = calcWorldCoord(gridPos);
                hexGridArray[x, y].transform.parent = hexGridGO.transform;
            }
        }
    }
    public void colorhex(int x, int y, Color color)
    {
        hexGridArray[x, y].GetComponent<Renderer>().material.color = color;
    }
    public void colorhex(Vector2 xy, Color color)
    {
        hexGridArray[(int)xy.x, (int)xy.y].GetComponent<Renderer>().material.color = color;
    }
    void Start() {
        setSizes();
        instance.createGrid();}
}