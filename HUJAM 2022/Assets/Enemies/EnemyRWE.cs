using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRWE : MonoBehaviour
{
    int randomD�rection = 0;

    
    void Start()
    {
        randomD�rection = Random.Range(-5, 6);
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(randomD�rection, -1));
    }
}
