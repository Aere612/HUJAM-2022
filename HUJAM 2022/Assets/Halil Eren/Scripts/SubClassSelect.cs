using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubClassSelect : MonoBehaviour
{
    public GameObject shotGunSubClass, asaultSubClass, sniperSubClass,shotgun,sniper,assault;
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
        shotgun.GetComponent<Shotgun>().isTurbo=true;
        PlayerPrefs.SetInt("shotgunSubClass", shotgunSubclass);
    }
    public void ShotgunSubClass2()
    {
        shotgunSubclass = 2;
        shotgun.GetComponent<Shotgun>().isBayonet=true;
        PlayerPrefs.SetInt("shotgunSubClass", shotgunSubclass);
    }
    public void SniperSubClass1()
    {
        sniperSubclass = 1;
        sniper.GetComponent<Sniper>().isHunter=true;
        PlayerPrefs.SetInt("sniperSubClass", sniperSubclass);
    }
    public void SniperSubClass2()
    {
        sniperSubclass = 2;
        sniper.GetComponent<Sniper>().isAssassin=true;
        PlayerPrefs.SetInt("sniperSubClass", sniperSubclass);
    }
    public void AsaultSubClass1()
    {
        asaultSubclass = 1;
        assault.GetComponent<Assault>().isPatriot=true;
        PlayerPrefs.SetInt("asaultSubClass", asaultSubclass);
    }
    public void AsaultSubClass2()
    {
        asaultSubclass = 2;
        assault.GetComponent<Assault>().isTank=true;
        PlayerPrefs.SetInt("asaultSubClass", asaultSubclass);
    }
}
