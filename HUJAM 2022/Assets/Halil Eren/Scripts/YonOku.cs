using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YonOku : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        transform.up = dir;
    }
}
