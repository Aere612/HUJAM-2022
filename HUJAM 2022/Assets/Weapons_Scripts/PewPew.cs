using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    public GameObject bullet;
    private void OnMouseDown()
    {
        Instantiate(bullet);

    }    
}
