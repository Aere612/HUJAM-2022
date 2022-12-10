using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float playerHp , maxPlayerHP=100f;
    public float movementSpeed = 1.0f;
    public float bulletPerSecond = 1.0f;
    public float damagePerBullet = 1.0f;
    public float bulletSpeed = 1.0f;
    private void Start()
    {
        playerHp = maxPlayerHP;
    }
}
