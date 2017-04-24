using UnityEngine;
using System.Collections;


namespace Spikes
{

    public class PlayerCore : MonoBehaviour
    {
        private GameManager_Master GM;
       [SerializeField]private GameObject Explosion;
        private GameObject Player;
        Rigidbody2D Exploder;
        public Transform PlayerPos;

        bool AlreadyExploded;

        void OnEnable()
        {
            refrence();

            GM.GameOver += ExplodePlayer;

        }

        void OnDisable()
        {
            GM.GameOver -= ExplodePlayer;
        }


        void refrence()
        {

            GM = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
            Player = GameObject.Find("PlayerBody");

        }

        void ExplodePlayer()
        {
            Destroy(Player);
           // Exploder = Instantiate(Explosion, PlayerPos.position, PlayerPos.rotation) as Rigidbody2D;
        }
    }
}