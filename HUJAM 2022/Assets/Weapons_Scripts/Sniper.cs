using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject bullet, currentBullet;
    public bool allowed = true,subAllowed=true,isHunter=false,isAssassin=false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && allowed)
        {
            allowed = false;
            StartCoroutine(BulletSpawner());
        }
        if (Input.GetKey(KeyCode.Mouse1) && subAllowed && isHunter)
        {
            subAllowed = false;
            StartCoroutine(Hunter());
        }
        if (Input.GetKey(KeyCode.Mouse1) && subAllowed && isAssassin)
        {
            subAllowed = false;
            StartCoroutine(Assassin());
        }
    }
    IEnumerator BulletSpawner()
    {
        currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(1 / GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletPerSecond);
        allowed = true;
    }
    IEnumerator Hunter()
    {
        GameObject.Find("Player").transform.Translate(0f,3f,0f,Space.Self);
        yield return new WaitForSeconds(5f);
        subAllowed = true;
    }
    IEnumerator Assassin()
    {
        currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.0001f);
        currentBullet.GetComponent<Bullet>().damage = currentBullet.GetComponent<Bullet>().damage *5;
        yield return new WaitForSeconds(10f);
        subAllowed = true;
    }
}