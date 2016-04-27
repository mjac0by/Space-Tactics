using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour
{
    public Tile tile;
    //After attaching this script to hex tile prefab don't forget to initialize following materials with the ones we created earlier
    public Material opaqueMaterial;
    public Material defaultMaterial;

    void changeState (string state)
    {
        switch (state)
        {
            case "MouseOver":
                GetComponent<Renderer>().material = opaqueMaterial;
                GetComponent<Renderer>().material.color = Color.blue; break;
            case "Selected":
                GetComponent<Renderer>().material = opaqueMaterial;
                GetComponent<Renderer>().material.color = Color.green; break;
            case "OverSelection":
                GetComponent<Renderer>().material = opaqueMaterial;
                GetComponent<Renderer>().material.color = Color.yellow; break;
            case "Obstacle":
                GetComponent<Renderer>().material = opaqueMaterial;
                GetComponent<Renderer>().material.color = Color.white; break;
            case "OverObstacle":
                GetComponent<Renderer>().material = opaqueMaterial;
                GetComponent<Renderer>().material.color = Color.red; break;
            default:
                GetComponent<Renderer>().material = defaultMaterial;
                GetComponent<Renderer>().material.color = defaultMaterial.color; break;
        }
    }

    //MOUSE INTERACTIONS
    void OnMouseEnter()
    {
        GridManager.instance.selectedTile = tile;
        if (this.Colour() == Color.green)
            changeState("OverSelection");
        else if (this.Colour() == Color.white)
            changeState("OverObstacle");
        else changeState("MouseOver");
    }

    void OnMouseExit()
    {
        GridManager.instance.selectedTile = null;
        if (this.Colour() == Color.yellow)
            changeState("Selected");
        else if (this.Colour() == Color.red)
            changeState("Obstacle");
        else changeState("");
    }

    //called every frame when mouse cursor is on this tile
    void OnMouseOver()
    {
        //LEFT-CLICK
        if (Input.GetMouseButtonUp(0))
        {changeState("OverSelection");}
        //RIGHT-CLICK
        if (Input.GetMouseButtonUp(1))
        {changeState("OverObstacle");}
    }

    Color Colour()
    {
        return GetComponent<Renderer>().material.color;
    }
}