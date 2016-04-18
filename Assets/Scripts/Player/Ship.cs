using System.IO;
using UnityEngine;

namespace Player
{
    public class Ship : MonoBehaviour
    {
        public int hp, maxHP; //Hull
        private int ap, maxAP; //Armor
        public int sp, maxSP; //Shields
        public int ep, maxEP; //Energy

        private int momentum;

        public Ship()      //Default ship for testing
        {
            maxHP = 1; hp = maxHP;
            maxAP = 0; ap = maxAP;
            maxSP = 1; sp = maxSP;
            maxEP = 1; ep = maxEP;
        }

        void onGUI()
        {
            //HP Bar
            //Armor Bar
            //Shield Bar
            //Energy Bar
        }

        void takeDamage (int dmg, Point source, string dmgType)
        {
            //later, when it matters: determine direction of impact
                //impact direction in radians relative to x axis = tan^-1 (source - location)
                //convert to degrees; = (x*180/pi) % 360
                //convert to facing; =floor( (x-90)/60 )
            
            //Apply damage one layer at a time until all damage is spent
            //May be a multiplier based on weapon type
            //Discard fractional damage but minimum 1 dmg on a successful hit
                /* Shields
                 * Armor
                 * Hull
                 */

            //later, if you took hull damage, systems potentially go offline
            //If so, apply debuffs as appropriate

            //If hp=0, ship destroyed
            //Later, on larger ships, we may have multiple hull sections, where if a section reaches 0, it means a hull breach
                //Then we may consider crew death, repairs, and what the threshold of death is

            //If a ship is destroyed
                //Explosion sound/animation
                //Remove ship from map and fleet
                //Alter scoreboard, giving kills, deaths, and points as appropriate
                //Create debris on the map. Potentially give that debris momentum.
        }
    }
}