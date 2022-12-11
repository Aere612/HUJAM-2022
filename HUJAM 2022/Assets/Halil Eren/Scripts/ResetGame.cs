using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Awake()
    {
        playerStats.weaponIndex = 0;
        PlayerPrefs.SetFloat("weaponIndex", playerStats.weaponIndex);
        playerStats.playerHp = 100;
        PlayerPrefs.SetFloat("playerHp", playerStats.playerHp);
        playerStats.movementSpeed = 0.01f;
        PlayerPrefs.SetFloat("movementSpeed", playerStats.movementSpeed);
        playerStats.bulletPerSecond = 1;
        PlayerPrefs.SetFloat("bulletPerSecond", playerStats.bulletPerSecond);
        playerStats.damagePerBullet = 1;
        PlayerPrefs.SetFloat("damage", playerStats.damagePerBullet);
        playerStats.bulletSpeed = 0.05f;
        PlayerPrefs.SetFloat("bulletSpeed", playerStats.bulletSpeed);
    }

}
