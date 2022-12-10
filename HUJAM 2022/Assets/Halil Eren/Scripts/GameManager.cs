using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject finishLevel;
    public GameObject[] enemies;
    public Transform[] poses;

    public float time, repeatRate;
    public int remainingEnemies, killEnemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawn", time, repeatRate);   
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingEnemies == killEnemies)
        {
            finishLevel.SetActive(true);
        }
    }

    void EnemySpawn()
    {
        int randomEnemyIndex, randomPosIndex;
        randomEnemyIndex = Random.Range(0, enemies.Length);
        randomPosIndex = Random.Range(0, poses.Length);
        Instantiate(enemies[randomEnemyIndex], poses[randomPosIndex].transform.position, transform.rotation);
    }
}
