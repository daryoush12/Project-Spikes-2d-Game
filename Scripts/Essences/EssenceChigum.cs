using UnityEngine;
using System.Collections;

namespace Spikes{
    public class EssenceChigum : MonoBehaviour{

        private ItemBase essenceb = new ItemBase();
        


        void Start(){
            essenceb.refrence(this.GetType().Name);
         //essenceb.essT = essenceb.
	    }
        void OnCollisionEnter2D(Collision2D col){
            essenceb.checkCollision(col);
        }
    }
}

