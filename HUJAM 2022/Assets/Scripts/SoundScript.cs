using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    void Start()
    {

        //audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        //audioSource.PlayOneShot(clip, 1f);
        AudioSource.PlayClipAtPoint(clip, transform.position, 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
