using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage,speed;
    Vector3 addSpeed;
    public void Start()
    {
        damage = GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().damagePerBullet;
        speed = GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletSpeed;
        Destroy(gameObject, 4.9857f);
    }
    void Update()
    {
        transform.Translate(new Vector3(0f, speed, transform.position.z), Space.Self);
    }
}
