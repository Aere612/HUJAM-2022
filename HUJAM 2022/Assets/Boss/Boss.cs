using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject currentBullet,bullet,hitEffect,currentHitEffect;
    public float bossHP = 1000f;
    public bool once = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            bossHP -= collision.gameObject.GetComponent<Bullet>().damage;
            currentHitEffect=Instantiate(hitEffect, transform);
            currentHitEffect.GetComponent<ParticleSystem>().maxParticles = (int)collision.gameObject.GetComponent<Bullet>().damage;
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {
        if (bossHP < 1000 && once)
        {
            StartCoroutine(Go());
            once = false;
        }
    }
    IEnumerator Go()
    {
        for (int counter = 0; counter != 10; counter++)
        {
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.Rotate(0f, 0f, counter * 6f - 30f);
        }
        
        while (transform.position.y < 3.5f)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(0f, 0.04f), Space.World);
        }
        currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.0001f);
        currentBullet.GetComponent<Bullet>().damage = currentBullet.GetComponent<Bullet>().damage =10;
        currentBullet.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5f;
        currentBullet.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        while (transform.position.x > -5.8f)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(-0.1f, 0f),Space.World);
            transform.Rotate(0f, 0f, 2f);
        }
        

        yield return new WaitForSeconds(0.1f);
    }
}
