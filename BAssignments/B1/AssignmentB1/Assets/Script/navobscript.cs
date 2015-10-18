using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class navobscript : MonoBehaviour {

    public float speed;

    private List<Rigidbody> obstacles = new List<Rigidbody>();

    private Rigidbody selected;
   

	
	void Start ()
    {
        obstacles.AddRange(GetComponentsInChildren<Rigidbody>());
        selected = null;
	}
	
	
	void Update ()
    {
	    if (Input.GetMouseButtonDown (0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                foreach (Rigidbody i in obstacles)
                {
                    if (hit.rigidbody.Equals(i))
                    {
                        selected = i;
                    }
                }
            }
        }
	}

    // Rigidbody movement physics
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveTurn;
        if (Input.GetButton("Jump"))
        {
            moveTurn = 10;
        }
        else
        {
            moveTurn = 0;
        }
        
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        Vector3 turn = new Vector3(0, moveTurn, 0);
        selected.AddForce(movement * speed);
        selected.AddTorque(turn);
        
        

    }

   
}
