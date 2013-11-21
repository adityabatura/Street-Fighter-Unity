using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	private Animator anim;					// Reference to the player's animator component.
	//public PlayerControlScript whateva;
	public bool crouch;
	public bool jump;
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

		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", h);


	/*	if(crouch)
		{
			anim.SetBool("Crouch", true);
		}
		else{
			anim.SetBool("Crouch", false);
		}*/

		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");

			//jump = false;

			//transform.parent.gameObject.GetComponent<PlayerControlScript>().jump = false;
		}
	}

	public void Crouch(){

		anim.SetBool("Crouch", true);

	}

	public void CrouchOff(){
		
		anim.SetBool("Crouch", false);
		
	}

	public void Jump(){

		anim.SetTrigger("Jump");

	}

	public void LP(){
		
		anim.SetTrigger("LP");
		
	}

	public void LK(){
		
		anim.SetTrigger("L_MK");
		
	}


}
