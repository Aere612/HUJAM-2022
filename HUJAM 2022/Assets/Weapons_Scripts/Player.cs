using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet;

    public float playerHp=100.0f;
    public float movementSpeed=1.0f;

    public int weaponTypeIndex;
    public float bulletPerSecond=1.0f;
    public float damagePerBullet=1.0f;
    public float bulletSpeed=1.0f;

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
    }
}
