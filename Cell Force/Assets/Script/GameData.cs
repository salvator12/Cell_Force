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
    public GameData()
    {
        calories = 0;
        currentStage = 0;
        currentLevel = 0;
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

    /*public int CurrentScene
    {
        get
        {
            return currentScene;
        }
        set
        {
            currentScene = value;
        }
    }*/

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
}
