using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public GameObject prefab;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) //when ever mouse left mouse button is clicked down 
        {
            Vector3 pos = Input.mousePosition; //obtain mousepostion
            pos = Camera.main.ScreenToWorldPoint(pos);//obtain exact mouse position from main camera screen
            pos.z = transform.position.z;

            Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
            GameObject go = Instantiate(prefab, transform.position, q) as GameObject;//create bullet as a new gameObject
        }
    }

}
