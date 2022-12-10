using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet;

    public int playerHp;
    public float movementSpeed;

    public int weaponTypeIndex;
    public float bulletPerSecond;
    public float damagePerBullet;
    public float bulletSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mouse konumunun ve bu konuma g�re a��n�n hesaplanmas�
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //Objeyi a��ya g�re �evrilmesi
        transform.up = dir;

        //Klavye giri�i
        if(Input.GetKey(KeyCode.W))
        {
            //Hareketin objenin a��s�n�n ilerisine g�re yap�lmas�
            rb.AddForce(transform.up * movementSpeed, ForceMode2D.Impulse);

        }
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
