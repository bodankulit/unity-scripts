using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
	public Animator anim;
	public string trigger;
	private float timer = 0.0f;
	private float waitingTime = 0.5f;
	public bool interacted;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interacted) {
			anim.SetTrigger(trigger);
			timer+=Time.deltaTime;
			if (timer > waitingTime) {
				timer = 0f;
				anim.ResetTrigger(trigger);
			}
			interacted = false;
		}
    }
}
