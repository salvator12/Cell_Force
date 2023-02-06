using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveLoad.Load();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Application.persistentDataPath);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void OnApplicationQuit()
    {
        SaveLoad.Save();
        Application.Quit();
    }

    public void ensiklopedia()
    {
        SceneManager.LoadScene("Ensiklopedia");
    }

}
