using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeneme : MonoBehaviour
{
    GameObject[] allObjects;
    [SerializeField] List<GameObject> activetedObjects;
    [SerializeField] private ParticleSystem playerDeathParticle;

    private PlayerStats playerStats;
    void Start()
    {
        allObjects = FindObjectsOfType<GameObject>();
        playerStats = GameObject.Find("Game Manager Object").GetComponent<PlayerStats>();
    }
    void Update()
    {
        if(playerStats.playerHp <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        foreach (var obj in allObjects)
        {
            obj.SetActive(false);
        }
        var explosion = Instantiate(playerDeathParticle, this.transform.position, Quaternion.identity);
        foreach (var obj in activetedObjects)
        {
            obj.SetActive(true);
        }
        Destroy(explosion, 2f);
    }
}
