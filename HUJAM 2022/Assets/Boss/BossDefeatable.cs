using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeatable : MonoBehaviour//34
{
    public GameObject timeLine;
    public int counter = 0;
    public GameObject currentBullet, bullet, sniperBullet, hitEffect, currentHitEffect;
    public float bossHP = 1000f;
    public bool once = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
#pragma warning disable UNT0002 // Inefficient tag comparison
        if (collision.transform.tag == "Bullet")
#pragma warning restore UNT0002 // Inefficient tag comparison
        {
            bossHP -= collision.gameObject.GetComponent<Bullet>().damage;
            currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
            currentHitEffect.GetComponent<ParticleSystem>().maxParticles = (int)collision.gameObject.GetComponent<Bullet>().damage;
#pragma warning restore CS0618 // Type or member is obsolete
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
        if (bossHP <= 0)
        {
            timeLine.SetActive(true);
        }
    }
    void Snipe()
    {
        currentBullet = Instantiate(sniperBullet, transform.position, transform.rotation);
        currentBullet.GetComponent<EnemyBullet>().damage = 10;
        currentBullet.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5f;
        currentBullet.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }
    void Shotgun()
    {
        for (int counter = 0; counter != 10; counter++)
        {
            currentBullet = Instantiate(bullet, transform.position, transform.rotation);
            currentBullet.transform.Rotate(0f, 0f, counter * 6f - 30f);
        }
    }
    void Shot()
    {
        currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        currentBullet.GetComponent<EnemyBullet>().damage = 1;
    }
    IEnumerator Go()
    {

        Shotgun();
        while (transform.position.y < 3.5f)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(0f, 0.04f), Space.World);
        }
        Snipe();
        yield return new WaitForSeconds(0.0001f);

        while (transform.position.x > -5.8f)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(-0.1f, 0f), Space.World);
            transform.Rotate(0f, 0f, 1f);
        }
        Shotgun();
        while (transform.position.x < 5.8f)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(0.1f, 0f), Space.World);
            transform.Rotate(0f, 0f, -1f);
        }
        Shotgun();
        while (transform.position.y > -3f)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(0f, -0.1f), Space.World);
            transform.Rotate(0f, 0f, -1f);
        }
        Shotgun();
        while (transform.position.x > -5.8f)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(-0.1f, 0f), Space.World);
            transform.Rotate(0f, 0f, -1f);
        }
        Shotgun();
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 10;
#pragma warning restore CS0618 // Type or member is obsolete
        while (counter != 30)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Rotate(0f, 0f, 1f);
            counter++;
        }
        counter = 0;
        Snipe();
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 10;
#pragma warning restore CS0618 // Type or member is obsolete
        while (counter != 60)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Rotate(0f, 0f, -1f);
            counter++;
        }
        counter = 0;
        Snipe();
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 10;
#pragma warning restore CS0618 // Type or member is obsolete
        while (counter != 30)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Rotate(0f, 0f, 1f);
            counter++;
        }
        counter = 0;
        Snipe();
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);

        transform.position = new(-6f, -3f, 0);
        while (counter != 20)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(0.3f, 0.25f), Space.World);
            transform.Rotate(0f, 0f, -5.85f);
            counter++;
        }
        counter = 0;
        while (counter != 360)
        {
            yield return new WaitForSeconds(0.01f);
            counter++;
            transform.Rotate(0f, 0f, -1f);
            Shot();
        }
        counter = 0;
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);
        currentHitEffect = Instantiate(hitEffect, transform);
#pragma warning disable CS0618 // Type or member is obsolete
        currentHitEffect.GetComponent<ParticleSystem>().maxParticles = 50;
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitForSeconds(1f);
        StartCoroutine(Go());
    }
}