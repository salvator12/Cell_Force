using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CellForce.Data;
using UnityEditor;

public class StageManager : MonoBehaviour
{
    static public StageManager instance;
    public List<StageData> stage;
    [HideInInspector]
    public int currentStage;
    public int currentLevel;
    [HideInInspector]
    public int currentScene;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        currentStage = SaveLoad.data.CurrentStage;
        currentLevel = SaveLoad.data.CurrentLevel;
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveLoad.Save();
    }
}
