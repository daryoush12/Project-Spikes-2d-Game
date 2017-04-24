using UnityEngine;
using System.Collections;

namespace Spikes{
    public class AwgumEssence : MonoBehaviour{
        private ItemBase essenceb = new ItemBase();
	    void Start(){
            essenceb.refrence(this.GetType().Name);
           // essenceb.essT = EssenceType.GetType().Name;
	    }
        void OnCollisionEnter2D(Collision2D col){
            // Check what collided with essence
            essenceb.checkCollision(col);
            // Initiate the boost:
        }
    }
}
