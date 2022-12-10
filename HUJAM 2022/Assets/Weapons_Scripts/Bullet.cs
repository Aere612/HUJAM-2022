using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage,speed;
    private void Start()
    {
        damage = GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().damagePerBullet;
        speed = GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletSpeed;
    }
    void Update()
    {
        transform.Translate(speed,0f,transform.position.z,Space.Self);
    }
}
