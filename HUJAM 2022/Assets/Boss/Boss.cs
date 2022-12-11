using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject currentBullet,bullet;
    public float bosssHP = 1000f;

    void Update()
    {
        if (bosssHP < 1000)
        {
            StartCoroutine(Go());
        }
    }
    IEnumerator Go()
    {
        for (int counter = 0; counter != 10; counter++)
        {
            currentBullet = Instantiate(bullet);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z + (Random.Range(-45, 45)), 0f);
        }
        while (transform.position.y < 3.5f)
        {
            transform.Translate(Vector2.up);
        }
        for (int counter = 0; counter != 10; counter++)
        {
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.Rotate(0f, 0f, counter * 6f - 30f);
        }
        while (transform.position.x > -5.8f)
        {
            transform.Translate(Vector2.left);
            transform.Rotate(0f, 0f, 3f);
        }


        yield return new WaitForSeconds(0.1f);
    }
}
