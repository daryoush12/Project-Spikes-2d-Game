using UnityEngine;
using System.Collections;


namespace Spikes
{

    public class DamagePlayer : MonoBehaviour
    {
        // Initialising some variables:
        private PlayerMaster PlayerMast;
        public GameObject Trigger;
        private float CallRate = 0.3f;
        private float nextCall;

        // Use this for initialization
        void Start()
        {
			PlayerMast = GameObject.Find("PlayerBody").GetComponent<PlayerMaster>();
        }

        //Executing event and giving damage to player. Object destroyed after:
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player" && Time.time > nextCall)
            {
                PlayerMast.DeductHealthpoints(50);
                StartCoroutine(DamageTimer(1f));
                Debug.Log("Hp deduction calld");
                nextCall = Time.time + CallRate;
            }
            else
            {
                Debug.Log("Something else was hit by mace");
            }
        }

        IEnumerator DamageTimer(float Wait)
        {
            yield return new WaitForSeconds(Wait);
        }
    }
}


