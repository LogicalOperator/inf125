using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public GameObject prefab;
    GameObject go;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);

            Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
            go = Instantiate(prefab, transform.position, q) as GameObject;
        }
    }

}
