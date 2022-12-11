using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage=1f, speed=0.1f;
    void Update()
    {
        transform.Translate(new Vector3(0f, speed, transform.position.z), Space.Self);
    }
    private void Start()
    {
        Destroy(this.gameObject, 4.9f);
    }
}
