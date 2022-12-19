using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUpManager : MonoBehaviour
{
    public static powerUpManager instance;
    public GameObject[] _powerUps;
    public Image[] power;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        /*currentPowerUpsUI = 0;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (_powerUps[0].gameObject.activeSelf == true && power[0].sprite != null)
        {
            power[0].fillAmount = player.instance.currPowerUpsDur / player.instance._powerups.powerData.durationUse;
        }
        
    }
    public void checkSpawn()
    {
        int idx;
        if(power[0].sprite == null)
        {
            idx = 0;
        } else
        {
            idx = 1;
        }
        for (int i = idx; i < player.instance.powerUps.Count; i++)
        {
            if(i == 3)
            {
                break;
            }
            if (player.instance.powerUps[i] != null)
            {
                power[i].sprite = player.instance.powerUps[i].powerData.Icon;
                _powerUps[i].SetActive(true);
            }
/*            else
            {
                power[i].sprite = null;
                _powerUps[i].SetActive(false);
            }*/
        }


    }
}
