using UnityEngine;
using System.Collections;

namespace Spikes{

    public class EssenceOogum : MonoBehaviour {
    private ItemBase essenceb = new ItemBase();

        public GameObject EssenceGay;
      
       PlayerMaster pmaster;

	    void Start(){
            essenceb.refrence(this.GetType().Name);
            essenceb.CheckEssence(this.GetType().Name);
            pmaster = GameObject.Find("PlayerBody").GetComponent<PlayerMaster>();
            EssenceGay = GameObject.Find("OogumEssence");

	    }
        void OnCollisionEnter2D(Collision2D col){
            switch (essenceb.checkCollision(col))
            {
                case true:
                    pmaster.AddEssencePoints(25);
                    Destroy(EssenceGay);
                    break;
                case false:
                    //do photosynthesis
                    break;
                default:
                    Debug.Log("Error Collision scan did not succeed");
                    break;
            }
            
          
        }
    }
}
