using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 12.7f);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 12.7f);
        }
    }
}
