using UnityEngine;
using System.Collections;

public class NoPhysicsControls : MonoBehaviour {

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;
	public bool jump = false;
	public bool crouch = false;
	public bool hadouken = false;
	public float jumpForce = 400f;
	private Animator anim;					// Reference to the player's animator component.
	public float moveForce = 20f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 2f;	

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;

		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("jump");
			
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}

		if(Input.GetKey(KeyCode.D)){
			transform.position = new  Vector2 (transform.position.x + 5* Time.deltaTime,transform.position.y);
		}
	
	}
}
