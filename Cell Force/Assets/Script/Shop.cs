using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CellForce.Data;
public class Shop : MonoBehaviour
{
    public powerUpsData rapid;
    public powerUpsData split;
    public GameObject spliButton;
    public Text levelRapid;
    public Text levelSplit;
    public Text haveMinnion;
    public Text rapidCost;
    public Text splitCost;
    public Text minnionCost;
    public Text calories;
    private bool rapidMax = false;
    private bool splitMax = false;
    private bool minnionMax = false;
    private int Manyminnion = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        calories.text = SaveLoad.data.Calories.ToString();
        if (SaveLoad.data.LevelRapid != "Max")
        {
            rapidCost.text = SaveLoad.data.RapidCost.ToString();
        } else
        {
            rapidCost.text = "--";
        }

        if(SaveLoad.data.LevelSplit != "Max")
        {
            splitCost.text = SaveLoad.data.SplitCost.ToString();
        } else
        {
            splitCost.text = "--";
        }

        if(SaveLoad.data.HaveMinnion != "Max")
        {
            minnionCost.text = SaveLoad.data.MinnionCost.ToString();
        } else
        {
            minnionCost.text = "--";
        }
        levelRapid.text = SaveLoad.data.LevelRapid;
        levelSplit.text = SaveLoad.data.LevelSplit;
        haveMinnion.text = SaveLoad.data.HaveMinnion;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("Scene next: " + StageManager.instance.currentScene);*/
        if (SaveLoad.data.Calories >= SaveLoad.data.RapidCost && levelRapid.text != "Max")
        {
            levelRapid.color = Color.green;
            rapidCost.color = Color.green;
        } else
        {
            levelRapid.color = Color.red;
            rapidCost.color = Color.red;
        }

        if (SaveLoad.data.Calories >= SaveLoad.data.SplitCost && levelSplit.text != "Max")
        {
            levelSplit.color = Color.green;
            splitCost.color = Color.green;
        }
        else
        {
            levelSplit.color = Color.red;
            splitCost.color = Color.red;
        }

        if (SaveLoad.data.Calories >= SaveLoad.data.MinnionCost && haveMinnion.text != "Max")
        {
            haveMinnion.color = Color.green;
            minnionCost.color = Color.green;
        }
        else
        {
            haveMinnion.color = Color.red;
            minnionCost.color = Color.red;
        }
        if(SaveLoad.data.SplitUnlocked)
        {
            spliButton.SetActive(true);
        }
    }

    public void nextStage()
    {
        StageManager.instance.currentScene++;
        Debug.Log("Scene next: " + StageManager.instance.currentScene);
        SaveLoad.Save();
        SceneManager.LoadScene(StageManager.instance.currentScene);
    }
    public void mainMenu()
    {
        SaveLoad.Save();
        SceneManager.LoadScene("Main Menu");
    }
    public void upgradeRapid()
    {
        
        if (levelRapid.color == Color.green)
        {
            Debug.Log(levelRapid.text + "," + "Level 1");
            SaveLoad.data.Calories -= SaveLoad.data.RapidCost;
            calories.text = SaveLoad.data.Calories.ToString();
            if (SaveLoad.data.RapidFireRate == 0.15f)
            {
                Debug.Log("masuk");
                SaveLoad.data.RapidFireRate = 0.10f;
                SaveLoad.data.RapidChance = 25f;
                SaveLoad.data.RapidCost = 100;
                rapidCost.text = SaveLoad.data.RapidCost.ToString();
                levelRapid.text = "Level 2";
                
            } else if(SaveLoad.data.RapidFireRate == 0.10f)
            {
                SaveLoad.data.RapidFireRate = 0.05f;
                SaveLoad.data.RapidChance = 30f;
                rapidCost.text = "--";
                levelRapid.text = "Max";
                rapidMax = true;
            }
            SaveLoad.data.LevelRapid = levelRapid.text;
        }
    }

    public void upgradeSplit()
    {
        if (levelSplit.color == Color.green)
        {
            SaveLoad.data.Calories -= SaveLoad.data.SplitCost;
            calories.text = SaveLoad.data.Calories.ToString();
            if (SaveLoad.data.SplitbulletAmount == 2)
            {
                SaveLoad.data.SplitbulletAmount = 3;
                SaveLoad.data.SplitChance = 20f;
                SaveLoad.data.SplitCost = 100;
                rapidCost.text = SaveLoad.data.RapidCost.ToString();
                levelSplit.text = "Level 2";
            }
            else if (SaveLoad.data.SplitbulletAmount == 3)
            {
                SaveLoad.data.SplitbulletAmount = 4;
                SaveLoad.data.SplitChance = 25f;
                rapidCost.text = "--";  
                levelSplit.text = "Max";
                splitMax = true;
            }
            SaveLoad.data.LevelSplit = levelSplit.text;
        }
    }

    public void buyMinnion()
    {
        if (haveMinnion.color == Color.green)
        {
            SaveLoad.data.Calories -= SaveLoad.data.MinnionCost;
            calories.text = SaveLoad.data.Calories.ToString();
            if (SaveLoad.data.ManyMinnion == 0)
            {
                SaveLoad.data.ManyMinnion++;
                SaveLoad.data.MinnionCost = 300;
                minnionCost.text = SaveLoad.data.MinnionCost.ToString();
                haveMinnion.text = "Have: " + SaveLoad.data.ManyMinnion;
            } else if(SaveLoad.data.ManyMinnion == 1)
            {
                SaveLoad.data.ManyMinnion++;
                SaveLoad.data.MinnionCost = 300;
                minnionCost.text = "--";
                haveMinnion.text = "Max";
                minnionMax = true;
            }
            SaveLoad.data.HaveMinnion = haveMinnion.text;
        }
    }
}
