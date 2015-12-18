using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
    public Camera camera;

	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		offset = transform.position - (player.transform.position/5);
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;

        // Points the camera in the direction of the mouse using ray casting
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        camera.transform.Translate(ray.direction, Space.World);
	}
}
