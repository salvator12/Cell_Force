using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage2 : MonoBehaviour
{
    public List<powerUps> dropPowerUp = new List<powerUps>();
    public int calories_drop;
    public float health;
    public float moveSpeed;
    public float startShoot;
    public float fireRate;
    public float startAngle;
    public float endAngle;
    private float total = 100f;
    float nextShoot = 0.5f;
    float numForAdding = 0f;
    float angle = 0f;
    bool counter = false;
    Vector2 poscurr;
    Vector2 bulDir;
    bool changedir = false;
    // Start is called before the first frame update
    void Start()
    {
        poscurr = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("medicine"))
        {
            health -= 2f;
            if (health <= 0)
            {
                GameManager.instance.totalEnemies--;
                this.gameObject.SetActive(false);
                SaveLoad.data.UnlockedBoss2 = true;
                /*calculate_powerUpsdrop();*/
                GameManager.instance.calories += calories_drop;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        movement();
        /*Debug.Log("Time: "+ Time.time + " " + "nextShoot: " + nextShoot);*/
        if (Time.time > startShoot && Time.time > nextShoot)
        {
            nextShoot = Time.time + fireRate;
            shoot();
        }
        if (health != 500 && health % 15 == 0)
        {
            if (!counter)
            {
                calculate_powerUpsdrop();
            }

        }
        else
        {
            counter = false;
        }
    }

    public void movement()
    {

        if (!changedir && transform.position.x >= (poscurr.x - 3f))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
            if (transform.position.x <= poscurr.x - 3f)
            {
                changedir = true;
            }
        }
        else if (changedir && transform.position.x <= (poscurr.x + 3f))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
            if (transform.position.x >= poscurr.x + 3f)
            {
                changedir = false;
            }

        }
    }

    public void shoot()
    {
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            bulDir = (bulMoveVector - transform.position).normalized;
            GameObject bullet = bulletPool.instance.GetbulletEnemyPooled();
            if (bullet && !bullet.activeSelf)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().setMoveDir(bulDir);
            }
        }
        angle += 10f;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
    public void calculate_powerUpsdrop()
    {
        float random = Random.Range(0f, dropPowerUp.Count + 1);
        for (int i = 0; i < dropPowerUp.Count; i++)
        {
            /*if(i == 0)
            {
                dropPowerUp[i].powerData.chance = 20f;
                dropPowerUp[i].powerData.fireRate = 0.10f;
            } else if(i == 1)
            {
                dropPowerUp[i].powerData.chance = 15f;
            }*/
            Debug.Log("drop: " + dropPowerUp[i].powerData.chance / total + numForAdding + "rand: " + random);
            if (dropPowerUp[i].powerData.chance / total + numForAdding >= random)
            {
                player.instance.setPowerUps(dropPowerUp[i]);
                return;
            }
            else
            {
                numForAdding += dropPowerUp[i].powerData.chance / total;
            }
            counter = true;
        }
    }
}
