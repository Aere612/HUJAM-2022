using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRWE : MonoBehaviour
{
    int randomDırection = 0;

    
    void Start()
    {
        randomDırection = Random.Range(-5, 6);
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(randomDırection, -1));
    }
}
