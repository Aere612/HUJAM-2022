using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSkill : MonoBehaviour
{
    public float playerHp;
    public float movementSpeed;
    public float bulletPerSecond;
    public float damagePerBullet;
    public float bulletSpeed;
    public void NextScene()
    {
        SceneManager.LoadScene("Level2");
    }
}
