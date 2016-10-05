using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
    public GameObject player;

    private Vector3 offset;
	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;// create a small offset from player

    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;//change camera position off player location with offset
    }
}
