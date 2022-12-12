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
        // Mouse konumunun ve bu konuma g�re a��n�n hesaplanmas�
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 dir = new(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //Objeyi a��ya g�re �evrilmesi
        transform.up = dir;

        //Klavye giri�i
        if(Input.GetKey(KeyCode.W))
        {
            //Hareketin objenin a��s�n�n ilerisine g�re yap�lmas�
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
