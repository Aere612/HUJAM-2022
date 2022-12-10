using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    public GameObject bullet,currentBullet;
    public bool allowed = true;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && allowed)
        {
            allowed = false;
            StartCoroutine(BulletSpawner());
        }
    }    
    IEnumerator BulletSpawner()
    {
        currentBullet = Instantiate(bullet,transform.position,transform.rotation);
        yield return new WaitForSeconds(1 / GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().bulletPerSecond);
        allowed = true;
    }
}