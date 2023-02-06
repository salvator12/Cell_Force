using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CellForce.Data;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    static public StageManager instance;
    public List<StageData> stage;
    public GameObject[] stageUI;
    public GameObject[] lockedUI;
    [HideInInspector]
    public int currentStage = 0;
    [HideInInspector]
    public int[] currentLevel;
    [HideInInspector]
    public int currentScene;
    private int chooseStage = 0;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            /*DontDestroyOnLoad(this.gameObject);*/
            
        }
        currentLevel = SaveLoad.data.CurrentLevel;
        controlWorldMap();
        /*        Debug.Log("currentLevel manager: " + currentLevel);*/

    }
    
    // Start is called before the first frame update
    /*void Start()
    {
        controlWorldMap();
    }*/

    // Update is called once per frame

    public void leftArrow()
    {
        if(chooseStage == 0)
        {
            chooseStage = 1;
            stageUI[chooseStage].SetActive(true);
            stageUI[chooseStage - 1].SetActive(false);
        } else
        {
            chooseStage = 0;
            stageUI[chooseStage].SetActive(true);
            stageUI[chooseStage + 1].SetActive(false);
        }
    }
    public void rightArrow()
    {
        if(chooseStage == 1)
        {
            chooseStage = 0;
            stageUI[chooseStage].SetActive(true);
            stageUI[chooseStage + 1].SetActive(false);
        } else
        {
            chooseStage = 1;
            stageUI[chooseStage].SetActive(true);
            stageUI[chooseStage - 1].SetActive(false);
        }
    }

    public void confirmStage()
    {
        if (SaveLoad.data.CurrentStage >= chooseStage) //biar stage yang ke lock tidak bisa di klik
        {
            Debug.Log("choose: " + chooseStage);
            currentStage = chooseStage;
            Debug.Log("current: " + currentStage);
            SceneManager.LoadScene("LevelSelection");
        }
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void controlWorldMap()
    {
        for(int i = 0; i <= SaveLoad.data.CurrentStage; i++)
        {
            lockedUI[i].SetActive(false);
        }
    }
}
