using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject particle, particleRed;
    public PlayerStats playerStats;
    public float damage=1f, speed=0.1f;
    private void Start()
    {
        playerStats = FindObjectOfType(typeof(PlayerStats)) as PlayerStats;

        Destroy(this.gameObject, 10f);
    }
    void Update()
    {
        transform.Translate(new Vector3(0f, speed, transform.position.z), Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerStats.playerHp -= damage;
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
