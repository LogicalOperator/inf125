using UnityEngine;
using System.Collections;
using System.Linq;

public class scroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeX;
    private Vector3 startPosition;
    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = (Vector3.forward * newPosition);

    }
}
