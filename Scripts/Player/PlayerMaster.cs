using UnityEngine;
using System.Collections;

namespace Spikes
{
    public class PlayerMaster : MonoBehaviour
    {

        //PlayerStats:

       [SerializeField] private float Health = 100;
       [SerializeField] private float essence = 200;

       [SerializeField] private float MaxEssence = 200;
       [SerializeField] private float MaxHp = 100;

        private UI_Bars UIELE;


        //PlayerEvents:
        public delegate void GeneralEvent();
        //Add and deduct hp:
        public event GeneralEvent DeductHp;
        public event GeneralEvent AddHp;
        // Add and deduct Essence:
        public event GeneralEvent DeductEssence;
        public event GeneralEvent AddEssence;

        //Boost Events:
        public event GeneralEvent SpeedBoost;
        public event GeneralEvent DamageBoost;


        void Start()
        {
			UIELE = GameObject.Find("GameManager").GetComponent<UI_Bars>();
        }




        // Calls:

        //Hp Calls:
        public void DeductHealthpoints(int damage)
        {
            
            if (DeductHp != null)
            {
                if (Health < 0)
                {

                    Health = 0;
                    DeductHp();
                }

                else
                {

                    Health = Health - damage;
                    DeductHp();
                }

            }

            StartCoroutine(UIELE.Message(damage+" Taken!",0.5f));


        }

        public void AddHealthPoints(int GivenHp)
        {
			if (AddHp != null && Health < MaxHp)
			{

				Health = Health + GivenHp;
				DeductEssence();
			}

			else if (AddHp != null && Health > MaxHp)
			{
				Health = MaxHp;
				Debug.Log("Essence can not exceed limit of 200!  Ultimate Ability can now be activated");


			}
        }

        //Essence Calls:
        public void DeductEssencePoints(int LostEss)
        {



        }

        public void AddEssencePoints(int GivenEss)
        {

            if (AddEssence != null && essence < MaxEssence)
            {

                essence = essence + GivenEss;
                DeductEssence();
            }

            else if (AddEssence != null && essence > MaxEssence)
            {
                essence = MaxEssence;
                Debug.Log("Essence can not exceed limit of 200!  Ultimate Ability can now be activated");


            }

        }

        // Used for checking hp and essence values from other scripts:
        public float CallForCurrentHp()
        {
           float hp = Health;

          
            return hp;


        }

        public float CallForCurrentEssence()
        {
            float ess = essence;
            return ess;
        }


        //PlayerStatBoost Calls:
        public void GiveSpeedBoost(int boostvalue)
        {
            if(SpeedBoost != null)
            {
                SpeedBoost();
            }
        }

        public void GiveDamageBoost(int DMGBoost)
        {

            if(DamageBoost != null)
            {
				
            }
        }
    }

}


