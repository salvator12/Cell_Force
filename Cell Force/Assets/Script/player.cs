using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int shootCode;
    public static player instance;
    [HideInInspector]
    public List<powerUps> powerUps = new List<powerUps>();
    [HideInInspector]
    public float currPowerUpsDur = 0f;
    [HideInInspector]
    public powerUps _powerups;
    private int manyMinnion;
    public GameObject[] minnion;
    private float fireRate = 0.5f;
    private float nextShoot = 0f;
    private float startAngle, endAngle;
    Vector2 bulDir;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {
        _powerups = null;
        Debug.Log(manyMinnion);
        manyMinnion = SaveLoad.data.ManyMinnion;
        for (int i = 0; i < manyMinnion; i++)
        {
            /*Debug.Log("masuk");*/
            minnion[i].SetActive(true);
        }
    }

    void Update()
    {
        powerUpManager.instance.checkSpawn();
        /*Debug.Log("count: " + powerUps.Count);*/
        if(_powerups != null && currPowerUpsDur > 0)
        {
            currPowerUpsDur -= Time.deltaTime;
        }else if(_powerups != null && currPowerUpsDur <= 0)
        {
            _powerups = null;
            if(powerUps.Count <= 2)
            {
                powerUpManager.instance.power[powerUps.Count - 1].sprite = null;
                powerUpManager.instance._powerUps[powerUps.Count - 1].SetActive(false);
            } else
            {
                powerUpManager.instance.power[2].sprite = null;
                powerUpManager.instance._powerUps[2].SetActive(false);
            }
            powerUps.RemoveAt(0);
            powerUpManager.instance._powerUps[0].SetActive(false);
            powerUpManager.instance.power[0].sprite = null;
        }
        if (_powerups == null && powerUps.Count != 0 && currPowerUpsDur <= 0f)
        {
            _powerups = powerUps[0];
            currPowerUpsDur = _powerups.powerData.durationUse;

        }
        /*Debug.Log(Time.time);*/
        if (Input.GetMouseButton(shootCode) && Time.time > nextShoot)
        {
            nextShoot = Time.time + fireRate;
            /*Debug.Log("nextShoot: " + nextShoot);*/
            Shoot();
        }
    }

    public void Shoot()
    {
        /*Debug.Log("powerUps: " +  _powerups);
        Debug.Log("currDur: " + currPowerUpsDur);*/
        Vector3 bulMoveVector;
        if(powerUps.Count == 0 && _powerups == null)
        {
            bulDir = new Vector2(0, 1);
            GameObject bullet = bulletPool.instance.GetbulletPlayerPooled();
            if (bullet && !bullet.activeSelf)
            {
                bullet.transform.position = transform.position + new Vector3(0, 1, 0);
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().speed = 8;
                fireRate = 0.5f;
                bullet.GetComponent<Bullet>().setMoveDir(bulDir);
            }
        } else
        {
            startAngle = _powerups.powerData.startAngle;
            endAngle = _powerups.powerData.endAngle;
            if(_powerups.name == "powerUp_BulletFireRate")
            {
                _powerups.powerData.fireRate = SaveLoad.data.RapidFireRate;
            } else if(_powerups.name == "powerUp_BulletDirection")
            {
                _powerups.powerData.bulletAmount = SaveLoad.data.SplitbulletAmount;
            }
            float angleStep = (endAngle - startAngle) / _powerups.powerData.bulletAmount;
            float angle = startAngle;

            for(int i = 0; i < _powerups.powerData.bulletAmount; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
                bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                bulDir = (bulMoveVector - transform.position).normalized;
                GameObject bullet = bulletPool.instance.GetbulletPlayerPooled();
                if (bullet && !bullet.activeSelf)
                {
                    bullet.transform.position = transform.position + new Vector3(0, 1, 0);
                    bullet.transform.rotation = transform.rotation;
                    bullet.SetActive(true);
                    bullet.GetComponent<Bullet>().speed = _powerups.powerData.speed;
                    fireRate = _powerups.powerData.fireRate;
                    bullet.GetComponent<Bullet>().setMoveDir(bulDir);
                }
                angle += angleStep;
            }
        }
        
    }
    public void setPowerUps(powerUps _powerups)
    {
        powerUps.Add(_powerups);
    }
}
