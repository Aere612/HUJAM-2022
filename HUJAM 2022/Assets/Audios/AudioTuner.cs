using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTuner : MonoBehaviour
{
    public AudioSource auso;
    private void Start()
    {
        auso.volume = 0;
        StartCoroutine(audioTuner());
    }
    IEnumerator audioTuner()
    {
        while(auso.volume <= 0.75f)
        {
            auso.volume+=0.02f;
            yield return new WaitForSeconds(0.2f);
        }
    }

            
}
