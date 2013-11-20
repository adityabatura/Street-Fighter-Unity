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
		crouch = transform.parent.gameObject.GetComponent<PlayerControlScript>().crouch;//GetComponent<PlayerControlScript>().crouch;
		jump = transform.parent.gameObject.GetComponent<PlayerControlScript>().jump;
		bool grounded = transform.parent.gameObject.GetComponent<PlayerControlScript>().grounded;
		//bool crouch = other.crouch;
		//whateva.functionMan();
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("speed", Mathf.Abs(h));

		//if(!grounded){
		anim.SetFloat("Speed", h);


		if(crouch)
		{
			anim.SetBool("Crouch", true);
		}
		else{
			anim.SetBool("Crouch", false);
		}

		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");

			//jump = false;

			transform.parent.gameObject.GetComponent<PlayerControlScript>().jump = false;
		}
	}


}
