using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("Scene next: " + StageManager.instance.currentScene);*/
    }

    public void nextStage()
    {
        StageManager.instance.currentScene++;
        Debug.Log("Scene next: " + StageManager.instance.currentScene);
        SceneManager.LoadScene(StageManager.instance.currentScene);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
