using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum movementType
    {
        moveLeft,
        moveRight,
        moveTop,
        moveBottom,
    }
    public movementType move;
    public List<powerUps> dropPowerUp = new List<powerUps>();
    public int calories_drop;
    public int health;
    public float moveSpeed;
    public float startShoot;
    public float fireRate;
    private float total = 100f;
    float nextShoot = 0f;
    float numForAdding = 0f;
    Vector2 poscurr;
    Vector2 bulDir;
    bool changedir = false;
    // Start is called before the first frame update
    void Start()
    {
        poscurr = transform.position;
        /*fireRate = Random.Range(0.8f, 2f) * 2;*/
        /*InvokeRepeating("shoot", startShoot, fireRate);*/
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Dead");
            health--;
            if(health == 0)
            {
                this.gameObject.SetActive(false);
                this.GetComponent<BoxCollider2D>().enabled = false;
                calculate_powerUpsdrop();
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
    }

    public void movement()
    {
        
        if(move == movementType.moveLeft)
        {
            if (!changedir && transform.position.x >= (poscurr.x - 3f))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
                if (transform.position.x <= poscurr.x - 3f)
                {
                    changedir = true;
                }
            } else if(changedir && transform.position.x <= (poscurr.x + 3f))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
                if(transform.position.x >= poscurr.x + 3f)
                {
                    changedir = false;
                }
                
            }
        } 
        if(move == movementType.moveRight)
        {
            
            if (!changedir && transform.position.x <= (poscurr.x + 3f))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
                if (transform.position.x >= poscurr.x + 3f)
                {
                    changedir = true;
                }

            } else if (changedir && transform.position.x >= (poscurr.x - 3f))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
                if (transform.position.x <= poscurr.x - 3f)
                {
                    changedir = false;
                }
            }
        }

        if (move == movementType.moveTop)
        {

            if (!changedir && transform.position.y <= (poscurr.y + 1f))
            {
                transform.Translate(new Vector3(0,1,0) * moveSpeed * Time.deltaTime, Space.World);
                if (transform.position.y >= poscurr.y + 1f)
                {
                    changedir = true;
                }

            }
            else if (changedir && transform.position.y >= (poscurr.y - 1f))
            {
                transform.Translate(new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime, Space.World);
                if (transform.position.y <= poscurr.y - 1f)
                {
                    changedir = false;
                }
            }
        }

        if (move == movementType.moveBottom)
        {
            if (!changedir && transform.position.y >= (poscurr.y - 1f))
            {
                transform.Translate(new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime, Space.World);
                if (transform.position.y <= poscurr.y - 1f)
                {
                    changedir = true;
                }
            }
            else if (changedir && transform.position.y <= (poscurr.y + 1f))
            {
                transform.Translate(new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime, Space.World);
                if (transform.position.y >= poscurr.y + 1f)
                {
                    changedir = false;
                }

            }
        }
    }

    public void shoot()
    {
        bulDir = player.instance.transform.position;
        /*Vector2 playerPos = player.instance.transform.position;*/
        GameObject bullet = bulletPool.instance.GetbulletEnemyPooled();
        if (bullet && !bullet.activeSelf)
        {
            bullet.transform.position = transform.position + new Vector3(0, -1, 0);
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().setMoveDir(bulDir);
        }
    }
    public void calculate_powerUpsdrop()
    {
        float random = Random.Range(0f, 1f);
        for(int i = 0; i < dropPowerUp.Count; i++)
        {
            if(dropPowerUp[i].powerData.chance / total + numForAdding >= random)
            {
                player.instance.setPowerUps(dropPowerUp[i]);
                return;
            } else
            {
                numForAdding += dropPowerUp[i].powerData.chance / total;
            }
        }
    }
}
