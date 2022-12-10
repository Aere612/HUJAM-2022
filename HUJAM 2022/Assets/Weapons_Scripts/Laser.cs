using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject bullet, currentBullet;
    public bool allowed = true, subAllowed = true, isReaper = false, isAnnihilator = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && allowed)
        {
            allowed = false;
            StartCoroutine(BulletSpawner());
        }
        if (Input.GetKey(KeyCode.Mouse1) && subAllowed && isReaper)
        {
            subAllowed = false;
            StartCoroutine(Reaper());
        }
        if (Input.GetKey(KeyCode.Mouse1) && subAllowed && isAnnihilator)
        {
            subAllowed = false;
            StartCoroutine(Annihilator());
        }
    }
    IEnumerator BulletSpawner()
    {
        currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        currentBullet.transform.localScale=new(transform.localScale.x,transform.localScale.y+ GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
        yield return new WaitForSeconds(0.1f/GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletPerSecond);
        allowed = true;
    }
    IEnumerator Reaper()
    {
        for (int counter=0;counter!= 4 * GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletPerSecond; counter++)
        {
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z, 0f);
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z+45, 0f);
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z+90, 0f);
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z+135, 0f);
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z+180, 0f);
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z+225, 0f);
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z+270, 0f);
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed, transform.localScale.z);
            currentBullet.transform.rotation = new(currentBullet.transform.rotation.x, currentBullet.transform.rotation.y, currentBullet.transform.rotation.z+315, 0f);
            yield return new WaitForSeconds(0.1f / GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletPerSecond);
        }
        yield return new WaitForSeconds(10f);
        subAllowed = true;
    }
    IEnumerator Annihilator()
    {
        for (int counter = 0; counter != 1 * GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletPerSecond; counter++)
        {
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.localScale = new(transform.localScale.x, transform.localScale.y + GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletSpeed*2, transform.localScale.z);
            currentBullet.GetComponent<Bullet>().damage = currentBullet.GetComponent<Bullet>().damage * 5;
            yield return new WaitForSeconds(0.1f / GameObject.Find("Game Manager Obejct").GetComponent<PlayerStats>().bulletPerSecond);
        }
        yield return new WaitForSeconds(9f);
        subAllowed = true;
    }
}
