using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySASE : MonoBehaviour
{
    public GameObject Bullet;
    public Player player;
    public float enemyHp=3f;
    public float speed = 5f;
    float fireRate=1f, nextFire;
    public Transform target;
    public bool chase = true;
    public GameObject hitEffect, currentHitEffect;
    void Start()

    {
        nextFire = Time.time;
        StartCoroutine(ChaseAndStop());
        player = FindObjectOfType(typeof(Player)) as Player;
    }
    
   
    void Update()
    {
        CheckIfTimeToFire();
        if (chase)
        {
            EnemyChase();
        }
        Rotate();


    }
    void Rotate()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle,Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5f);
    }
    void CheckIfTimeToFire()
    {
        if (Time.time>nextFire && chase==false)
        {
            Instantiate(Bullet,transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
    void EnemyChase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    IEnumerator ChaseAndStop()
    {
        yield return new WaitForSeconds(1f);
        chase = false;
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
