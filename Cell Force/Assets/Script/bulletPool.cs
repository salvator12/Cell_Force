using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    public static bulletPool instance;
    private List<GameObject> bulletPlayerPool = new List<GameObject>();
    private List<GameObject> bulletEnemyPool = new List<GameObject>();
    public int amountPlayerBullet; // menentukan jumlah bullet player yang ingin di pool
    public int amountEnemyBullet;
    [SerializeField] private GameObject bulletPlayerPrefab;
    [SerializeField] private GameObject bulletEnemyPrefab;
    private void Awake()
    {
         if(instance == null)
        {
            instance = this;
        }   
    }

    void Start()
    {
        for(int i = 0; i < amountPlayerBullet; i++)
        {
            GameObject obj = Instantiate(bulletPlayerPrefab);
            obj.SetActive(false);
            bulletPlayerPool.Add(obj);
        }

        for(int i = 0; i < amountEnemyBullet; i++)
        {
            GameObject obj = Instantiate(bulletEnemyPrefab);
            obj.SetActive(false);
            bulletEnemyPool.Add(obj);
        }
    }

    public GameObject GetbulletPlayerPooled()
    {
        for(int i = 0; i < bulletPlayerPool.Count; i++)
        {
            if(!bulletPlayerPool[i].activeInHierarchy) // jika ada bullet yang tidak aktif di urutan hirarki
            {
                return bulletPlayerPool[i];
            }
        }
        return null; // jika semuanya aktif
    }

    public GameObject GetbulletEnemyPooled()
    {
        for (int i = 0; i < bulletEnemyPool.Count; i++)
        {
            if (!bulletEnemyPool[i].activeInHierarchy) // jika ada bullet yang tidak aktif di urutan hirarki
            {
                return bulletEnemyPool[i];
            }
        }
        return null; // jika semuanya aktif
    }
}
