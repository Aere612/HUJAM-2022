using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int weaponIndex;
    public GameObject pewpew, sniper, laser, shootgun, assault, particle;
    public Animator engineAnimator;
    Rigidbody2D rb;
    void latency()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
    void Start()
    {
        Invoke("latency", 1);
        weaponIndex = PlayerPrefs.GetInt("weaponIndex");

        rb = GetComponent<Rigidbody2D>();

        switch(weaponIndex)
        {
            case 0:
                pewpew.SetActive(true);
                break;
            case 1:
                sniper.SetActive(true);
                break;
            case 2:
                laser.SetActive(true);
                break;
            case 3:
                shootgun.SetActive(true);
                break;
            case 4:
                assault.SetActive(true);
                break;
        }

    }

    void Update()
    {
        // Mouse konumunun ve bu konuma göre açýnýn hesaplanmasý
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 dir = new(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //Objeyi açýya göre çevrilmesi
        transform.up = dir;

        //Klavye giriþi
        if(Input.GetKey(KeyCode.W))
        {
            //Hareketin objenin açýsýnýn ilerisine göre yapýlmasý
            rb.AddForce(transform.up * GameObject.Find("Game Manager Object").GetComponent<PlayerStats>().movementSpeed, ForceMode2D.Impulse);
            engineAnimator.SetBool("force",true);

        }
        else
        {
            engineAnimator.SetBool("force", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particle, transform.position, transform.rotation);
        }
    }
}
