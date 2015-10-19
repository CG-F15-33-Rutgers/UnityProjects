using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class BotNavControlScript : MonoBehaviour
{
    public float deadZone = 5f;                 // a public setting for how small angles are to be ignored
    public float animSpeed = 1.5f;              // a public setting for overall animator animation speed

    private NavMeshAgent nav;                   // a reference to the navMeshAgent on the character
    private Animator anim;                      // a reference to the animator on the character
    private AnimatorStateInfo currentBaseState; // a reference to the current state of the animator, used for base layer

    private float speed;
    private float angle;

    //static int idleState = Animator.StringToHash("Base Layer.Idle");	
    static int walkState = Animator.StringToHash("Base Layer.Walk");			// these integers are references to our animator's states
    static int runState = Animator.StringToHash("Base Layer.Run");              // and are used to check state for various actions to occur
    static int jumpState = Animator.StringToHash("Base Layer.Jump");                // within our FixedUpdate() function below


    void Start()
    {
        // initialising reference variables
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

        // rotation is not set by navAgent, should be set by animator
        nav.updateRotation = false;
        nav.stoppingDistance = 1f;

        deadZone *= Mathf.Deg2Rad;
        
    }

    void Update()
    {
        NavAnimSetup();
    }

    void onAnimationMove()
    {
        nav.velocity = anim.deltaPosition / Time.deltaTime;
        transform.rotation = anim.rootRotation;
    }

    
    void FixedUpdate()
    {
        float v = speed;
        float h = angle;
        h *= Mathf.Rad2Deg;
        
        if (h >= 90)
        {
            h = 90;
        }else if (h <= -90)
        {
            h = -90;
        }
        h = h / 90;
        
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        anim.speed = animSpeed;                                 // set the speed of our animator to the public variable 'animSpeed'
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0); // set our currentState variable to the current state of the Base Layer (0) of animation

        // toggle run boolean
        if (Input.GetButtonDown("Run"))
        {
            anim.SetBool("Run", true);

        }
        if (Input.GetButtonUp("Run"))
        {
            anim.SetBool("Run", false);

        }


        // jumping

        // only jump if we are in walk or jump state
        if (currentBaseState.fullPathHash == walkState || currentBaseState.fullPathHash == runState)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Jump", true);
            }
        }

        // if we are in the jumping state... 
        else if (currentBaseState.fullPathHash == jumpState)
        {
            //  ..and not still in transition..
            if (!anim.IsInTransition(0))
            {
                // set the Jump to false so that the state does not loop 
                anim.SetBool("Jump", false);
            }

        }


    }
    

    void NavAnimSetup()
    {
        speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;
        angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);
        if(Mathf.Abs(angle) < deadZone)
        {
            transform.LookAt(transform.position + nav.desiredVelocity);
            angle = 0f;
        }

    }

    float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector)
    {
        if(toVector == Vector3.zero)
        {
            return 0f;
        }
        float angle = Vector3.Angle(fromVector, toVector);
        Vector3 normal = Vector3.Cross(fromVector, toVector);
        angle *= Mathf.Sign(Vector3.Dot(normal, upVector));
        angle *= Mathf.Deg2Rad;

        return angle;
    }


    
}
