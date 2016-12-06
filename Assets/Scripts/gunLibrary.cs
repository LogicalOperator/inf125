using UnityEngine;
using System.Collections;

public class gunLibrary : MonoBehaviour {
    public GameObject[] guns;
    public static gunLibrary instance;
    GameObject gun;

    void Awake()
    {
        instance = this;  //static version of library
    }
    
    public GameObject findGun(int gunIndex) //return a gun depending on int given
    {
        switch (gunIndex)
        {
            case 0:
                gun = guns[0];
                break;
            case 1:
                gun = guns[1];
                break;
            case 2:
                gun = guns[2];
                break;
            case 3:
                gun = guns[3];
                break;
        }
        return gun;
    }
}
