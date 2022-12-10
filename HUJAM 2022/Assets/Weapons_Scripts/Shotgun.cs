using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject bullet, currentBullet;
    public bool allowed = true, subAllowed = true, isTurbo = false, isBayonet = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && allowed)
        {
            allowed = false;
            StartCoroutine(BulletSpawner());
        }
        if (Input.GetKey(KeyCode.Mouse1) && subAllowed && isTurbo)
        {
            subAllowed = false;
            StartCoroutine(Turbo());
        }
        if (Input.GetKey(KeyCode.Mouse1) && subAllowed && isBayonet)
        {
            subAllowed = false;
            StartCoroutine(Bayonet());
        }
    }
    IEnumerator BulletSpawner()
    {
        for (int counter = 0; counter != 10; counter++)
        {
            currentBullet = Instantiate(bullet);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z + (Random.Range(-45, 45)), 0f);
        }
        yield return new WaitForSeconds(1 / GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletPerSecond);
        allowed = true;
    }
    IEnumerator Turbo()
    {
        float temp = GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().movementSpeed;
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().movementSpeed *= 1.5f;
        yield return new WaitForSeconds(5f);
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().movementSpeed = temp;
        yield return new WaitForSeconds(5f);
        subAllowed = true;
    }
    IEnumerator Bayonet()
    {
        float temp = GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletPerSecond;
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletPerSecond *= 5f;
        yield return new WaitForSeconds(5f);
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletPerSecond = temp;
        yield return new WaitForSeconds(10f);
        subAllowed = true;
    }
}