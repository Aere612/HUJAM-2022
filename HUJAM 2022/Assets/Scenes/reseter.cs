using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reseter : MonoBehaviour
{
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats.weaponIndex = 0;
        PlayerPrefs.SetFloat("weaponIndex",playerStats.weaponIndex);
        playerStats.playerHp = 100;
        PlayerPrefs.SetFloat("playerHp", playerStats.playerHp);
        playerStats.movementSpeed = 0.025f;
        PlayerPrefs.SetFloat("movementSpeed", playerStats.movementSpeed);
        playerStats.bulletPerSecond = 5;
        PlayerPrefs.SetFloat("bulletPerSecond", playerStats.bulletPerSecond);
        playerStats.damagePerBullet = 3;
        PlayerPrefs.SetFloat("damage", playerStats.damagePerBullet);
        playerStats.bulletSpeed = 0.1f;
        PlayerPrefs.SetFloat("bulletSpeed", playerStats.bulletSpeed);
    }
}
