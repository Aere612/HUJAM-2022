using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIValues : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameManager gameManager;
    public TextMeshProUGUI hpText, remainigEnemyText, killEnemyText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        playerStats = FindObjectOfType(typeof(PlayerStats)) as PlayerStats;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.playerHp <= 0)
        {
            playerStats.playerHp = 0;
        }
        killEnemyText.text = gameManager.killEnemies.ToString();
        remainigEnemyText.text = gameManager.remainingEnemies.ToString();
        hpText.text =playerStats.playerHp.ToString();

       
    }
}
