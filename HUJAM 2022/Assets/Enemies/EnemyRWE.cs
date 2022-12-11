using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRWE : MonoBehaviour
{
    int randomDýrection = 0;

    
    void Start()
    {
        randomDýrection = Random.Range(-5, 6);
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(randomDýrection, -1));
    }
}
