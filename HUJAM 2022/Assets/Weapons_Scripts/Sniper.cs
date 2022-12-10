using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject bullet, currentBullet;
    public bool allowed = true,subAllowed=true,isHunter=false,isAssassin=false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && allowed)
        {
            allowed = false;
            StartCoroutine(BulletSpawner());
        }
        if (Input.GetKey(KeyCode.Mouse2) && subAllowed && isHunter)
        {
            subAllowed = false;
            StartCoroutine(Hunter());
        }
        if (Input.GetKey(KeyCode.Mouse2) && subAllowed && isAssassin)
        {
            subAllowed = false;
            StartCoroutine(Assassin());
        }
    }
    IEnumerator BulletSpawner()
    {
        currentBullet = Instantiate(bullet);
        yield return new WaitForSeconds(1 / GameObject.Find("Player").GetComponent<PlayerStats>().bulletPerSecond);
        allowed = true;
    }
    IEnumerator Hunter()
    {
        transform.Translate(3f,0f,0f,Space.Self);
        yield return new WaitForSeconds(5f);
        subAllowed = true;
    }
    IEnumerator Assassin()
    {
        currentBullet = Instantiate(bullet);
        currentBullet.GetComponent<Bullet>().damage = currentBullet.GetComponent<Bullet>().damage *5;
        yield return new WaitForSeconds(10f);
        subAllowed = true;
    }
}