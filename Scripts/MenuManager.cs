using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private AsyncOperation Async = null;

    public void NewGame()
    {
      
        SceneManager.LoadScene("Prototype");


    }


    IEnumerator LoadingLevel(int i)
    {
        Async = SceneManager.LoadSceneAsync(i);
        yield return Async;
    }

}
