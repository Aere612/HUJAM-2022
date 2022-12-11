using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public int subClassIndex;//1 ise turbo 2 ise bayonet
    public GameObject bullet, currentBullet;
    public bool allowed = true, subAllowed = true, isTurbo = false, isBayonet = false;
    private void Start()
    {
        subClassIndex = PlayerPrefs.GetInt("shotgunSubClass");
        //Burada 1 ya da 2 deðeri geliyor secime gore. Ona gore dongude 0 ya da 1 olma durumu ele alýncak
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && allowed)
        {
            allowed = false;
            StartCoroutine(BulletSpawner());
        }
        if (Input.GetMouseButtonDown(1) && subAllowed && isTurbo)
        {
            subAllowed = false;
            StartCoroutine(Turbo());
        }
        if (Input.GetMouseButtonDown(1) && subAllowed && isBayonet)
        {
            subAllowed = false;
            StartCoroutine(Bayonet());
        }
    }
    IEnumerator BulletSpawner()
    {
        for (int counter = 0; counter != 10; counter++)
        {
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.Rotate(0f, 0f, counter*6f-30f);
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