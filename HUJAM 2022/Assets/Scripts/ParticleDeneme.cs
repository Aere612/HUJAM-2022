using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeneme : MonoBehaviour
{

    [SerializeField] private ParticleSystem playerDeathParticle;
    void Start()
    {
        var Object = Instantiate(playerDeathParticle, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(Object,0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
