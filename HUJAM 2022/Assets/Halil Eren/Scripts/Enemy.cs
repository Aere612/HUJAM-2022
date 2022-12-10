using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float time, repeatRate;
    public GameObject damageReport;
    public GameObject bullet;
    public Transform player;
    public int enemyHp;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", time, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        transform.up = dir;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);

    }
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(damageReport, transform.position, damageReport.transform.rotation);
        }
    }
}
