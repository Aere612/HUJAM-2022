using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage=1f,speed=0.1f;
    void Update()
    {
        transform.Translate(new Vector2(speed,0f));
    }
}
