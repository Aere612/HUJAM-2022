using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySASE : MonoBehaviour
{
    public GameObject damageReport;
    public GameObject Bullet;
    public Player player;
    public float enemyHp
;   public float speed = 5f;
    public float time, repeatRate;
    public Transform target;
    public bool chase = true;
    bool isFire;
    void Start()
    {
        StartCoroutine(ChaseAndStop());
        player = FindObjectOfType(typeof(Player)) as Player;

        InvokeRepeating("Shoot", time, repeatRate);
    }
    void Shoot()
    {
        if (isFire)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(damageReport, transform.position, damageReport.transform.rotation);
        }
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            isFire = true;
        }


    }
    void Update()
    {
        
        if (chase)
        {
            EnemyChase();
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
}
