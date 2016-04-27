using System;
using UnityEngine;

namespace Player
{
    class PlayerController : MonoBehaviour
    {
        private Vector3 pos;
        private int facing;
        private bool moving = false;
        Vector2 oneHex;

        void Start() {
            // First store our current position when the script is initialized.
            pos = transform.position;
            facing = (int) Math.Floor(transform.rotation.eulerAngles.z / 60f +2) %6;
            //Hard coded to assume facing 0 is to the right
        }
        void Update() {
            CheckInput();

            if (moving)
            {   // pos is changed when there's input from the player
                transform.position = pos;
                moving = false;
            }
        }
        void OnMouseOver()
        {
            if (Input.GetMouseButtonUp(0))
            {
                //Highlight the ship and its tile

                //Highlight all valid moves

                    /* Get the ship's energy
                     * For each point of energy:
                     *      get all neighbors
                     *      if they aren't highlit; highlight them according to the current iteration
                     *      if they ARE highlit, and the new path would be faster, replace the highlighting
                     *      pass all of the neighbor tiles up to repeat the process recursively */

                //If you left-click somewhere else, return to default display
                    //Deselect all tiles

                //If you left-click a valid move, highlight the path there
                    //Then if you click again, move there
                //If you right-click a valid move, move there

                //After you've moved, spend energy

                //If the ship is out of energy; deselect it

                //Otherwise, update the valid moves
            }
        }
        private void CheckInput()
        {
            //Verify that the ship has energy before allowing it to move
            
            // QWEASD control
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {   thrust(1,0);    }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {   thrust(-1,0);   }
            else if (Input.GetKeyDown(KeyCode.E) )
            {   thrust(1, 1);   }
            else if (Input.GetKeyDown(KeyCode.Q) )
            {   thrust(1, -1);  }

            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))  { yaw(-1);    moving = true; }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) { yaw( 1);    moving = true; }
               
            //After it moves, spend energy
        }

        private void yaw (int r) { facing = (facing + r + 6) % 6; transform.Rotate(0, 60*r, 0); moving = true; }
        private void thrust (int t, int slip)
        {
            oneHex = GridManager.instance.hexSize();

            switch (Math.Abs((facing + slip + 6) % 6))
            {
                case 0: pos += new Vector3(t*oneHex.x,0);break;
                case 1: pos += new Vector3(0.5f*t*oneHex.x, -0.75f*t*oneHex.y); break;
                case 2: pos += new Vector3(-0.5f*t*oneHex.x, -0.75f * t *oneHex.y); break;
                case 3: pos += new Vector3(-t*oneHex.x, 0); break;
                case 4: pos += new Vector3(-0.5f*t*oneHex.x, 0.75f * t *oneHex.y); break;
                case 5: pos += new Vector3(0.5f*t*oneHex.x, 0.75f * t *oneHex.y); break;
                default: Debug.LogError("Something went wrong with the facing.");break;
            }
            moving = true;
        }
    }
}