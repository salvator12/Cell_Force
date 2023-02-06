using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnsiManager : MonoBehaviour
{
    public GameObject warningMessage;
    public GameObject RhinoButton;
    public GameObject AdenoButton;
    public GameObject descRhinoPanel;
    public GameObject descAdenoPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(SaveLoad.data.UnlockedBoss1 || SaveLoad.data.UnlockedBoss2)
        {
            if(SaveLoad.data.UnlockedBoss1)
            {
                RhinoButton.SetActive(true);
            } 
            if(SaveLoad.data.UnlockedBoss2)
            {
                AdenoButton.SetActive(true);
            }
            warningMessage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void descRhino()
    {
        descRhinoPanel.SetActive(true);
        descAdenoPanel.SetActive(false);
    }
    public void descAdeno()
    {
        descAdenoPanel.SetActive(true);
        descRhinoPanel.SetActive(false);
    }
}
