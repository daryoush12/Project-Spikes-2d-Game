using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Spikes
{
    public class UI_Bars : MonoBehaviour
    {

        private PlayerMaster PlayerMast;
        private GameManager_Master GameManager;

        // HEALTH AND ESSENCE BAR:
        [SerializeField]private Image hpBar;
        [SerializeField]private Image EssenceBar;


        private float  EssenceChange;
        private float  HealthChange;

        public float Checkhp = 100;
        public float checkessence = 0;

        //Score:
        public float CheckScore;
         Text Score;

        //GameOver UI: 
        GameObject GameOverPopup;
        //Text DeathMessage;


        //InGameLogger
        Text GameMSGT;
        GameObject GameMSG;

        //GameNovelPotrait:

        GameObject PotraitPanel;

	

        void Update()
        {
			UpdateValues ();
            HandleScore();
        }

        void OnEnable()
        {
			//Instance refrence
			PlayerMast = GameObject.Find("PlayerBody").GetComponent<PlayerMaster>();
			//GameOverUI:
			GameOverPopup = GameObject.Find("GameOver");
			//DeathMessage = GameObject.Find("go_msg").GetComponent<Text>();
			GameManager = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
			GameOverPopup.SetActive(false);

			//InGameLogger:
			GameMSGT = GameObject.Find("InGameLog").GetComponent<Text>();
			GameMSG = GameObject.Find("InGameLog");
			GameMSG.SetActive(false);

			//Score:
			Score = GameObject.Find("Score").GetComponent<Text>();



			//Potrait:

			PotraitPanel = GameObject.Find("StorySegmentPotrait");


			PotraitPanel.SetActive(false);


            PlayerMast.AddHp += HandleHp;
            PlayerMast.DeductHp += HandleHp;

            PlayerMast.AddEssence += HandleEssence;
            PlayerMast.DeductEssence += HandleEssence;

            GameManager.GameOver += Death;
        }

        void OnDisable()
        {
            PlayerMast.AddHp -= HandleHp;
            PlayerMast.DeductHp -= HandleHp;

            PlayerMast.AddEssence -= HandleEssence;
            PlayerMast.DeductEssence -= HandleEssence;

            GameManager.GameOver -= Death;
        }

        void HandleHp()
        {
            HealthChange = PlayerMast.CallForCurrentHp();
            hpBar.fillAmount = Map(HealthChange, 0,100,0,1);
        }

        void HandleEssence()
		{
           EssenceChange = PlayerMast.CallForCurrentEssence();
           EssenceBar.fillAmount = Map(EssenceChange, 0, 200, 0, 1);
        }

        void HandleScore()
        {
          CheckScore =  GameManager.CallForCurrentScore();
          Score.text = ("Score: " + CheckScore);
        }

        private float Map(float value, float inMin, float inMax, float outMin, float outMax)
		{
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
			

        void UpdateValues()
        {
            Checkhp = PlayerMast.CallForCurrentHp();
            checkessence = PlayerMast.CallForCurrentEssence();

            if (Checkhp > 0 && checkessence < 200)
                {

                //Now Update UI:
                hpBar.fillAmount = Map(Checkhp, 0, 100, 0, 1);
                EssenceBar.fillAmount = Map(checkessence, 0, 200, 0, 1);
                Debug.Log("Update called");
                }

                else if (Checkhp == 0)
            {

                GameManager.CallGameOver();
                Debug.Log("Gameover");  
            }

                else
                {

                    Checkhp = PlayerMast.CallForCurrentHp();
                    checkessence = PlayerMast.CallForCurrentEssence();
                   
                }
               
            
           
        }

        void Death()
        {


            StartCoroutine(DeathIniate(1f));  
            



        }

        IEnumerator DeathIniate(float Wait)
        {
            yield return new WaitForSeconds(Wait);
            GameOverPopup.SetActive(true);

        }

        public  IEnumerator Message(string text, float waitTime)
        {
            GameMSG.SetActive(true);
            GameMSGT.text = text;
            yield return new WaitForSeconds(waitTime);
            GameMSG.SetActive(false);
        }

        void InitiatePotraitConv()
        {
            PotraitPanel.SetActive(true);
            // Deactivate Player Movement.

            


        }
        
   
        

        
     










    }
}


