using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector2(collision.transform.position.x -22, collision.transform.position.y);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.position = new Vector2(collision.transform.position.x - 22, collision.transform.position.y);
        }
    }
}
