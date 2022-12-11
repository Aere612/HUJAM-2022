using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossUiValues : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI bossHpText, playerHpText;
    public Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHpText.text = playerStats.playerHp.ToString();
        bossHpText.text = boss.bossHP.ToString();
    }
}
