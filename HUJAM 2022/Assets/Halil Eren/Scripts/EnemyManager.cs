using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int oldurulmesiGerekenDusmanSayisi, olenDusmanSayisi;
    public GameObject selectUpdateScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(olenDusmanSayisi==oldurulmesiGerekenDusmanSayisi)
        {
            selectUpdateScreen.SetActive(true);
        }
    }
}
