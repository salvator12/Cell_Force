using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
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
    float nextShoot = 3f;
    float numForAdding = 0f;
    float anglePattern2 = 0f;
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
            health-=2f;
            if (health <= 0)
            {
                GameManager.instance.totalEnemies--;
                this.gameObject.SetActive(false);
                StageManager.instance.currentStage += 1;
                SaveLoad.data.CurrentStage = StageManager.instance.currentStage;
                SaveLoad.data.UnlockedBoss1 = true;
                GameManager.instance.calories += calories_drop;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        movement();
        if (Time.time > startShoot && Time.time > nextShoot)
        {
            nextShoot = Time.time + fireRate;
            shoot();
        }
        if(health != 500 && health % 15 == 0)
        {
            if(!counter)
            {
                calculate_powerUpsdrop();
            }
            
        } else
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
        if(health > 100)
        {
            startAngle = 90f;
            endAngle = 270f;
            float angleStep = (endAngle - startAngle) / 15;
            float angle = startAngle;

            for (int i = 0; i < 15; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                bulDir = (bulMoveVector - transform.position).normalized;
                GameObject bullet = bulletPool.instance.GetbulletEnemyPooled();
                if (bullet && !bullet.activeSelf)
                {
                    bullet.transform.position = transform.position + new Vector3(0, 1, 0);
                    bullet.transform.rotation = transform.rotation;
                    bullet.SetActive(true);
                    bullet.GetComponent<Bullet>().setMoveDir(bulDir);
                }
                angle += angleStep;
            }
        } else
        {
            fireRate = 0.15f;
            float bulDirX = transform.position.x + Mathf.Sin((anglePattern2 * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((anglePattern2 * Mathf.PI) / 180f);
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

            anglePattern2 += 10f;
        }
        
    }
    public void calculate_powerUpsdrop()
    {
        float random = Random.Range(0f, dropPowerUp.Count+1);
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
