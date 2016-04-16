using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour
{
    public Tile tile;
    //After attaching this script to hex tile prefab don't forget to initialize following materials with the ones we created earlier
    public Material OpaqueMaterial;
    public Material defaultMaterial;
    //Slightly transparent orange
    Color cursorHoverColour = Color.blue;
    Color cursorLeftClickColour = Color.green;
    Color cursorRightClickColour = Color.red;

    void changeColor(Color color)
    {
        //If transparency is not set already, set it to default value
       // if (color.a == 1)
       //     color.a = 130f / 255f;
        GetComponent<Renderer>().material = OpaqueMaterial;
        GetComponent<Renderer>().material.color = color;
    }

    //IMPORTANT: for methods like OnMouseEnter, OnMouseExit and so on to work, collider (Component -> Physics -> Mesh Collider) should be attached to the prefab
    void OnMouseEnter()
    {
        GridManager.instance.selectedTile = tile;
        //when mouse is over some tile, and color is not Red/Green, change color to orange
        if (this.isColour(Color.white))
        {
            changeColor(cursorHoverColour);
        }
    }

    //changes back to fully transparent material when mouse cursor is no longer hovering over the tile
    void OnMouseExit()
    {
        GridManager.instance.selectedTile = null;
        if (this.isColour(cursorHoverColour))
        {
            GetComponent<Renderer>().material = defaultMaterial;
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
    //called every frame when mouse cursor is on this tile
    void OnMouseOver()
    {
        //if player right-clicks on the tile, toggle passable variable and change the color accordingly
        if (Input.GetMouseButtonUp(1))
        {
            if (this.isColour(cursorRightClickColour))
            {
                changeColor(cursorHoverColour);
            }
            else {
                changeColor(cursorRightClickColour);
            }

        }
        //if user left-clicks the tile
        if (Input.GetMouseButtonUp(0))
        {
            if (this.isColour(cursorLeftClickColour))
            {
                changeColor(cursorHoverColour);
            }
            else
            {
                changeColor(cursorLeftClickColour);
            }
        }
    }

    void originTileChanged()
    {
        var originTileTB = GridManager.instance.originTileTB;
        //deselect origin tile if user clicks on current origin tile
        if (this == originTileTB)
        {
            GridManager.instance.originTileTB = null;
            GetComponent<Renderer>().material = defaultMaterial;
            return;
        }
        //if origin tile is not specified already mark this tile as origin
        GridManager.instance.originTileTB = this;
        changeColor(Color.red);
    }

    void destTileChanged()
    {
        var destTile = GridManager.instance.destTileTB;
        //deselect destination tile if user clicks on current destination tile
        if (this == destTile)
        {
            GridManager.instance.destTileTB = null;
            GetComponent<Renderer>().material.color = cursorHoverColour;
            return;
        }
        //if there was other tile marked as destination, change its material to default (fully transparent) one
        if (destTile != null)
            destTile.GetComponent<Renderer>().material = defaultMaterial;
        GridManager.instance.destTileTB = this;
        changeColor(Color.blue);
    }

    bool isColour(Color colour) {
        if (GetComponent<Renderer>().material.color != colour)
        {
            return false;
        }
        else {
            return true;
        }

    }
}