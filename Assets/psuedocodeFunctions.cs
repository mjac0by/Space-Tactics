using UnityEngine;
using System.Collections;

public class psuedocodeFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

/* http://www.redblobgames.com/grids/hexagons/#coordinates
 * Get position of ship (0,0)
 * Get heading of ship (Deg) 30,90,150,210,270,330,390*
 * for (# of moves){
 * 	Calculate colors for heading 0, turn 60, turn -60
 * 	if not already colored, apply colors
 * }
 * 
*/