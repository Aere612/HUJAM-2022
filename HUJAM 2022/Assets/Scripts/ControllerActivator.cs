using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerActivator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player playerScript;
    [SerializeField] private GameObject pewPewGun;

    private void Update()
    {
        if (animator.isActiveAndEnabled)
        {
            playerScript.enabled = false;
            pewPewGun.SetActive(false);
            Invoke("SetAnimator", 10f);
        }
        else
        {
            playerScript.enabled = true;
            pewPewGun.SetActive(true);
        }
    }
    private void Start()
    {
        PlayerPrefs.SetInt("shotgunSubClass", 0);
        PlayerPrefs.SetInt("sniperSubClass", 0);
        PlayerPrefs.SetInt("asaultSubClass", 0);
    }

    private void SetAnimator()
    {
        animator.enabled = false;
    }
}
