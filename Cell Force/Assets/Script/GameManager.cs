using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using CellForce.Data;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public int calories;
    public int totalEnemies;
    public TextMeshProUGUI caloriesText;
    /*[HideInInspector]*/
    public int health;
    public Image[] healthbar;
    public GameObject pauseMenu;
    public GameObject stageComplete;
    public GameObject gameOver;
    private bool isPause = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 1f;
        print(Application.persistentDataPath + "/CellForce.bk");
        Debug.Log("Scene: " + SceneManager.GetActiveScene().buildIndex);
        calories = SaveLoad.data.Calories; 
        updateCalories();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        updateCalories();
        if(health <= 0)
        {
            //game over
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }   
        if(Input.GetKeyDown(KeyCode.Escape) && (!stageComplete.activeSelf && !gameOver.activeSelf))
        {
            pause();
        }
        if(totalEnemies == 0)
        {
            stageComplete.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void updateCalories()
    {
        caloriesText.text = calories.ToString();
    }

    public void pause()
    {
        isPause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        isPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        if(totalEnemies == 0)
        {
            StageManager.instance.currentLevel++;
            SaveLoad.data.CurrentLevel = StageManager.instance.currentLevel;
            StageManager.instance.stage[StageManager.instance.currentStage].levelStage[StageManager.instance.currentLevel].islocked = false;
        }
        SaveLoad.data.Calories = calories;
        SaveLoad.Save();
        SceneManager.LoadScene("Main Menu");
    }

    public void shop()
    {
        StageManager.instance.currentLevel++;
        SaveLoad.data.CurrentLevel = StageManager.instance.currentLevel;
        StageManager.instance.stage[StageManager.instance.currentStage].levelStage[StageManager.instance.currentLevel].islocked = false;
        SaveLoad.data.Calories = calories;
        Time.timeScale = 1f;
        StageManager.instance.currentScene = SceneManager.GetActiveScene().buildIndex;
        SaveLoad.Save();
        SceneManager.LoadScene("Shop");
    }
}
