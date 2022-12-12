using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player player;
    PlayerStats playerStats;
    public GameObject finishLevel, gameOverScreen, deathParticle,shotgun,assault,sniper;
    public GameObject[] enemies;
    public Transform[] poses;

    public bool isSpawn;
    public float time, repeatRate;
    public int remainingEnemies, killEnemies, gelmesiGerekenDusmanSayisi;
    int gelenDusmanSayisi;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("shotgunSubClass"));
        Debug.Log(PlayerPrefs.GetInt("sniperSubClass"));
        Debug.Log(PlayerPrefs.GetInt("asaultSubClass"));

        if(PlayerPrefs.GetInt("shotgunSubClass")==1)
        {
            shotgun.GetComponent<Shotgun>().isTurbo=true;
        }else if(PlayerPrefs.GetInt("shotgunSubClass")==2){
            shotgun.GetComponent<Shotgun>().isBayonet=true;
        }
        if(PlayerPrefs.GetInt("sniperSubClass")==1)
        {
            sniper.GetComponent<Sniper>().isHunter=true;
        }else if(PlayerPrefs.GetInt("sniperSubClass")==2){
            sniper.GetComponent<Sniper>().isAssassin=true;
        }
        if(PlayerPrefs.GetInt("asaultSubClass")==1)
        {
            assault.GetComponent<Assault>().isPatriot=true;
        }else if(PlayerPrefs.GetInt("asaultSubClass")==2){
            assault.GetComponent<Assault>().isTank=true;
        }

        Time.timeScale = 1.0f;
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
            Invoke("TimeStopper", 2f);
        }
        if(playerStats.playerHp<=1f)
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
    void TimeStopper()
    {
        Time.timeScale = 0;
    }
}
