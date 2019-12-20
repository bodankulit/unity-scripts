using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
	public float x1;
	public float x2;
	public float z1;
	public float z2;
	public float defaultY;
	public float timeBetween = 5.0f;
	public float speed = 2;
	private Vector3 searchPoint;
	public bool aggroed;
	public GameObject player;
	
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(NewLocation), 0.0f, timeBetween);
    }

    // Update is called once per frame
    void Update()
    {
	    if (Vector3.Distance(transform.position, player.transform.position) < 7) {
		    aggroed = true;
		    speed = 5;
		    Pathfind(player.transform.position);
	    }
	    else {
		    aggroed = false;
		    speed = 2;
		    Pathfind(searchPoint);
	    }
    }
	
	void NewLocation() {
		searchPoint = new Vector3(Random.Range(x1, x2), defaultY, Random.Range(z1, z2));
	}

	void Pathfind(Vector3 targetLocation) {
		// Determine which direction to rotate towards
		Vector3 targetDirection = targetLocation - transform.position;
		
		// The step size is equal to speed times frame time.
		float singleStep = Time.deltaTime;
		
		// Rotate the forward vector towards the target direction by one step
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
		newDirection.y = defaultY;

		// Calculate a rotation a step closer to the target and applies rotation to this object
		transform.rotation = Quaternion.LookRotation(newDirection);
		
		transform.position += transform.forward * Time.deltaTime * speed;
	}
}
