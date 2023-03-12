using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startGame);
        optionsButton.onClick.AddListener(openOptions);
        quitButton.onClick.AddListener(quitGameLmao);
    }

    IEnumerator LoadAsyncScene(){
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        //FADE MAKE IT FADE IT'LL BE COOL I SWEAR
        Color temp = startButton.GetComponent<Image>().color;
        Vector3 temp2 = new Vector3(0, 0, 0);
        while(temp.a > 0.0f){
            yield return new WaitForSeconds(0.01f);
            temp.a = temp.a - 0.01f;
            startButton.GetComponent<Image>().color = temp;
            optionsButton.GetComponent<Image>().color = temp;
            quitButton.GetComponent<Image>().color = temp;

            temp2 = startButton.GetComponent<Transform>().position;
            temp2.y-= 0.01f;
            startButton.GetComponent<Transform>().position = temp2;
            temp2 = optionsButton.GetComponent<Transform>().position;
            temp2.y-= 0.01f;
            optionsButton.GetComponent<Transform>().position = temp2;
            temp2 = quitButton.GetComponent<Transform>().position;
            temp2.y-= 0.01f;
            quitButton.GetComponent<Transform>().position = temp2;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BeginningCutscene");



        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void startGame(){
        StartCoroutine(LoadAsyncScene());
    }

    void openOptions(){
        
    }

    void quitGameLmao(){
        Debug.Log("Night Sky is no more. Another weteor crashes into Santa Monica and everyone dies. The End.");
        Application.Quit();
    }
}
