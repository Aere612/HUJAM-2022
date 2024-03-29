using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public int subClassIndex;
    public GameObject bullet, currentBullet;
    public bool allowed = true,subAllowed=true,isHunter=false,isAssassin=false;
    private void Start()
    {
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().damagePerBullet=5;
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletPerSecond=1;
        GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletSpeed=0.2f;
        subClassIndex = PlayerPrefs.GetInt("sniperSubClass");
        //Burada 1 ya da 2 de�eri geliyor secime gore. Ona gore dongude 0 ya da 1 olma durumu ele al�ncak
    }
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
        currentBullet.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5f;
        currentBullet.GetComponent<SpriteRenderer>().color = new Color(0,0.3f , 1, 1);
        yield return new WaitForSeconds(10f);
        subAllowed = true;
    }
}