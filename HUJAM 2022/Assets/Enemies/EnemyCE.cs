using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCE : MonoBehaviour
{
    public GameManager gameManager;

    public float enemyHp
;   public float speed=3f;
    public Player player;
    public GameObject hitEffect, currentHitEffect;
    private void Start()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

        player = FindObjectOfType(typeof(Player)) as Player;

    }
    void Update()
    {
        EnemyChase();
        Rotate();
        if (enemyHp <= 0)
        {
            currentHitEffect = Instantiate(hitEffect, transform);
            gameManager.killEnemies++;
            Destroy(gameObject);
        }
    }
    void EnemyChase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void Rotate()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5f);
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
            currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 5;
            transform.GetChild(0).SetParent(null);
            Destroy(gameObject);
        }
    }


}

