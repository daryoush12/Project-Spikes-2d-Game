using UnityEngine;
using System.Collections;


namespace Spikes
{

    public class CoinHandler : MonoBehaviour
    {

        private ItemBase essenceb = new ItemBase();
       
        GameManager_Master GM;

        void Start()
        {
            essenceb.refrence(this.GetType().Name);
            refrence();
           


        }

        void refrence()
        {


            essenceb.refrence(this.GetType().Name);
            essenceb.CheckEssence(this.GetType().Name);
            GM = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
            

        }


        void OnCollisionEnter2D(Collision2D col)
        {
            switch (essenceb.checkCollision(col))
            {
                case true:
                    GM.CallAddPoints(75);
                    Destroy(this.gameObject);
                    break;
                case false:
                    //do photosynthesis
                    Debug.Log("Item doesnt exist");
                    break;
                default:
                    Debug.Log("Error Collision scan did not succeed");
                    break;
            }


        }



    }



}




