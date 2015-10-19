using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
    public float distanceAway = 10;          // distance from the back of the craft
    public float distanceUp = 10;            // distance above the craft
    public GameObject player;

    Transform follow;

    void Start()
    {
        follow = player.transform;
    }

    void LateUpdate()
    {

        transform.position = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;

        // make sure the camera is looking the right way
        transform.LookAt(follow);
    }
}
