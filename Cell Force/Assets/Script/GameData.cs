using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    private int calories;
    /*private int currentScene;*/
    private int currentLevel;
    private int currentStage;
    private int rapidCost;
    private int splitCost;
    private int minnionCost;
    private int manyMinnion;
    private float rapidFireRate;
    private float rapidChance;
    private int splitbulletAmount;
    private float splitChance;
    private bool splitUnlocked;
    private string levelSplit;
    private string levelRapid;
    private string haveMinnion;
    public GameData()
    {
        calories = 0;
        currentStage = 0;
        currentLevel = 0;
        splitbulletAmount = 2;
        rapidFireRate = 0.15f;
        rapidCost = 50;
        splitCost = 50;
        minnionCost = 150;
        manyMinnion = 0;
        splitChance = 15f;
        rapidChance = 20f;
        splitUnlocked = false;
        levelSplit = "Level 1";
        levelRapid = "Level 1";
        haveMinnion = "Have: 0";
    }

    
    public int Calories
    {
        get
        {
            return calories;
        }
        set
        {
            calories = value;
        }
    }

    public int CurrentStage
    {
        get
        {
            return currentStage;
        }
        set
        {
            currentStage = value;
        }
    }

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    public int RapidCost
    {
        get
        {
            return rapidCost;
        }
        set
        {
            rapidCost = value;
        }
    }
    public int SplitCost
    {
        get
        {
            return splitCost;
        }
        set
        {
            splitCost = value;
        }
    }

    public int MinnionCost
    {
        get
        {
            return minnionCost;
        }
        set
        {
            minnionCost = value;
        }
    }

    public float RapidFireRate
    {
        get
        {
            return rapidFireRate;
        }
        set
        {
            rapidFireRate = value;
        }
    }

    public int SplitbulletAmount
    {
        get
        {
            return splitbulletAmount;
        }
        set
        {
            splitbulletAmount = value;
        }
    }
    public bool SplitUnlocked
    {
        get
        {
            return splitUnlocked;
        }
        set
        {
            splitUnlocked = value;
        }
    }

    public int ManyMinnion
    {
        get
        {
            return manyMinnion;
        }
        set
        {
            manyMinnion = value;
        }
    } 
    
    public float SplitChance
    {
        get
        {
            return splitChance;
        }
        set
        {
            splitChance = value;
        }
    }

    public float RapidChance
    {
        get
        {
            return rapidChance;
        }
        set
        {
            rapidChance = value;
        }
    }

    public string LevelSplit
    {
        get
        {
            return levelSplit;
        }
        set
        {
            levelSplit = value;
        }
    }

    public string LevelRapid
    {
        get
        {
            return levelRapid;
        }
        set
        {
            levelRapid = value;
        }
    }

    public string HaveMinnion
    {
        get
        {
            return haveMinnion;
        }
        set
        {
            haveMinnion = value;
        }
    }
}
