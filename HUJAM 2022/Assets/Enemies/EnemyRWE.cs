using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRWE : MonoBehaviour
{
    public GameManager gameManager;
    int randomDırection = 0;
    public float enemyHp = 3f;
    public GameObject hitEffect, currentHitEffect;

    void Start()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

        randomDırection = Random.Range(-5, 6);
    }

    private void Update()
    {
        if(enemyHp<=0)
        {
            currentHitEffect = Instantiate(hitEffect, transform);
            gameManager.killEnemies++;
            Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(randomDırection, -1));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            enemyHp -= collision.gameObject.GetComponent<Bullet>().damage;
            currentHitEffect = Instantiate(hitEffect, transform);
            currentHitEffect.GetComponent<ParticleSystem>().maxParticles = (int)collision.gameObject.GetComponent<Bullet>().damage;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Player")
        {
            GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().playerHp -= 20;
            currentHitEffect = Instantiate(hitEffect, transform);
            currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 10;
            transform.GetChild(0).SetParent(null);
            Destroy(gameObject);
        }
    }
}
