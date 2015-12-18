using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class OverworldCamera : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        // just hardcode this for now I guess
        transform.LookAt(new Vector3(10, 50, 50));
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(moveHorizontal, 0, moveVertical);

        
	}
}
