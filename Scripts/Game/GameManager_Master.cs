using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Spikes
{

    public class GameManager_Master : MonoBehaviour
    {

        float Score = 0;


        // Initiate Events
        public delegate void GeneralEvent();
        //GameOver:
        public event GeneralEvent GameOver;
        public event GeneralEvent GameMessage;
        public event GeneralEvent AddPoints;


        //GamePotrait
        //public event GeneralEvent ActivateCutScene;
        //public event GeneralEvent DeactivateCutScene;

        //Story

        //public event GeneralEvent WelcomeIntoPrototype;



        public void CallGameOver()
        {
            if (GameOver != null)
            {

                GameOver();

            }
        }

        public void CallGameMEssage()
        {
             if(GameMessage != null)
            {
                GameMessage();
            }
        }

        public void CallAddPoints(int PointsToAdd)
        {
            if(AddPoints != null)
            {

                AddPoints();
                Score = Score + PointsToAdd;

            }

            Score = Score + PointsToAdd;

        }




        public void Restart ()
        {
          
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }

        public void ExitToMenu()
        {

            SceneManager.LoadScene("MainMenu");

        }




        public float CallForCurrentScore()
        {

            float checkScore = Score;

            return checkScore;

        }
    }

}

