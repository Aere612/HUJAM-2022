using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCE : MonoBehaviour
{
    public GameObject damageReport;
    public GameObject bullet;
    public float enemyHp
;   public float speed=5f;
    public Transform target;   
    void Update()
    {
        EnemyChase();
    }
    void EnemyChase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
   
    
}

