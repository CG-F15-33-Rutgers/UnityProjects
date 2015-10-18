using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent
{
    public NavMeshAgent agent;
    private bool selected;

    public Agent(NavMeshAgent agent)
    {
        this.agent = agent;
        selected = false;
    }

    public void clicked()
    {
        selected = !selected;
    }

    public bool isSelected()
    {
        return selected;
    }
}

public class navcharscript : MonoBehaviour {

    List<Agent> agents = new List<Agent>();

    // Use this for initialization
	void Start () {
        foreach (NavMeshAgent i in GetComponents<NavMeshAgent>())
        {
            agents.Add(new Agent(i));
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetMouseButtonDown (0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit))
            {
                foreach (Agent i in agents)
                {
                    if (hit.transform == i.agent.transform)
                    {
                        i.clicked();
                    }
                }
            }
        }
		if (Input.GetMouseButtonDown (1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast (ray, out hit, 100))
			{
				foreach (Agent i in agents)
                {
                    if (i.isSelected())
                    {
                        i.agent.SetDestination(hit.point);
                    }
                }
			}
		}

	}
	

}
