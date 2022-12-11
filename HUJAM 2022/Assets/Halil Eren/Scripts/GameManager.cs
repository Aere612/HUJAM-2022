using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player player;
    PlayerStats playerStats;
    public GameObject finishLevel, gameOverScreen, deathParticle;
    public GameObject[] enemies;
    public Transform[] poses;

    public bool isSpawn;
    public float time, repeatRate;
    public int remainingEnemies, killEnemies, gelmesiGerekenDusmanSayisi;
    int gelenDusmanSayisi;

    // Start is called before the first frame update
    void Start()
    {
        isSpawn = true;
        player = FindObjectOfType(typeof(Player)) as Player;

        playerStats = GetComponent<PlayerStats>();
        InvokeRepeating("EnemySpawn", time, repeatRate);   
    }

    // Update is called once per frame
    void Update()
    {
        if(gelenDusmanSayisi==gelmesiGerekenDusmanSayisi)
        {
            isSpawn = false;
        }
        if(remainingEnemies == killEnemies)
        {
            finishLevel.SetActive(true);
        }
        if(playerStats.playerHp<=0)
        {
            Instantiate(deathParticle, player.transform.position, transform.rotation);

            Destroy(player.gameObject);
            gameOverScreen.SetActive(true);
        }
    }

    void EnemySpawn()
    {
        if(isSpawn)
        {
            int randomEnemyIndex, randomPosIndex;
            randomEnemyIndex = Random.Range(0, enemies.Length);
            randomPosIndex = Random.Range(0, poses.Length);
            Instantiate(enemies[randomEnemyIndex], poses[randomPosIndex].transform.position, transform.rotation);
            gelenDusmanSayisi++;
        }
        
    }
}
