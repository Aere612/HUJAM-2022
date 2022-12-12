using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assault : MonoBehaviour
{
    public int subClassIndex;
    public GameObject bullet, currentBullet;
    public bool allowed = true, subAllowed = true, isPatriot = false, isTank = false;
    private void Start()
    {
        subClassIndex = PlayerPrefs.GetInt("asaultSubClass");
        //Burada 1 ya da 2 deðeri geliyor secime gore. Ona gore dongude 0 ya da 1 olma durumu ele alýncak
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && allowed)
        {
            allowed = false;
            StartCoroutine(BulletSpawner());
        }
        if (Input.GetKey(KeyCode.Mouse1) && subAllowed && isPatriot)
        {
            subAllowed = false;
            StartCoroutine(Patriot());
        }
        if (Input.GetKey(KeyCode.Mouse1) && subAllowed && isTank)
        {
            subAllowed = false;
            StartCoroutine(Tank());
        }
    }
    IEnumerator BulletSpawner()
    {
        currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        
        yield return new WaitForSeconds(1 / GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletPerSecond);
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
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().playerHp+=(GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().maxPlayerHp - GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().playerHp)/2;
        yield return new WaitForSeconds(30f);
        subAllowed = true;
    }
}
