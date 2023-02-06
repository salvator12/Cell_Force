using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject[] locked;
    public TextMeshProUGUI title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("chooseStage: " + StageManager.instance.currentStage);
        /*Debug.Log(StageManager.instance.currentStage);*/
        if (StageManager.instance.currentStage == 0)
        {
            Debug.Log("masuk");
            title.text = "Throat";
        }
        else if (StageManager.instance.currentStage == 1)
        {
            Debug.Log("masuk1");
            title.text = "Lungs";
        }
        controlLevel();
    }

    public void controlLevel()
    {
        for(int i = 0; i <= SaveLoad.data.CurrentLevel[StageManager.instance.currentStage]; i++)
        {
            locked[i].SetActive(false);
        }
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void pickLevel1()
    {
        if (!locked[0].activeSelf)
        {
            if (StageManager.instance.currentStage == 0)
            {
                StageManager.instance.currentScene = 4;
            }
            else
            {
                StageManager.instance.currentScene = 9;
            }
            StageManager.instance.currentLevel[StageManager.instance.currentStage] = 0;
            SceneManager.LoadScene("Shop");
        }
        
    }

    public void pickLevel2()
    {
        if (!locked[1].activeSelf)
        {
            if (StageManager.instance.currentStage == 0)
            {
                StageManager.instance.currentScene = 5;
            }
            else
            {
                StageManager.instance.currentScene = 10;
            }
            StageManager.instance.currentLevel[StageManager.instance.currentStage] = 1;
            SceneManager.LoadScene("Shop");
        }
    }

    public void pickLevel3()
    {
        if(!locked[2].activeSelf)
        {
            if (StageManager.instance.currentStage == 0)
            {
                StageManager.instance.currentScene = 6;
            }
            else
            {
                StageManager.instance.currentScene = 11;
            }
            StageManager.instance.currentLevel[StageManager.instance.currentStage] = 2;
            SceneManager.LoadScene("Shop");
        }
        
    }

    public void pickLevel4()
    {
        if (!locked[3].activeSelf)
        {
            if (StageManager.instance.currentStage == 0)
            {
                StageManager.instance.currentScene = 7;
            }
            else
            {
                StageManager.instance.currentScene = 12;
            }
            StageManager.instance.currentLevel[StageManager.instance.currentStage] = 3;
            SceneManager.LoadScene("Shop");
        }
        
    }

    public void pickLevel5()
    {
        if (!locked[1].activeSelf)
        {
            if (StageManager.instance.currentStage == 0)
            {
                StageManager.instance.currentScene = 8;
            }
            else
            {
                StageManager.instance.currentScene = 13;
            }
            StageManager.instance.currentLevel[StageManager.instance.currentStage] = 4;
            SceneManager.LoadScene("Shop");
        }
        
    }

}
