using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class minnion : MonoBehaviour
{
    public float fireRate;
    Vector2 shootDir;
    private float nextShoot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShoot)
        {
            nextShoot = Time.time + fireRate;
            /*Debug.Log("nextShoot: " + nextShoot);*/
            Shoot();
        }
        if(Time.time == 3)
        {

        }
    }

    public void Shoot()
    {
        GameObject bullet = bulletPool.instance.GetbulletMinnionPooled();
        if (bullet && !bullet.activeSelf)
        {
            bullet.transform.position = transform.position + new Vector3(0, 1, 0);
            shootDir = new Vector2(0, 1);

            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().speed = 8;
            bullet.GetComponent<Bullet>().setMoveDir(shootDir);
        }
    }
}
