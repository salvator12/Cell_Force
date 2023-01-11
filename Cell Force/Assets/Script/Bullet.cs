using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    [HideInInspector] public Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.CompareTag("enemyBullet"))
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                gameObject.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                if (GameManager.instance.health > 0)
                {
                    GameManager.instance.health--;
                    Debug.Log("Health: " + GameManager.instance.health);
                    GameManager.instance.healthbar[GameManager.instance.health].gameObject.SetActive(false);
                }
                gameObject.SetActive(false);
                
            }

        }
        if (this.gameObject.CompareTag("Bullet") && (collision.gameObject.CompareTag("Wall")|| collision.gameObject.CompareTag("Enemy")))
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection.normalized * speed;
    }

    public void setMoveDir(Vector2 dir)
    {
        moveDirection = dir;
    }
}
