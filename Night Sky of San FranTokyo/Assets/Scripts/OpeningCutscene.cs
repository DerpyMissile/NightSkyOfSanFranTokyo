using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [YarnCommand("fade_background")]
    static IEnumerator backgroundCoolThing(){
        
        yield return new WaitForSeconds(3.0f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("ActualGame");



        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
