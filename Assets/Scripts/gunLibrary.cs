using UnityEngine;
using System.Collections;

public class gunLibrary : MonoBehaviour {
    public GameObject[] guns;
    public static gunLibrary instance;
    GameObject gun;

    void Start()
    {
        instance = this;
    }
    
    public GameObject findGun(int gunIndex)
    {
        switch (gunIndex)
        {
            case 0:
                gun = guns[0];
                break;
            case 1:
                gun = guns[1];
                break;
        }
        return gun;
    }
}
