using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float playerHp = 100.0f;
    public float movementSpeed = 1.0f;
    public float bulletPerSecond = 1.0f;
    public float damagePerBullet = 1.0f;
    public float bulletSpeed = 1.0f;

    private void Start()
    {
        playerHp = PlayerPrefs.GetFloat("hp");
        movementSpeed = PlayerPrefs.GetFloat("movementSpeed");
        bulletPerSecond = PlayerPrefs.GetFloat("bulletPerSecond");
        damagePerBullet = PlayerPrefs.GetFloat("damagePerBullet");
        bulletSpeed = PlayerPrefs.GetFloat("bulletSpeed");
    }
}
