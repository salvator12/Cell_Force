using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public int calories = 0;
    public TextMeshProUGUI caloriesText;
    [HideInInspector]
    public int health = 3;
    public Image[] healthbar;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        caloriesText.text = calories.ToString();
        if(health <= 0)
        {
            //game over
        }
    }
}
