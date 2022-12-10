using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject damageReport;
    public GameObject bullet;
    public Player player;

    public int enemyHp;
    public float movementSpeed;
    public float time, repeatRate;

    bool isFire;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;

        InvokeRepeating("Shoot", time, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.up = dir;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);

    }
    void Shoot()
    {
        if (isFire)
        {
            Instantiate(bullet, transform.position, transform.rotation);
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
}
