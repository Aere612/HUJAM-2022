using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSkill : MonoBehaviour
{
    PlayerStats playerStats;
    int sceneIndex;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void CanArtir()
    {
        
        playerStats.maxPlayerHp += 25;
        PlayerPrefs.SetFloat("maxPlayerHp", playerStats.maxPlayerHp);
    }
    public void SilahDegismeSniper()
    {
        playerStats.weaponIndex = 1;
        PlayerPrefs.SetInt("weaponIndex", playerStats.weaponIndex);
    }
    public void SilahDegismeLaser()
    {
        playerStats.weaponIndex = 2;
        PlayerPrefs.SetInt("weaponIndex", playerStats.weaponIndex);
    }
    public void SilahDegismeShootgun()
    {
        playerStats.weaponIndex = 3;
        PlayerPrefs.SetInt("weaponIndex", playerStats.weaponIndex);
    }
    public void SilahDegismeAssult()
    {
        playerStats.weaponIndex = 4;
        PlayerPrefs.SetInt("weaponIndex", playerStats.weaponIndex);
    }
    public void HareketHiziArtir()
    {
        playerStats.movementSpeed += 0.02f;
        PlayerPrefs.SetFloat("movementSpeed", playerStats.movementSpeed);
    }
    public void MermiHasariArtir()
    {
        playerStats.damagePerBullet += 2;
        PlayerPrefs.SetFloat("damage", playerStats.damagePerBullet);
    }
    public void MermiAtęsHiziArtir()
    {
        playerStats.bulletPerSecond += 2;
        PlayerPrefs.SetFloat("bulletPerSecond", playerStats.bulletPerSecond);
    }
    public void MermiHiziArtir()
    {
        playerStats.bulletSpeed += 0.1f;
        PlayerPrefs.SetFloat("bulletSpeed", playerStats.bulletSpeed);
    }
    public void AsaultSubSkill()
    {

    }
}
