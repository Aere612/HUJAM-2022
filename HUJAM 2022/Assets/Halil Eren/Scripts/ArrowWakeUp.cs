using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWakeUp : MonoBehaviour
{
    public Animator arrowAnimator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            arrowAnimator.SetTrigger("wakeUp");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            arrowAnimator.SetTrigger("sleep");
            Debug.Log("Çktý");
        }
    }
}
