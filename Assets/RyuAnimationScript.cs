using UnityEngine;
using System.Collections;

public class RyuAnimationScript : MonoBehaviour {

	private Animator anim;					// Reference to the player's animator component.
	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		// Setting up references.
		anim = GetComponent<Animator>();
		
	}


	// Update is called once per frame
	void Update () {
	
	}

	public void Hadouken(){
		
		anim.SetTrigger("Hadouken");
		
	}
}
