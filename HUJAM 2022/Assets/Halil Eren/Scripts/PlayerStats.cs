using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int weaponIndex;
    public float maxPlayerHp;
    public float playerHp;
    public float movementSpeed;
    public float bulletPerSecond;
    public float damagePerBullet;
    public float bulletSpeed;

    private void Start()
    {
        weaponIndex = PlayerPrefs.GetInt("weaponIndex");
        playerHp = PlayerPrefs.GetFloat("playerHp");
        movementSpeed = PlayerPrefs.GetFloat("movementSpeed");
        bulletPerSecond = PlayerPrefs.GetFloat("bulletPerSecond");
        damagePerBullet = PlayerPrefs.GetFloat("damage");
        bulletSpeed = PlayerPrefs.GetFloat("bulletSpeed");
    }
}
