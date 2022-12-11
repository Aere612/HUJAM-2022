using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubClassSelect : MonoBehaviour
{
    public GameObject shotGunSubClass, asaultSubClass, sniperSubClass;
    public int weaponIndex, shotgunSubclass, asaultSubclass, sniperSubclass;
    // Start is called before the first frame update
    void Start()
    {
        weaponIndex = PlayerPrefs.GetInt("weaponIndex");

        switch (weaponIndex)
        {
            case 0:
                //pewpew.SetActive(true);
                break;
            case 1:
                sniperSubClass.SetActive(true);
                break;
            case 2:
                //laser.SetActive(true);
                break;
            case 3:
                shotGunSubClass.SetActive(true);
                break;
            case 4:
                asaultSubClass.SetActive(true);
                break;
        }
    }
    public void ShotgunSubClass1()
    {
        shotgunSubclass = 1;
        PlayerPrefs.SetInt("shotgunSubClass", shotgunSubclass);
    }
    public void ShotgunSubClass2()
    {
        shotgunSubclass = 2;
        PlayerPrefs.SetInt("shotgunSubClass", shotgunSubclass);
    }
    public void SniperSubClass1()
    {
        sniperSubclass = 1;
        PlayerPrefs.SetInt("sniperSubClass", sniperSubclass);
    }
    public void SniperSubClass2()
    {
        sniperSubclass = 2;
        PlayerPrefs.SetInt("sniperSubClass", sniperSubclass);
    }
    public void AsaultSubClass1()
    {
        asaultSubclass = 1;
        PlayerPrefs.SetInt("asaultSubClass", asaultSubclass);
    }
    public void AsaultSubClass2()
    {
        asaultSubclass = 2;
        PlayerPrefs.SetInt("asaultSubClass", asaultSubclass);
    }
}
