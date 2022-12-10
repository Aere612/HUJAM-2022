using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assault : MonoBehaviour
{
    public GameObject bullet, currentBullet;
    public bool allowed = true, subAllowed = true, isPatriot = false, isTank = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && allowed)
        {
            allowed = false;
            StartCoroutine(BulletSpawner());
        }
        if (Input.GetKey(KeyCode.Mouse2) && subAllowed && isPatriot)
        {
            subAllowed = false;
            StartCoroutine(Patriot());
        }
        if (Input.GetKey(KeyCode.Mouse2) && subAllowed && isTank)
        {
            subAllowed = false;
            StartCoroutine(Tank());
        }
    }
    IEnumerator BulletSpawner()
    {
        currentBullet = Instantiate(bullet);
        yield return new WaitForSeconds(1 / GameObject.Find("Player").GetComponent<PlayerStats>().bulletPerSecond);
        allowed = true;
    }
    IEnumerator Patriot()
    {
        float temp=GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().playerHp;
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().playerHp = 1000000f;
        yield return new WaitForSeconds(3f);
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().playerHp = temp;
        yield return new WaitForSeconds(12f);
        subAllowed = true;
    }
    IEnumerator Tank()
    {
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().playerHp+=(GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().maxPlayerHP - GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().playerHp)/2;
        yield return new WaitForSeconds(30f);
        subAllowed = true;
    }
}
